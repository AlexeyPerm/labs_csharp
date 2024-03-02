using System;

namespace ClassLibraryLab10;

public class InsuranceCompany : Organisation
{
    private uint _insuranceCases; // количество страховых случаев

    public uint InsuranceCases
    {
        get => _insuranceCases;
        set => _insuranceCases = value;
    }

    public InsuranceCompany()
    { }

    public InsuranceCompany(string orgName, int budget, uint insuranceCases) :
        base(orgName, budget)
    {
        InsuranceCases = insuranceCases;
    }

    /// <summary>
    /// Ручной ввод информации об объекту. Вызывает конструктор базового класса.
    /// </summary>
    public override void Init()
    {
        base.Init();
        Console.Write("Введите страховых случаев:\n> ");
        var error = false;
        while (!error)
        {
            try
            {
                InsuranceCases = checked((uint)InputDigit());
                error = true;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Количество страховых случаев должно быть не меньше 0");
                Console.Write("Введите количество страховых случаев:\n> ");
            }
        }
    }

    /// <summary>
    /// Формирование объекта с помощью ДСЧ. Вызывает конструктор базового класса.
    /// </summary>
    public override void RandomInit()
    {
        base.RandomInit();
        InsuranceCases = (uint)rand.Next(9999);
    }

    /// <summary>
    /// Вывод на экран информации об объекте
    /// </summary>
    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Количество страховых случаев: {InsuranceCases}");
    }

    /// <summary>
    /// Не виртуальный метод Show()
    /// </summary>
    public void ShowNotOverride()
    {
        base.Show();
        Console.WriteLine($"Количество страховых случаев: {InsuranceCases}");
    }

    public override string ToString()
    {
        return base.ToString() + $"Количество страховых случаев: {InsuranceCases}\n";
    }

    public override bool Equals(object? obj)
    {
        if (obj is not InsuranceCompany ins)
            return false;

        return OrgName == ins.OrgName && Budget == ins.Budget &&
               InsuranceCases == ins.InsuranceCases;
    }


    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), _insuranceCases);
    }


    public override object Clone() => new InsuranceCompany(OrgName, Budget, InsuranceCases);
    public override object ShallowCopy() => (InsuranceCompany)MemberwiseClone();
}