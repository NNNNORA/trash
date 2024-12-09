using System;

// Абстрактный класс для генерации отчета
public abstract class ReportGenerator
{
    // Шаблонный метод, который будет вызывать последовательность шагов
    public void GenerateReport()
    {
        Console.WriteLine("Начало генерации отчета...");
        CollectData();       // Сбор данных
        ProcessData();       // Обработка данных
        FormatReport();      // Форматирование отчета
        ExportReport();      // Экспорт отчета
        Console.WriteLine("Генерация отчета завершена.");
    }

    // Абстрактные методы, которые должны быть реализованы в конкретных классах
    protected abstract void CollectData(); // Сбор данных
    protected abstract void ProcessData(); // Обработка данных
    protected abstract void FormatReport(); // Форматирование отчета

    // Экспорт отчета — реализация по умолчанию
    protected virtual void ExportReport()
    {
        Console.WriteLine("Экспорт отчета в файл...");
    }
}

// Конкретный класс для отчета по студентам
public class StudentReportGenerator : ReportGenerator
{
    // Сбор данных о студентах (имитация)
    protected override void CollectData()
    {
        Console.WriteLine("Собираем данные о студентах...");
        // Логика сбора данных о студентах может быть здесь
    }

    // Обработка данных о студентах (имитация)
    protected override void ProcessData()
    {
        Console.WriteLine("Обрабатываем данные о студентах...");
        // Логика обработки данных студентов
    }

    // Форматирование отчета по студентам (имитация)
    protected override void FormatReport()
    {
        Console.WriteLine("Форматируем отчет о студентах...");
        // Логика форматирования отчета о студентах
    }
}

// Конкретный класс для отчета по курсам
public class CourseReportGenerator : ReportGenerator
{
    // Сбор данных о курсах (имитация)
    protected override void CollectData()
    {
        Console.WriteLine("Собираем данные о курсах...");
        // Логика сбора данных о курсах может быть здесь
    }

    // Обработка данных о курсах (имитация)
    protected override void ProcessData()
    {
        Console.WriteLine("Обрабатываем данные о курсах...");
        // Логика обработки данных о курсах
    }

    // Форматирование отчета по курсам (имитация)
    protected override void FormatReport()
    {
        Console.WriteLine("Форматируем отчет о курсах...");
        // Логика форматирования отчета о курсах
    }
}

class Program
{
    static void Main()
    {
        // Генерация отчета по студентам
        Console.WriteLine("---- Генерация отчета по студентам ----");
        ReportGenerator studentReportGenerator = new StudentReportGenerator();
        studentReportGenerator.GenerateReport();

        Console.WriteLine("\n-------------------------\n");

        // Генерация отчета по курсам
        Console.WriteLine("---- Генерация отчета по курсам ----");
        ReportGenerator courseReportGenerator = new CourseReportGenerator();
        courseReportGenerator.GenerateReport();
    }
}
