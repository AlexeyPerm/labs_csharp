using System;

namespace ClassLibraryLab10;

public class Organisation : IInit, IComparable, ICloneable
{
    protected static Random rand = new Random();
    protected string _orgName;
    protected int _budget;

    public string OrgName
    {
        get => _orgName;
        set => _orgName = value;
    }

    public int Budget
    {
        get => _budget;
        set => _budget = value;
    }

    public Organisation()
    {
        OrgName = "EmptyName";
        Budget = 0;
    }

    public Organisation(string orgName, int budget)
    {
        OrgName = orgName;
        Budget = budget;
    }

    public virtual void Init()
    {
        Console.Write("Введите название организации:\n> ");
        OrgName = Console.ReadLine();

        Console.Write("Введите объём бюджета органзиции:\n> ");
        Budget = InputDigit();
        while (Budget < 0)
        {
            Console.Write("Бюджет должен быть больше 0\n> ");
            Budget = InputDigit();
        }
    } //end of method Init

    public virtual void RandomInit()
    {
        string[] orgName =
        {
            "Хмели-Сунели", "Шестёрочка", "Apple", "HP", "ASUS", "РосАтом",
            "Эр-Телеком", "ГРЧЦ", "РЖД", "Нефтехимпром", "Лукойл", "МСБ", "Лента", "Русал", "НорНикель", "КГБ"
        };
        OrgName = orgName[rand.Next(orgName.Length)];
        Budget = rand.Next(500, 10000);
    } //end of method RandomInit


    public virtual void Show()
    {
        Console.WriteLine($"Название: {OrgName}\n" +
                          $"Бюджет: {Budget} рублей");
    } //end of method Show

    public void ShowNotOverride()
    {
        Console.WriteLine($"Название: {OrgName}\n" +
                          $"Бюджет: {Budget} рублей");
    } //end of method Show

    public override string ToString()
    {
        return $"Название: {OrgName}\n" +
               $"Бюджет: {Budget} рублей\n";
    }

    public override bool Equals(object obj)
    {
        if (obj is not Organisation organisation)
            return false;
        return OrgName == organisation.OrgName && Budget == organisation.Budget;
    }

    public virtual object Clone() => new Organisation(OrgName, Budget);

    public virtual object ShallowCopy() => (Organisation)MemberwiseClone();


    public int CompareTo(object obj)
    {
        if (obj is Organisation org)
        {
            return string.Compare(OrgName, org.OrgName);
        }

        throw new ArgumentException("Некорректное значение параметра");
    }

    protected static int InputDigit()
    {
        int result;
        while (!int.TryParse(Console.ReadLine(), out result))
        {
            Console.Write("Ошибка! Должен быть тип int\nПовторите ввод\n> ");
        }

        return result;
    }
}