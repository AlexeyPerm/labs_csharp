namespace LibraryLab10
{
    public class Factory : Organisation
    {
        protected uint _engeneersCount;

        public uint EngeneersCount
        {
            get => _engeneersCount;
            set => _engeneersCount = value;
        }

        public Factory()
        {
            EngeneersCount = 0;
        }

        public Factory(string orgName, string director, int budget, uint engeneersCount) :
            base(orgName, director, budget)
        {
            EngeneersCount = engeneersCount;
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Введите количество инженеров в органзиции:\n> ");
            var error = false;
            while (!error)
            {
                try
                {
                    EngeneersCount = checked((uint)InputDigit());
                    error = true;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Количество инженеров должно быть больше 0");
                    Console.Write("Введите количество инженеров в органзиции:\n> ");
                }
            }
        }

        public override void RandomInit()
        {
            base.RandomInit();
            var rand = new Random();
            EngeneersCount = (uint)rand.Next(999);
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Количество инженеров: {EngeneersCount}");
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Factory)
                return false;
            var f = (Factory)obj;
            return OrgName == f.OrgName && Director == f.Director && Budget == f.Budget &&
                   EngeneersCount == f.EngeneersCount;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), _engeneersCount);
        }
    }
}