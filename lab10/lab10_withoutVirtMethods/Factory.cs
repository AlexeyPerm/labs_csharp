using System;

namespace lab10_withoutVirtMethods;

public class Factory : Organisation {
    protected uint _engeneersCount;

    public uint EngeneersCount {
        get => _engeneersCount;
        private set => _engeneersCount = value;
    }

    public Factory() { }

    public Factory(string orgName, string director, int budget, uint engeneersCount) :
        base(orgName, director, budget) {
        EngeneersCount = engeneersCount;
    }

    public void Init() {
        base.Init();
        Console.Write("Введите количество инженеров в органзиции:\n> ");
        var error = false;
        while (!error) {
            try {
                EngeneersCount = checked((uint)InputDigit());
                error = true;
            }
            catch (OverflowException) {
                Console.WriteLine("Количество инженеров должно быть больше 0");
                Console.Write("Введите количество инженеров в органзиции:\n> ");
            }
        }
    }

    public void RandomInit() {
        base.RandomInit();
        var rand = new Random();
        EngeneersCount = (uint)rand.Next(999);
    }

    public void Show() {
        base.Show();
        Console.WriteLine($"Количество инженеров: {EngeneersCount}");
    }

    public bool Equals(object obj) {
        if (obj is not Factory)
            return false;
        var f = (Factory)obj;
        return OrgName == f.OrgName && Director == f.Director && Budget == f.Budget &&
               EngeneersCount == f.EngeneersCount;
    }
}