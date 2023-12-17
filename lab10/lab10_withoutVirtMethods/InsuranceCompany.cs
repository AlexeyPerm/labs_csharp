using System;

namespace lab10_withoutVirtMethods;

public class InsuranceCompany : Organisation {
    private uint _insuranceCases; //количество страховых случаев

    public InsuranceCompany(string orgName, string director, int budget, uint insuranceCases) :
        base(orgName, director, budget) {
        InsuranceCases = insuranceCases;
    }

    public InsuranceCompany() { }

    public uint InsuranceCases {
        get => _insuranceCases;
        set => _insuranceCases = value;
    }

    public void RandomInit() {
        base.RandomInit();
        var rand = new Random();
        InsuranceCases = (uint)rand.Next(9999);
    }

    public void Show() {
        base.Show();
        Console.WriteLine($"Количество страховых случаев: {InsuranceCases}");
    }

    public bool Equals(object obj) {
        if (obj is not InsuranceCompany)
            return false;
        var ins = (InsuranceCompany)obj;
        return OrgName == ins.OrgName && Director == ins.Director && Budget == ins.Budget &&
               InsuranceCases == ins.InsuranceCases;
    }
}