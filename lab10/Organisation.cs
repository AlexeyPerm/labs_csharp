using System;

namespace Lab10;

public class Organisation {
    protected string _orgName;
    protected string _director;
    protected string _address;
    protected int _budget;

    public Organisation(string orgName, string director, string address, int budget) {
        _orgName = orgName;
        _director = director;
        _address = address;
        _budget = budget;
    }

    public Organisation() { }

    public virtual void RandomInit() {
        string[] name = {
            "Михаил", "Максим", "Макар", "Мартын", "Матвей", "Марк", "Назар", "Никита", "Олег", "Петр", "Павел", "Роман"
        };
        string[] surname = {
            "Анисимов", "Анненков", "Басурин", "Будницкий", "Варламов", "Гагарин", "Далматов", "Евменьев",
            "Екатеринчев", "Золотухин", "Карабанов", "Котов"
        };

        string[] orgName = {
            "Хмели-Сунели", "Шестёрочка", "Apple", "HP", "ASUS", "РосАтом", "Эр-Телеком", "ГРЧЦ", "РЖД", "Нефтехимпром",
            "Лукойл"
        };

        string[] address = {
            "Пермь", "Москва", "Барнаул", "Киров", "Саратов", "Махачкала", "Архангельск", "Якутск", "Иркутск",
            "Владивосток", "Салехард"
        };
        var rand = new Random();
        OrgName = orgName[rand.Next(orgName.Length)];
        Director = surname[rand.Next(surname.Length)] + " " + name[rand.Next(name.Length)];
        Address = address[rand.Next(address.Length)];
        Budget = rand.Next(99999, int.MaxValue);
    }

    public string OrgName {
        get => _orgName;
        set => _orgName = value;
    }

    public string Director {
        get => _director;
        set => _director = value;
    }

    public string Address {
        get => _address;
        set => _address = value;
    }

    public int Budget {
        get => _budget;
        set => _budget = value;
    }

    public virtual void Show() {
        Console.WriteLine($"Название: {OrgName}\n" +
                          $"Директор: {Director}\n" +
                          $"Адрес: {Address}\n" +
                          $"Оборот: {Budget} рублей");
    }
}