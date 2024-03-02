namespace ClassLibraryLab10;

public class Shipyard : Factory
{
    private uint _builtShips; //Количество построенных судн

    public uint BuiltShips
    {
        get => _builtShips;
        private set => _builtShips = value;
    }

    public Shipyard()
    { }

    public Shipyard(string orgName, int budget, uint engeneersCount, uint builtShips) :
        base(orgName, budget, engeneersCount)
    {
        BuiltShips = builtShips;
    }

    /// <summary>
    /// Ручной ввод информации об объекту. Вызывает конструктор базового класса.
    /// </summary>
    public override void Init()
    {
        base.Init();
        Console.Write("Введите количество построеных судн:\n> ");
        var error = false;
        while (!error)
        {
            try
            {
                BuiltShips = checked((uint)InputDigit());
                error = true;
            }
            catch (OverflowException)
            {
                Console.WriteLine("количество построеных судн должно быть не меньше 0");
                Console.Write("Введите количество построеных судн:\n> ");
            }
        }
    }

    /// <summary>
    /// Формирование объекта с помощью ДСЧ. Вызывает конструктор базового класса.
    /// </summary>
    public override void RandomInit()
    {
        base.RandomInit();
        BuiltShips = (uint)rand.Next(100, 500);
    }

    /// <summary>
    /// Вывод на экран информации об объекте
    /// </summary>
    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Количество построеных судн: {BuiltShips}");
    }


    /// <summary>
    /// Не виртуальный метод Show()
    /// </summary>
    public new void ShowNotOverride()
    {
        base.Show();
        Console.WriteLine($"Количество построеных судн: {BuiltShips}");
    }

    public override string ToString()
    {
        return base.ToString() + $"Количество построеных судн: {BuiltShips}\n";
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Shipyard sh)
            return false;
        return OrgName == sh.OrgName && Budget == sh.Budget &&
               BuiltShips == sh.BuiltShips;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), _builtShips);
    }


    public override object Clone() => new Shipyard(OrgName, Budget, EngeneersCount, BuiltShips);
    public override object ShallowCopy() => (Shipyard)MemberwiseClone();
}