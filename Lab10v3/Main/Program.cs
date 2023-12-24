namespace Main;

using LibraryLab10;

class Program {
    static void Main() {
        const int variantNumber = 549 % 16 - 1; //номер варианта 4
        Console.WriteLine($"Номер варианта = {variantNumber}\n");

        // var org = new Organisation();
        // var org1 = new Organisation();
        // var fact = new Factory();
        // var fact1 = new Factory();
        // var ship = new Shipyard();
        // var ship1 = new Shipyard();
        // var insur = new InsuranceCompany();
        // var insur1 = new InsuranceCompany();
        // var lib = new Library();
        // var lib1 = new Library();
        //
        //
        // Organisation[] arr = { org, org1, fact, fact1, ship, ship1, insur, insur1, lib, lib1 };
        // for (int i = 0; i < arr.Length; i++) {
        //     if (i % 2 == 0) {
        //         Console.WriteLine("=====================================\n");
        //     }
        //
        //     arr[i].RandomInit();
        //     Thread.Sleep(550);
        //     Console.WriteLine($"Класс: {arr[i].GetType().Name}");
        //     arr[i].Show();
        //     Console.WriteLine();
        // }
        // Console.WriteLine("=====================================");

        var arrLength = 50;
        Random rand = new Random();

        Organisation[] arr = new Organisation[arrLength];
        for (int i = 0; i < arrLength; i++) {
            var randSeed = rand.Next(100) % 5;

            switch (randSeed) {
                case 0:
                    arr[i] = new Organisation();
                    break;
                case 1:
                    arr[i] = new Factory();
                    break;
                case 2:
                    arr[i] = new Shipyard();
                    break;
                case 3:
                    arr[i] = new Library();
                    break;
                case 4:
                    arr[i] = new InsuranceCompany();
                    break;
                default:
                    arr[i] = new Organisation();
                    break;
            }

            arr[i].RandomInit();
        }

        for (int i = 0; i < arrLength; i++) {
            Console.WriteLine($"Класс: {arr[i].GetType().Name}");
            arr[i].Show();
            Console.WriteLine();
        }
    }
}