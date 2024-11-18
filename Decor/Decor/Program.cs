using System;


public interface INotifier
{
    void Send(string message);
}

public class EmailNotifier : INotifier
{
    private readonly string _emailAddress;

    public EmailNotifier(string emailAddress)
    {
        _emailAddress = emailAddress;
    }

    public virtual void Send(string message)
    {
        Console.WriteLine($"Отправка email на почту {_emailAddress}: {message}");
    }
}

// Абстрактный декоратор, реализующий интерфейс INotifier
public abstract class NotifierDecorator : INotifier
{
    protected readonly INotifier _notifier;

    public NotifierDecorator(INotifier notifier)
    {
        _notifier = notifier;
    }

    public virtual void Send(string message)
    {
        _notifier.Send(message);
    }
}

// Конкретный декоратор для отправки SMS
public class SmsNotifier : NotifierDecorator
{
    private readonly string _phoneNumber;

    public SmsNotifier(INotifier notifier, string phoneNumber) : base(notifier)
    {
        _phoneNumber = phoneNumber;
    }

    public override void Send(string message)
    {
        base.Send(message); // Передача вызова базовому объекту
        Console.WriteLine($"Отправка SMS на номер {_phoneNumber}: {message}");
    }
}

// Конкретный декоратор для отправки сообщений в Facebook
public class FacebookNotifier : NotifierDecorator
{
    private readonly string _facebookAccount;

    public FacebookNotifier(INotifier notifier, string facebookAccount) : base(notifier)
    {
        _facebookAccount = facebookAccount;
    }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"Отправка сообщения в Facebook аккаунт {_facebookAccount}: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        INotifier notifier = new EmailNotifier("admin@example.com");

        
        notifier = new SmsNotifier(notifier, "+123456789");

        
        notifier = new FacebookNotifier(notifier, "admin_facebook_account");

        
        notifier.Send("Сервер недоступен!");
    }
}
