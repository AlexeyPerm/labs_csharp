using System;

namespace ClassLibraryLab10;

public class InsuranceCompany : Organisation
{
    public InsuranceCompany(string orgName, int budget, uint insuranceCases) :
        base(orgName, budget)
    {
        InsuranceCases = insuranceCases;
    }

    public InsuranceCompany()
    { }

    public uint InsuranceCases { get; set; }

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

    public override void RandomInit()
    {
        base.RandomInit();
        InsuranceCases = (uint)rand.Next(9999);
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Количество страховых случаев: {InsuranceCases}");
    }

    public void ShowNotOverride()
    {
        base.Show();
        Console.WriteLine($"Количество страховых случаев: {InsuranceCases}");
    }

    public override string ToString()
    {
        return base.ToString() + $"Количество страховых случаев: {InsuranceCases}\n";
    }

    public override bool Equals(object obj)
    {
        if (obj is not InsuranceCompany ins)
            return false;
        return OrgName == ins.OrgName && Budget == ins.Budget &&
               InsuranceCases == ins.InsuranceCases;
    }

    public override object Clone() => (base.Clone(), InsuranceCases);
    public override object ShallowCopy() => (InsuranceCompany)MemberwiseClone();
}