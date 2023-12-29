namespace Main;

using LibraryLab10;

class Program
{
    static void Main()
    {
        const int variantNumber = 549 % 16 - 1; //номер варианта 4
        Console.WriteLine($"Номер варианта = {variantNumber}\n");

        var arrLength = 50; //размер массива, хранящий объекты класса
        Organisation[] arr = new Organisation[arrLength];
        RandomObjectArray(arrLength, arr); //наполняем массив случайно созданными объектами классов
        PrintArray(arr);
        Console.WriteLine("============= Задание номер 2 =============");
        Console.WriteLine();
        Console.WriteLine($"Суммарное количество книг в библиотеках {ShowBooksSum(arr)}");
        Console.WriteLine();
        Console.WriteLine($"Количество инженеров на предприятии НорНикель {EgineersNornikel(arr)}");
        Console.WriteLine();
        Console.WriteLine("Список cсудостроительных компаний, бюджет которых меньше 2000:");
        ShowOrgBudget(arr);
    } // end of Main

    private static void PrintArray(Organisation[] arr)
    {
        foreach (var item in arr)
        {
            Console.WriteLine($"Класс: {item.GetType().Name}");
            item.Show();
            Console.WriteLine();
        }
    }

    private static void RandomObjectArray(int arrLength, Organisation[] arr)
    {
        Random rand = new Random();
        for (int i = 0; i < arrLength; i++)
        {
            var randSeed = rand.Next(100) % 5;
            arr[i] = randSeed switch
            {
                0 => new Organisation(),
                1 => new Factory(),
                2 => new Shipyard(),
                3 => new Library(),
                4 => new InsuranceCompany(),
                _ => new Organisation()
            };
            arr[i].RandomInit();
        }
    } // end of RandomObjectArray

    static ulong ShowBooksSum(Organisation[] arr)
    {
        ulong booksSum = 0;
        foreach (Organisation item in arr)
        {
            if (item is Library p)
            {
                booksSum += p.BooksTotalNum;
            }
        }

        return booksSum;
    }

    static uint EgineersNornikel(Organisation[] arr)
    {
        uint engNum = 0;
        string factory = "НорНикель";
        foreach (Organisation item in arr)
        {
            if (item is not Factory p)
            {
                continue;
            }

            if (string.CompareOrdinal(p.OrgName, factory) == 0)
            {
                engNum += p.EngeneersCount;
            }
        }

        return engNum;
    } //end of EgineersNornikel

    static void ShowOrgBudget(Organisation[] arr)
    {
        foreach (Organisation item in arr)
        {
            if (item is Shipyard p)
            {
                if (p.Budget < 2000)
                {
                    p.Show();
                    Console.WriteLine();
                }
            }
        }
    } //end of ShowOrgBudget
} // end of class Program