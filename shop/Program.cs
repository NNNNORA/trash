using System;
using System.Collections.Generic;

public abstract class Product
{
    public string Name { get; set; }
    public virtual decimal Price { get; set; }

    public abstract string GetInfo();
}

public class Toy : Product
{
    public int AgeGroup { get; set; }

    public override decimal Price
    {
        get { return base.Price * 0.9m; } //1 0% 
        set { base.Price = value; }
    }

    public override string GetInfo()
    {
        return $"Игрушка: {Name}, Возрастная группа: {AgeGroup}, Цена: {Price}";
    }
}

public class Meat : Product
{
    public string Type { get; set; }

    public override decimal Price
    {
        get { return base.Price * 0.85m; } // 15% скидка на мясо
        set { base.Price = value; }
    }

    public override string GetInfo()
    {
        return $"Мясо: {Name}, Тип: {Type}, Цена: {Price}";
    }
}

public class Drinks : Product
{
    public string Flavor { get; set; }

    public override decimal Price
    {
        get { return base.Price * 0.95m; } // 5% скидка на напитки
        set { base.Price = value; }
    }

    public override string GetInfo()
    {
        return $"Напиток: {Name}, Вкус: {Flavor}, Цена: {Price}";
    }
}

public class Book : Product
{
    public string Author { get; set; }

    public override decimal Price
    {
        get { return base.Price * 0.8m; } // 20% скидка на книги
        set { base.Price = value; }
    }

    public override string GetInfo()
    {
        return $"Книга: {Name}, Автор: {Author}, Цена: {Price}";
    }
}
public class Bag : Product
{
    public int Volume { get; set; }
    public override decimal Price
    {
        get { return base.Price * 0.9m; } // 10% скидка на рюкзаки
        set { base.Price = value; }
    }

    public override string GetInfo()
    {
        return $"Рюкзак: {Name}, Объем: {Volume}, Цена: {Price}";
    }
}


    class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>
        {
            new Toy { Name = "Хаги ваги", AgeGroup = 5, Price = 100 },
            new Meat { Name = "Курилка", Type = "Свежая", Price = 200 },
            new Drinks { Name = "Флеш", Flavor = "Классическей", Price = 50 },
            new Book { Name = "Неночь", Author = "Ктото попыткин", Price = 300 },
            new Bag {Name = "Многоманихранями", Volume = 20, Price = 1000}
        };

        foreach (var product in products)
        {
            Console.WriteLine(product.GetInfo());
        }
    }
}