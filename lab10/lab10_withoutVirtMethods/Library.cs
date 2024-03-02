using System;

namespace lab10_withoutVirtMethods;

public class Library : Organisation {
    private uint _booksTotalNum;

    public uint BooksTotalNum {
        get => _booksTotalNum;
        private set => _booksTotalNum = value;
    }

    public Library() { }

    public Library(string orgName, string director, int budget, uint booksTotalNum) : base(orgName, director, budget) {
        BooksTotalNum = booksTotalNum;
    }

    public void Init() {
        base.Init();
        Console.Write("Введите количество книг в библиотеке:\n> ");
        var error = false;
        while (!error) {
            try {
                BooksTotalNum = checked((uint)InputDigit());
                error = true;
            }
            catch (OverflowException) {
                Console.WriteLine("Количество книг должно быть не меньше 0");
                Console.Write("Введите количество книг в библиотеке:\n> ");
            }
        }
    }

    public void RandomInit() {
        base.RandomInit();
        var rand = new Random();
        BooksTotalNum = (uint)rand.Next(int.MaxValue);
    }

    public bool Equals(object obj) {
        if (obj is not Library)
            return false;
        var f = (Library)obj;
        return OrgName == f.OrgName && Director == f.Director && Budget == f.Budget &&
               BooksTotalNum == f.BooksTotalNum;
    }

    public void Show() {
        base.Show();
        Console.WriteLine($"Количество книг: {BooksTotalNum}");
    }
}