using System;
using System.Collections.Generic;

// Структура для уникальных данных (внешнее состояние)
public struct ExtrinsicState
{
    public int Level { get; set; }
    public int Experience { get; set; }

    public ExtrinsicState(int level, int experience)
    {
        Level = level;
        Experience = experience;
    }
}

// Основной класс персонажа
public class Character
{
    // Легковесные свойства (общие)
    public string Name { get; private set; }
    public string Type { get; private set; }
    public string Image { get; private set; }

    // Приватный конструктор
    private Character(string name, string type, string image)
    {
        Name = name;
        Type = type;
        Image = image;
    }

    // Вложенная фабрика для управления объектами
    public class CharacterFactory
    {
        private readonly Dictionary<string, Character> _characters = new();

        public Character GetCharacter(string name, string type, string image)
        {
            string key = $"{name}_{type}";

            if (_characters.ContainsKey(key))
            {
                Console.WriteLine($"Пересоздание существующего персонажа: {name}, Тип: {type}");
                return _characters[key];
            }
            else
            {
                Console.WriteLine($"Создание нового персонажа: {name}, Тип: {type}");
                var newCharacter = new Character(name, type, image);
                _characters[key] = newCharacter;
                return newCharacter;
            }
        }

        public void PrintAllCharacters()
        {
            Console.WriteLine("Все созданные персонажи:");
            foreach (var key in _characters.Keys)
            {
                Console.WriteLine($" - {key}");
            }
        }
    }
}

// Пример использования
class Program
{
    static void Main()
    {
        var factory = new Character.CharacterFactory();

        // Создаем персонажей
        var warrior1 = factory.GetCharacter("Воин", "Ближний", "warrior.png");
        var warrior2 = factory.GetCharacter("Воин", "Ближний", "warrior.png"); // Пересоздание
        var mage = factory.GetCharacter("Маг", "Дальний", "mage.png");

        // Уникальные состояния
        var warriorState1 = new ExtrinsicState(level: 5, experience: 1500);
        var warriorState2 = new ExtrinsicState(level: 9, experience: 2999);
        var mageState = new ExtrinsicState(level: 3, experience: 250);

        // Вывод информации с учетом внешнего состояния
        PrintCharacter(warrior1, warriorState1);
        PrintCharacter(warrior2, warriorState2); // Повторный объект
        PrintCharacter(mage, mageState);

        // Печать всех персонажей
        Console.WriteLine();
        factory.PrintAllCharacters();
    }

    static void PrintCharacter(Character character, ExtrinsicState state)
    {
        Console.WriteLine($"Имя: {character.Name}, Тип: {character.Type}, Фото: {character.Image}, Уровень: {state.Level}, Опыт: {state.Experience}");
    }
}
