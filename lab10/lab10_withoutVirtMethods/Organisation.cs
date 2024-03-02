using System;

namespace lab10_withoutVirtMethods {
    public class Organisation {
        protected string _orgName;
        protected string _director;
        protected int _budget;

        public string OrgName {
            get => _orgName;
            private set => _orgName = value;
        }

        public string Director {
            get => _director;
            private set => _director = value;
        }

        public int Budget {
            get => _budget;
            private set => _budget = value;
        }

        public Organisation() { }

        public Organisation(string orgName, string director, int budget) {
            OrgName = orgName;
            Director = director;
            Budget = budget;
        }

        public void Init() {
            Console.Write("Введите название организации:\n> ");
            OrgName = Console.ReadLine();

            Console.Write("Введите имя директора:\n> ");
            Director = Console.ReadLine();

            Console.Write("Введите объём бюджета органзиции:\n> ");
            Budget = InputDigit();
            while (Budget < 0) {
                Console.Write("Бюджет должен быть больше 0\n> ");
                Budget = InputDigit();
            }
        } //end of method Init

        public void RandomInit() {
            string[] name = {
                "Михаил", "Максим", "Макар", "Мартын", "Матвей", "Марк",
                "Назар", "Никита", "Олег", "Петр", "Павел", "Роман"
            };
            string[] surname = {
                "Анисимов", "Анненков", "Басурин", "Будницкий", "Варламов", "Гагарин",
                "Евменьев", "Екатеринчев", "Золотухин", "Карабанов", "Котов", "Далматов",
            };
            string[] orgName = {
                "Хмели-Сунели", "Шестёрочка", "Apple", "HP", "ASUS", "РосАтом",
                "Эр-Телеком", "ГРЧЦ", "РЖД", "Нефтехимпром", "Лукойл"
            };
            var rand = new Random();
            OrgName = orgName[rand.Next(orgName.Length)];
            Director = surname[rand.Next(surname.Length)] + " " + name[rand.Next(name.Length)];
            Budget = rand.Next(99999, int.MaxValue);
        } //end of method RandomInit


        public void Show() {
            Console.WriteLine($"Название: {OrgName}\n" +
                              $"Директор: {Director}\n" +
                              $"Бюджет: {Budget} рублей");
        } //end of method Show

        public override bool Equals(object obj) {
            if (obj is not Organisation)
                return false;
            var o = (Organisation)obj;
            return OrgName == o.OrgName && Director == o.Director && Budget == o.Budget;
        } //end of method Equals

        protected static int InputDigit() {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result)) {
                Console.Write("Ошибка! Должен быть тип int\nПовторите ввод\n> ");
            }

            return result;
        } //end of static method InputDigit
    }
}