using System;

namespace ClassLibraryLab10;

public class Star : IInit
{
    public string Name { get; set; }
    public int VisualBrightness { get; set; }
    public int Mass { get; set; }

    public Star()
    { }

    public Star(string name, int visualBrightness, int mass)
    {
        Name = name;
        VisualBrightness = visualBrightness;
        Mass = mass;
    }

    public override string ToString()
    {
        return $"Название звезды: {Name}\n" +
               $"Видимая звёздная величина: {VisualBrightness}\n" +
               $"Масса: {Mass}\n";
    }

    public void Show()
    {
        Console.WriteLine($"Название звезды: {Name}\n" +
                          $"Видимая звёздная величина: {VisualBrightness}\n" +
                          $"Масса: {Mass}");
    }

    public virtual void RandomInit()
    {
        var rand = new Random();
        string[] name = ["Альзирр", "Киссин", "Солнце", "Альдебаран", "Сириус", "Бетельгейзе", "Андромеда", "Регул "];
        Name = name[rand.Next(name.Length)];
        VisualBrightness = rand.Next(1, 20);
        Mass = rand.Next(10, 1000);
    }


    public virtual void Init()
    {
        Console.Write("Введите название звезды:\n> ");
        Name = Console.ReadLine();

        Console.Write("Введите видимую звёздную величину:\n> ");
        VisualBrightness = InputDigit();

        Console.Write("Введите массу:\n> ");
        Mass = InputDigit();
    }

    private static int InputDigit()
    {
        int result;
        while (!int.TryParse(Console.ReadLine(), out result))
        {
            Console.Write("Ошибка! Должен быть тип int\nПовторите ввод\n> ");
        }

        return result;
    }

    public override bool Equals(object obj)
    {
        if (obj is not Star star)
            return false;
        return Name == star.Name && VisualBrightness == star.VisualBrightness && Mass == star.Mass;
    }

    public object Clone() => new Star(Name, VisualBrightness, Mass);
    public object ShallowCopy() => (Star)MemberwiseClone();
}