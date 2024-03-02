using System;

namespace ClassLibraryLab10;

public class Library : Organisation
{
    private uint _booksTotalNum; //Количество книг в библиотеке.

    public uint BooksTotalNum
    {
        get => _booksTotalNum;
        set => _booksTotalNum = value;
    }

    public Library()
    { }

    public Library(string orgName, int budget, uint booksTotalNum) : base(orgName, budget)
    {
        BooksTotalNum = booksTotalNum;
    }

    /// <summary>
    /// Ручной ввод информации об объекту. Вызывает конструктор базового класса.
    /// </summary>
    public override void Init()
    {
        base.Init();
        Console.Write("Введите количество книг в библиотеке:\n> ");
        var error = false;
        while (!error)
        {
            try
            {
                BooksTotalNum = checked((uint)InputDigit());
                error = true;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Количество книг должно быть не меньше 0");
                Console.Write("Введите количество книг в библиотеке:\n> ");
            }
        }
    }

    /// <summary>
    /// Формирование объекта с помощью ДСЧ. Вызывает конструктор базового класса.
    /// </summary>
    public override void RandomInit()
    {
        base.RandomInit();
        BooksTotalNum = (uint)rand.Next(100000);
    }

    /// <summary>
    /// Вывод на экран информации об объекте
    /// </summary>
    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Количество книг: {BooksTotalNum}");
    }

    /// <summary>
    /// Не виртуальный метод Show()
    /// </summary>
    public void ShowNotOverride()
    {
        base.Show();
        Console.WriteLine($"Количество книг: {BooksTotalNum}");
    }

    public override string ToString()
    {
        return base.ToString() + $"Количество книг: {BooksTotalNum}\n";
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Library library)
            return false;
        return OrgName == library.OrgName && Budget == library.Budget &&
               BooksTotalNum == library.BooksTotalNum;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), _booksTotalNum);
    }

    public override object Clone() => new Library(OrgName, Budget, BooksTotalNum);
    public override object ShallowCopy() => (Library)MemberwiseClone();
}