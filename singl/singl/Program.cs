using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

public class Servers 
{
    private static readonly object _lock = new object();
    private static readonly Lazy<Servers> _instance = new Lazy<Servers>(() => new Servers());

    private readonly Dictionary<string, bool> _servers = new Dictionary<string, bool>();

    private Servers() { }

    public static Servers Instance => _instance.Value;

    public bool AddServer(string server)
    {
        if (string.IsNullOrEmpty(server))
            return false;
        
        if (!server.StartsWith("http://", StringComparison.OrdinalIgnoreCase) && !server.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            return false;

        lock (_lock)
        {
            if (_servers.ContainsKey(server))
                return false;

            _servers.Add(server, true);
            return true;
        }
    }
  
    public List<string> GetHttpServers()
    {
        lock (_lock) 
        {
            return _servers.Where(s => s.Key.StartsWith("http://", StringComparison.OrdinalIgnoreCase)).Select(s => s.Key).ToList();
        }
    }
    
    public List<string> GetHttpsServers()
    {
        lock (_lock) 
        {
            return _servers.Where(s => s.Key.StartsWith("https://", StringComparison.OrdinalIgnoreCase)).Select(s => s.Key).ToList();
        }
    }
}
public class EagerServers 
{
    private static readonly EagerServers _instance = new EagerServers();
    private readonly Dictionary<string, bool> _servers = new Dictionary<string, bool>();

    public static EagerServers Instance => _instance;

    public bool AddServer(string server)
    {
        if (string.IsNullOrEmpty(server))
            return false;

        if (!server.StartsWith("http://", StringComparison.OrdinalIgnoreCase) && !server.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            return false;

        if (_servers.ContainsKey(server))
            return false;

        _servers.Add(server, true);
        return true;
    }

    public List<string> GetHttpServers()
    {
        return _servers.Where(s => s.Key.StartsWith("http://", StringComparison.OrdinalIgnoreCase)).Select(s => s.Key).ToList();
    }

    public List<string> GetHttpsServers()
    {
        return _servers.Where(s => s.Key.StartsWith("https://", StringComparison.OrdinalIgnoreCase)).Select(s => s.Key).ToList();
    }
}
public class Program
{
    public static void Main()
    {
        var servers = Servers.Instance;
        
        Console.WriteLine(servers.AddServer("http://example.com")); // true
        Console.WriteLine(servers.AddServer("https://example.com")); // true
        Console.WriteLine(servers.AddServer("http://example.com")); // false
        Console.WriteLine(string.Join(", ", servers.GetHttpServers())); // http://example.com
        Console.WriteLine(string.Join(", ", servers.GetHttpsServers())); // https://example.com
    }
}