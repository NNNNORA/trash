using System;

public abstract class EventHandler
{
    protected EventHandler nextHandler;

    // Устанавливаем следующий обработчик в цепочке
    public void SetNextHandler(EventHandler handler)
    {
        nextHandler = handler;
    }

    // Абстрактный метод обработки запроса
    public abstract void HandleRequest(Request request);
}

public class LoggingHandler : EventHandler
{
    public override void HandleRequest(Request request)
    {
        if (request.Type == "Log")
        {
            Console.WriteLine($"Запись события: {request.Content}");
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest(request); // Передаем запрос следующему обработчику
        }
    }
}

public class EmailHandler : EventHandler
{
    public override void HandleRequest(Request request)
    {
        if (request.Type == "Email")
        {
            Console.WriteLine($"Отправка email с содержимым: {request.Content}");
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest(request); // Передаем запрос следующему обработчику
        }
    }
}

public class NotificationHandler : EventHandler
{
    public override void HandleRequest(Request request)
    {
        if (request.Type == "Notification")
        {
            Console.WriteLine($"Отправка уведомления: {request.Content}");
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest(request); // Передаем запрос следующему обработчику
        }
    }
}

public class Request
{
    public string Type { get; set; }
    public string Content { get; set; }

    // Конструктор запроса, который принимает тип и содержимое
    public Request(string type, string content)
    {
        Type = type;
        Content = content;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание обработчиков
        EventHandler loggingHandler = new LoggingHandler();
        EventHandler emailHandler = new EmailHandler();
        EventHandler notificationHandler = new NotificationHandler();

        // Формирование цепочки обработчиков
        loggingHandler.SetNextHandler(emailHandler);
        emailHandler.SetNextHandler(notificationHandler);

        // Создание запросов
        Request logRequest = new Request("Log", "Записать это событие");
        Request emailRequest = new Request("Email", "Отправить этот email");
        Request notificationRequest = new Request("Notification", "Отправить это уведомление");

        // Отправка запросов по цепочке
        Console.WriteLine("Обработка запроса на логирование:");
        loggingHandler.HandleRequest(logRequest);

        Console.WriteLine("\nОбработка запроса на отправку email:");
        loggingHandler.HandleRequest(emailRequest);

        Console.WriteLine("\nОбработка запроса на отправку уведомления:");
        loggingHandler.HandleRequest(notificationRequest);
    }
}
