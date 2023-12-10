using System;

namespace Lab10;

public class Factory : Organisation {
    protected uint _engeneersCount;

    public uint EngeneersCount {
        get => _engeneersCount;
        set => _engeneersCount = value;
    }

    public Factory() : base() { }

    public Factory(string orgName, string director, string address, int budget, uint engeneersCount) :
        base(orgName, director, address, budget) {
        _engeneersCount = EngeneersCount;
    }

    public override void RandomInit() {
        base.RandomInit();
        var rand = new Random();
        EngeneersCount = (uint)rand.Next(999);
    }

    public override void Show() {
        base.Show();
        Console.WriteLine($"Количество инженеров: {EngeneersCount}");
    }
}