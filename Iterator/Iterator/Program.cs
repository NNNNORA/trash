using System;
using System.Collections;
using System.Collections.Generic;

// Класс Book
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public override string ToString()
    {
        return $"Название: {Title}, Автор: {Author}, Год: {Year}";
    }
}

// Класс Library
public class Library : IEnumerable<Book>
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    // Метод для добавления книги в библиотеку
    public void AddBook(Book book)
    {
        books.Add(book);
    }

    // Реализация итератора
    public IEnumerator<Book> GetEnumerator()
    {
        return books.GetEnumerator();
    }

    // Метод для получения итератора (необязательно, используется для совместимости с IEnumerable)
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

// Пример использования
public class Program
{
    public static void Main()
    {
        // Создание библиотеки
        Library library = new Library();

        // Добавление книг
        library.AddBook(new Book("451° по Фаренгейту", "Рэй Брэдбери", 1966));
        library.AddBook(new Book("Повесть о двух городах", "Чарльз Диккенс", 1958));
        library.AddBook(new Book("К востоку от рая", "Джон Стейнбек", 1955));

        // Перебор и вывод книг из библиотеки
        foreach (var book in library)
        {
            Console.WriteLine(book);
        }
    }
}
