public interface INotificationSender //интерфейс определяет метод
{
    void Send(string message);
}
//оба класса реализуют интерфейс типо отправляют сообщение
public class EmailSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Отправка:{message}");
    }
}

public class SmsSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Отправка смс: {message}");
    }
}
//содержит ссылку на интерфейс и принимает объект, который его реализует
public abstract class Notification
{
    protected INotificationSender NotificationSender;

    protected Notification(INotificationSender notificationSender)
    {
        NotificationSender = notificationSender;
    }

    public abstract void Notify(string message);
}
//классы наследники которые реализуеют абстрактный метод нотифай из родителя
public class TextNotification : Notification
{
    public TextNotification(INotificationSender notificationSender) : base(notificationSender) { }

    public override void Notify(string message)
    {
        NotificationSender.Send($"Текст: {message}");
    }
}

public class HtmlNotification : Notification
{
    public HtmlNotification(INotificationSender notificationSender) : base(notificationSender) { }

    public override void Notify(string message)
    {
        NotificationSender.Send($"<html><body><p>{message}</p></body></html>");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        INotificationSender emailSender = new EmailSender();
        INotificationSender smsSender = new SmsSender();
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Magenta;
        Notification textEmail = new TextNotification(emailSender);
        textEmail.Notify("Привки!");

        Notification htmlSms = new HtmlNotification(smsSender);
        htmlSms.Notify("Привет черес смс!");
        
    }
}
