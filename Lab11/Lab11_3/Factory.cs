namespace Lab113;

public class Factory : Organisation
{
    protected uint _engeneersCount; // Количество инженеров на фабрике

    public uint EngeneersCount
    {
        get => _engeneersCount;
        set => _engeneersCount = value;
    }

    public Factory()
    {
        EngeneersCount = 0;
    }

    public Factory(string orgName, int budget, uint engeneersCount) :
        base(orgName, budget)
    {
        EngeneersCount = engeneersCount;
    }

    public Organisation BaseOrganisation => new(OrgName, Budget);


    /// <summary>
    /// Ручной ввод информации об объекту. Вызывает конструктор базового класса.
    /// </summary>
    public override void Init()
    {
        base.Init();
        Console.Write("Введите количество инженеров в органзиции:\n> ");
        var error = false;
        while (!error)
        {
            try
            {
                EngeneersCount = checked((uint)InputDigit());
                error = true;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Количество инженеров должно быть больше 0");
                Console.Write("Введите количество инженеров в органзиции:\n> ");
            }
        }
    }

    /// <summary>
    /// Формирование объекта с помощью ДСЧ. Вызывает конструктор базового класса.
    /// </summary>
    public override void RandomInit()
    {
        base.RandomInit();
        EngeneersCount = (uint)rand.Next(999);
    }

    /// <summary>
    /// Вывод на экран информации об объекте
    /// </summary>
    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Количество инженеров: {EngeneersCount}");
    }

    /// <summary>
    /// Не виртуальный метод Show()
    /// </summary>
    public void ShowNotOverride()
    {
        base.Show();
        Console.WriteLine($"Количество инженеров: {EngeneersCount}");
    }

    public override string ToString()
    {
        return base.ToString() + $"Количество инженеров: {EngeneersCount}\n";
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Factory)
            return false;
        var f = (Factory)obj;
        return OrgName == f.OrgName && Budget == f.Budget &&
               EngeneersCount == f.EngeneersCount;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), _engeneersCount);
    }

    public override object Clone() => new Factory(OrgName, Budget, EngeneersCount);
    public override object ShallowCopy() => (Factory)MemberwiseClone();
}