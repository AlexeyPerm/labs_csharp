namespace LibraryLab10;

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

    public override void Init() {
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

    public override void RandomInit() {
        base.RandomInit();
        var rand = new Random();
        BooksTotalNum = (uint)rand.Next(int.MaxValue);
    }

    public override bool Equals(object? obj) {
        if (obj is not Library library)
            return false;
        return OrgName == library.OrgName && Director == library.Director && Budget == library.Budget &&
               BooksTotalNum == library.BooksTotalNum;
    }


    public override int GetHashCode() {
        return HashCode.Combine(base.GetHashCode(), _booksTotalNum);
    }

    public override void Show() {
        base.Show();
        Console.WriteLine($"Количество книг: {BooksTotalNum}");
    }
}