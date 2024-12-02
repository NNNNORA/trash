using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface ISubject
{
    string Request(string request);
}

public class RealSubject : ISubject
{
    public string Request(string request)
    {
        // Логика, которую нужно защитить или контролировать
        Console.WriteLine("RealSubject: Обработка запроса...");
        return $"Ответ на запрос '{request}'";
    }
}

public class Proxy : ISubject
{
    private RealSubject _realSubject;
    private Dictionary<string, (string Response, DateTime Timestamp)> _cache;
    private TimeSpan _cacheDuration;
    private string _currentUser;

    public Proxy(string currentUser)
    {
        _realSubject = new RealSubject();
        _cache = new Dictionary<string, (string Response, DateTime Timestamp)>();
        _cacheDuration = TimeSpan.FromSeconds(30); // Кэшируем запросы на 30 секунд
        _currentUser = currentUser;
    }

    public string Request(string request)
    {
        // Проверка прав доступа для текущего пользователя
        Console.WriteLine($"Proxy: Проверяю права доступа для пользователя '{_currentUser}'.");

        if (!HasAccess())
        {
            return "Доступ запрещён. У вас нет прав на выполнение этого запроса.";
        }

        // Проверка, есть ли в кэше актуальный результат
        if (_cache.ContainsKey(request) && (DateTime.Now - _cache[request].Timestamp) < _cacheDuration)
        {
            Console.WriteLine("Proxy: Возвращаю результат из кэша.");
            return _cache[request].Response;
        }

        // Если кэша нет или результат устарел, выполняем запрос через RealSubject
        Console.WriteLine("Proxy: Обращение к RealSubject.");
        var response = _realSubject.Request(request);

        // Кэшируем ответ
        _cache[request] = (response, DateTime.Now);

        return response;
    }

    private bool HasAccess()
    {
        // Реализуем логику проверки прав доступа (например, проверка авторизации)
        // В примере пользователю "Admin" разрешается доступ, а пользователю "Guest" нет.
        if (_currentUser == "Admin")
        {
            return true;
        }
        else if (_currentUser == "Guest")
        {
            return false;
        }

        return false;
    }
}

public class Program
{
    public static void Main()
    {
        ISubject proxyAdmin = new Proxy("Admin");
        ISubject proxyGuest = new Proxy("Guest");

        // Пример запросов для администратора
        Console.WriteLine(proxyAdmin.Request("Запрос 1"));
        Console.WriteLine(proxyAdmin.Request("Запрос 1"));  // Должен использовать кэшированный ответ

        // Пример запросов для гостя
        Console.WriteLine(proxyGuest.Request("Запрос 1"));
    }
}
