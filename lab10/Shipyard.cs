using System;

namespace Lab10;

public class Shipyard : Factory {
    private uint _builtShips;

    public uint BuiltShips {
        get => _builtShips;
        set => _builtShips = value;
    }

    public Shipyard(string orgName, string director, string address, int budget, uint engeneersCount, uint builtShips) :
        base(orgName, director, address, budget, engeneersCount) {
        BuiltShips = builtShips;
    }

    public Shipyard() : base() { }

    public override void RandomInit() {
        base.RandomInit();
        var rand = new Random();
        BuiltShips = (uint)rand.Next(100, 500);
    }

    public override void Show() {
        base.Show();
        Console.WriteLine($"Количество построеных судн: {BuiltShips}");
    }
}