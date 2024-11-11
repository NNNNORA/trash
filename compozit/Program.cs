using System;
using System.Collections.Generic;

public interface IDocumentComponent
{
    void Add(IDocumentComponent component);  // добавление дочернего компонента
    void Remove(IDocumentComponent component);
    void Display(int indent = 0);  //для иерархической структуры
}


public class Paragraph : IDocumentComponent
{
    public string Text { get; set; }

    public Paragraph(string text)
    {
        Text = text;
    }

    // Добавление в параграф невозможно, потому что он не может содержать других компонентов
    public void Add(IDocumentComponent component)
    {
        throw new InvalidOperationException("Параграф не может содержать другие компоненты.");
        
    }

    public void Remove(IDocumentComponent component)
    {
        throw new InvalidOperationException("Параграф  не может содержать другие компоненты.");
    }

   
    public void Display(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + "Параграф: " + Text);
    }
}


public class Section : IDocumentComponent
{
    public string Title { get; set; }  
    private List<IDocumentComponent> _components = new List<IDocumentComponent>(); 

    public Section(string title)
    {
        Title = title;
    }


    public void Add(IDocumentComponent component)
    {
        _components.Add(component);
    }

   
    public void Remove(IDocumentComponent component)
    {
        _components.Remove(component);
    }

    
    public void Display(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + "Секции: " + Title);
        foreach (var component in _components)
        {
            component.Display(indent + 2);  
        }
    }
}


public class Document : IDocumentComponent
{
    private List<IDocumentComponent> _sections = new List<IDocumentComponent>();  // список разделов

  
    public void Add(IDocumentComponent component)
    {
        _sections.Add(component);
    }

    
    public void Remove(IDocumentComponent component)
    {
        _sections.Remove(component);
    }

   
    public void Display(int indent = 0)
    {
        Console.WriteLine("Документ:");
        foreach (var section in _sections)
        {
            section.Display(indent + 2);  
        }
    }
}


public class Program
{
    public static void Main()
    {
       
        var para1 = new Paragraph("Это первый параграф.");
        var para2 = new Paragraph("Это второй параграф.");
        var para3 = new Paragraph("Это третий параграф.");

        
        var section1 = new Section("Введение");
        section1.Add(para1); 

        var section2 = new Section("Подробности");
        section2.Add(para2); 

        var section3 = new Section("Заключение");
        section3.Add(para3);  

        
        var document = new Document();
        document.Add(section1);  
        document.Add(section2);  
        document.Add(section3);  
        document.Display();
    }
}
