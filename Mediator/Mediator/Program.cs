using System;
using System.Collections.Generic;

public class Message
{
    public string Sender { get; set; }
    public string Recipient { get; set; }
    public string Text { get; set; }

    public Message(string sender, string recipient, string text)
    {
        Sender = sender;
        Recipient = recipient;
        Text = text;
    }
}

public class User
{
    public string Name { get; private set; }
    private ChatMediator _chatMediator;
    public List<Message> MessageHistory { get; private set; }

    public User(string name)
    {
        Name = name;
        MessageHistory = new List<Message>();
    }

    // Присоединить пользователя к чату
    public void JoinChat(ChatMediator chatMediator)
    {
        _chatMediator = chatMediator;
        _chatMediator.AddUser(this);
    }

    // Отправить сообщение
    public void SendMessage(string recipient, string message)
    {
        Console.WriteLine($"{Name} отправил сообщение {recipient}: {message}");
        _chatMediator.SendMessage(this, recipient, message);
    }

    // Получить сообщение
    public void ReceiveMessage(Message message)
    {
        MessageHistory.Add(message);
        Console.WriteLine($"{Name} получил сообщение от {message.Sender}: {message.Text}");
    }

    // Выйти из чата
    public void LeaveChat()
    {
        _chatMediator.RemoveUser(this);
        Console.WriteLine($"{Name} покинул чат.");
    }
}

public class ChatMediator
{
    private List<User> _users;

    public ChatMediator()
    {
        _users = new List<User>();
    }

    // Добавить пользователя в чат
    public void AddUser(User user)
    {
        _users.Add(user);
    }

    // Удалить пользователя из чата
    public void RemoveUser(User user)
    {
        _users.Remove(user);
    }

    // Отправить сообщение пользователю
    public void SendMessage(User sender, string recipientName, string message)
    {
        var recipient = _users.Find(u => u.Name == recipientName);

        if (recipient != null)
        {
            var msg = new Message(sender.Name, recipientName, message);
            recipient.ReceiveMessage(msg);
        }
        else
        {
            Console.WriteLine($"Ошибка: пользователь {recipientName} не найден.");
        }
    }
}

class Program
{
    static void Main()
    {
        // Создание чат-посредника
        ChatMediator chatMediator = new ChatMediator();

        // Создание пользователей
        User zotik = new User("Зотик");
        User sadok = new User("Садок");
        User feodul = new User("Феодул");

        // Пользователи присоединяются к чату
        zotik.JoinChat(chatMediator);
        sadok.JoinChat(chatMediator);
        feodul.JoinChat(chatMediator);

        // Отправка сообщений
        zotik.SendMessage("Садок", "Привет, Садок!");
        sadok.SendMessage("Зотик", "Привет, Зотик! Как ты?");
        feodul.SendMessage("Зотик", "Привет, Зотик! Как дела?");

        // Вывод истории сообщений
        Console.WriteLine("\nИстория сообщений для Зотика:");
        foreach (var message in zotik.MessageHistory)
        {
            Console.WriteLine($"{message.Sender} -> {message.Recipient}: {message.Text}");
        }

        Console.WriteLine("\nИстория сообщений для Садока:");
        foreach (var message in sadok.MessageHistory)
        {
            Console.WriteLine($"{message.Sender} -> {message.Recipient}: {message.Text}");
        }

        // Пользователь выходит из чата
        zotik.LeaveChat();

        // Попробуем отправить сообщение после выхода
        sadok.SendMessage("Зотик", "Ты умер?");
    }
}
