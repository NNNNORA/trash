using System;

public class ComputerGame
{
    private string name;
    private PegiAgeRating pegiAgeRating;
    private double budgetInMillionsOfDollars;
    private int minimumGpuMemoryInMegabytes;
    private int diskSpaceNeededInGB;
    private int ramNeededInGb;
    private int coresNeeded;
    private double coreSpeedInGhz;

    public ComputerGame(string name,
                        PegiAgeRating pegiAgeRating,
                        double budgetInMillionsOfDollars,
                        int minimumGpuMemoryInMegabytes,
                        int diskSpaceNeededInGB,
                        int ramNeededInGb,
                        int coresNeeded,
                        double coreSpeedInGhz)
    {
        this.name = name;
        this.pegiAgeRating = pegiAgeRating;
        this.budgetInMillionsOfDollars = budgetInMillionsOfDollars;
        this.minimumGpuMemoryInMegabytes = minimumGpuMemoryInMegabytes;
        this.diskSpaceNeededInGB = diskSpaceNeededInGB;
        this.ramNeededInGb = ramNeededInGb;
        this.coresNeeded = coresNeeded;
        this.coreSpeedInGhz = coreSpeedInGhz;
    }

    public string GetName()
    {
        return name;
    }

    public PegiAgeRating GetPegiAgeRating()
    {
        return pegiAgeRating;
    }

    public double GetBudgetInMillionsOfDollars()
    {
        return budgetInMillionsOfDollars;
    }

    public int GetMinimumGpuMemoryInMegabytes()
    {
        return minimumGpuMemoryInMegabytes;
    }

    public int GetDiskSpaceNeededInGB()
    {
        return diskSpaceNeededInGB;
    }

    public int GetRamNeededInGb()
    {
        return ramNeededInGb;
    }

    public int GetCoresNeeded()
    {
        return coresNeeded;
    }

    public double GetCoreSpeedInGhz()
    {
        return coreSpeedInGhz;
    }
}

public enum PegiAgeRating
{
    P3 = 3, P7 = 7, P12 = 12, P16 = 16, P18 = 18
}

public class Requirements
{
    private int gpuGb;
    private int HDDGb;
    private int RAMGb;
    private double cpuGhz;
    private int coresNum;

    public Requirements(int gpuGb, int HDDGb, int RAMGb, double cpuGhz, int coresNum)
    {
        this.gpuGb = gpuGb;
        this.HDDGb = HDDGb;
        this.RAMGb = RAMGb;
        this.cpuGhz = cpuGhz;
        this.coresNum = coresNum;
    }

    public int GetGpuGb()
    {
        return gpuGb;
    }

    public int GetHDDGb()
    {
        return HDDGb;
    }

    public int GetRAMGb()
    {
        return RAMGb;
    }

    public double GetCpuGhz()
    {
        return cpuGhz;
    }

    public int GetCoresNum()
    {
        return coresNum;
    }
}

public interface PCGame
{
    string GetTitle();
    int GetPegiAllowedAge();
    bool IsTripleAGame();
    Requirements GetRequirements();
}

public class ComputerGameAdapter : PCGame
{
    private ComputerGame computerGame;

    public ComputerGameAdapter(ComputerGame computerGame)
    {
        this.computerGame = computerGame;
    }

    public string GetTitle()
    {
        return computerGame.GetName();
    }

    public int GetPegiAllowedAge()
    {
        return (int)computerGame.GetPegiAgeRating();
    }

    public bool IsTripleAGame()
    {
        return computerGame.GetBudgetInMillionsOfDollars() > 50;
    }

    public Requirements GetRequirements()
    {
        return new Requirements(
            computerGame.GetMinimumGpuMemoryInMegabytes() / 1024, // Конвертируем в GB
            computerGame.GetDiskSpaceNeededInGB(),
            computerGame.GetRamNeededInGb(),
            computerGame.GetCoreSpeedInGhz(),
            computerGame.GetCoresNeeded()
        );
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Пример создания объекта ComputerGame
        ComputerGame game = new ComputerGame(
            "Call of Duty®: Modern Warfare",
            PegiAgeRating.P18,
            250, // Бюджет 250 миллионов
            8192, // 8 ГБ GPU
            90, // 90 ГБ дискового пространства
            16, // 16 ГБ ОЗУ
            4, // 4 ядра
            3.5 // 3.5 ГГц
        );

        // Создание адаптера
        PCGame adapter = new ComputerGameAdapter(game);

        // Использование адаптера
        Console.WriteLine($"Title: {adapter.GetTitle()}");
        Console.WriteLine($"Allowed Age: {adapter.GetPegiAllowedAge()}");
        Console.WriteLine($"Is Triple A: {adapter.IsTripleAGame()}");

        Requirements requirements = adapter.GetRequirements();
        Console.WriteLine($"Requirements: {requirements.GetGpuGb()} GB GPU, " +
                          $"{requirements.GetHDDGb()} GB HDD, " +
                          $"{requirements.GetRAMGb()} GB RAM, " +
                          $"{requirements.GetCpuGhz()} GHz CPU, " +
                          $"{requirements.GetCoresNum()} Cores");
    }
}
