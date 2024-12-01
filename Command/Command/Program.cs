using System;
using System.Collections.Generic;

// Интерфейс команды
public interface ICommand
{
    void Execute();
    void Undo();
}

// Класс редактора текста
public class TextEditor
{
    public string Text { get; private set; } = string.Empty;

    public void InsertText(string text, int position)
    {
        if (position < 0 || position > Text.Length)
            throw new ArgumentOutOfRangeException(nameof(position), "Invalid position for inserting text.");
        Text = Text.Insert(position, text);
    }

    public void DeleteText(int position, int length)
    {
        if (position < 0 || position >= Text.Length || position + length > Text.Length)
            throw new ArgumentOutOfRangeException(nameof(position), "Invalid position or length for deleting text.");
        Text = Text.Remove(position, length);
    }
}

// Команда для ввода текста
public class InsertTextCommand : ICommand
{
    private readonly TextEditor _editor;
    private readonly string _text;
    private readonly int _position;

    public InsertTextCommand(TextEditor editor, string text, int position)
    {
        _editor = editor;
        _text = text;
        _position = position;
    }

    public void Execute()
    {
        _editor.InsertText(_text, _position);
    }

    public void Undo()
    {
        _editor.DeleteText(_position, _text.Length);
    }
}

// Команда для удаления текста
public class DeleteTextCommand : ICommand
{
    private readonly TextEditor _editor;
    private readonly int _position;
    private readonly int _length;
    private string _deletedText;

    public DeleteTextCommand(TextEditor editor, int position, int length)
    {
        _editor = editor;
        _position = position;
        _length = length;
    }

    public void Execute()
    {
        _deletedText = _editor.Text.Substring(_position, _length);
        _editor.DeleteText(_position, _length);
    }

    public void Undo()
    {
        _editor.InsertText(_deletedText, _position);
    }
}

// Класс для управления командами
public class CommandManager
{
    private readonly Stack<ICommand> _commandHistory = new();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commandHistory.Push(command);
    }

    public void Undo()
    {
        if (_commandHistory.Count > 0)
        {
            ICommand lastCommand = _commandHistory.Pop();
            lastCommand.Undo();
        }
        else
        {
            Console.WriteLine("No commands to undo.");
        }
    }
}

// Тестирование
class Program
{
    static void Main()
    {
        var editor = new TextEditor();
        var manager = new CommandManager();

        // Ввод текста
        var insertCommand1 = new InsertTextCommand(editor, "Hello, ", 0);
        manager.ExecuteCommand(insertCommand1);

        var insertCommand2 = new InsertTextCommand(editor, "world!", 7);
        manager.ExecuteCommand(insertCommand2);

        Console.WriteLine($"Text after insertion: {editor.Text}");

        // Удаление текста
        var deleteCommand = new DeleteTextCommand(editor, 5, 2);
        manager.ExecuteCommand(deleteCommand);

        Console.WriteLine($"Text after deletion: {editor.Text}");

        // Отмена операций
        manager.Undo();
        Console.WriteLine($"Text after undo: {editor.Text}");

        manager.Undo();
        Console.WriteLine($"Text after undo: {editor.Text}");

        manager.Undo();
        Console.WriteLine($"Text after undo: {editor.Text}");
    }
}
