public class CPU
{
    public string Model { get; set; }
}

public class Motherboard
{
    public string Model { get; set; }
}

public class RAM
{
    public string Capacity { get; set; }
}

public class Storage
{
    public string Type { get; set; }
}

public class GPU
{
    public string Model { get; set; }
}
public class Computer
{
    public CPU Processor { get; set; }
    public Motherboard MotherBoard { get; set; }
    public RAM Memory { get; set; }
    public Storage Storage { get; set; }
    public GPU VideoCard { get; set; }

    public override string ToString()
    {
        return $"Характеристеки компьютера:\n" +
               $"CPU: {Processor?.Model ?? "Not set"}\n" +
               $"Материнская плата: {MotherBoard?.Model ?? "Not set"}\n" +
               $"RAM: {Memory?.Capacity ?? "Not set"}\n" +
               $"Память: {Storage?.Type ?? "Not set"}\n" +
               $"GPU: {VideoCard?.Model ?? "Not set"}";
    }
}
public class ComputerBuilder
{
    private Computer _computer = new Computer();

    public ComputerBuilder SetCPU(string model)
    {
        _computer.Processor = new CPU { Model = model };
        return this;
    }

    public ComputerBuilder SetMotherboard(string model)
    {
        _computer.MotherBoard = new Motherboard { Model = model };
        return this;
    }

    public ComputerBuilder SetRAM(string capacity)
    {
        _computer.Memory = new RAM { Capacity = capacity };
        return this;
    }

    public ComputerBuilder SetStorage(string type)
    {
        _computer.Storage = new Storage { Type = type };
        return this;
    }

    public ComputerBuilder SetGPU(string model)
    {
        _computer.VideoCard = new GPU { Model = model };
        return this;
    }

    public Computer Build()
    {
        return _computer;
    }
}
class Program
{
    static void Main(string[] args)
    {
        ComputerBuilder builder = new ComputerBuilder();

        Computer myComputer = builder
            .SetCPU("AMD ryzen 7 7700 OEM")
            .SetMotherboard("MSI PRO B650M-A WIFI")
            .SetRAM("64GB")
            .SetStorage("2TB SSD")
            .SetGPU("NVIDIA RTX 3080")
            .Build();

        Console.WriteLine(myComputer);
    }
}
