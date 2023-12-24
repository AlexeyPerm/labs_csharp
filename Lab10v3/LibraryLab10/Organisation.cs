namespace LibraryLab10;

public class Organisation {
    protected string _orgName;
    protected int _budget;

    public string OrgName {
        get => _orgName;
        set => _orgName = value;
    }

    public int Budget {
        get => _budget;
        set => _budget = value;
    }

    public Organisation() {
        OrgName = "EmptyName";
        Budget = 0;
    }

    public Organisation(string orgName, int budget) {
        OrgName = orgName;
        Budget = budget;
    }

    public virtual void Init() {
        Console.Write("Введите название организации:\n> ");
        OrgName = Console.ReadLine()!;

        Console.Write("Введите имя директора:\n> ");

        Console.Write("Введите объём бюджета органзиции:\n> ");
        Budget = InputDigit();
        while (Budget < 0) {
            Console.Write("Бюджет должен быть больше 0\n> ");
            Budget = InputDigit();
        }
    } //end of method Init

    public virtual void RandomInit() {
        string[] orgName = {
            "Хмели-Сунели", "Шестёрочка", "Apple", "HP", "ASUS", "РосАтом",
            "Эр-Телеком", "ГРЧЦ", "РЖД", "Нефтехимпром", "Лукойл", "МСБ", "Лента", "Русал", "НорНикель", "КГБ"
        };
        var rand = new Random();
        OrgName = orgName[rand.Next(orgName.Length)];
        Budget = rand.Next(99999, int.MaxValue);
    } //end of method RandomInit


    public virtual void Show() {
        Console.WriteLine($"Название: {OrgName}\n" +
                          $"Бюджет: {Budget} рублей");
    } //end of method Show

    public override bool Equals(object? obj) {
        if (obj is not Organisation organisation)
            return false;
        return OrgName == organisation.OrgName && Budget == organisation.Budget;
    }

    protected static int InputDigit() {
        int result;
        while (!int.TryParse(Console.ReadLine(), out result)) {
            Console.Write("Ошибка! Должен быть тип int\nПовторите ввод\n> ");
        }

        return result;
    }
}