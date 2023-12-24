namespace LibraryLab10;

public class InsuranceCompany : Organisation {
    private uint _insuranceCases; //количество страховых случаев

    public InsuranceCompany(string orgName, int budget, uint insuranceCases) :
        base(orgName, budget) {
        InsuranceCases = insuranceCases;
    }

    public InsuranceCompany() { }

    public uint InsuranceCases {
        get => _insuranceCases;
        set => _insuranceCases = value;
    }

    public override void RandomInit() {
        base.RandomInit();
        var rand = new Random();
        InsuranceCases = (uint)rand.Next(9999);
    }

    public override void Show() {
        base.Show();
        Console.WriteLine($"Количество страховых случаев: {InsuranceCases}");
    }

    public override bool Equals(object? obj) {
        if (obj is not InsuranceCompany ins)
            return false;
        return OrgName == ins.OrgName && Budget == ins.Budget &&
               InsuranceCases == ins.InsuranceCases;
    }
}