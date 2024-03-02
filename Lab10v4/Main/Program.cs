using System;
using System.Threading;
using ClassLibraryLab10;

namespace Main
{
    class Program
    {
        static void Main()
        {
            const int variantNumber = 549 % 16 - 1; //номер варианта 4
            Console.WriteLine($"Номер варианта = {variantNumber}\n");
            // Task1();
            //Task2();
            Task3();
        }


        private static void Task1()
        {
            Console.WriteLine("             Задание номер 1             \n" +
                              "Написать демонстрационную программу, в которой создаются объекты различных\n" +
                              "классов и помещаются в массив, после чего массив просматривается.\n");
            var org = new Organisation();
            var org1 = new Organisation();
            var fact = new Factory();
            var fact1 = new Factory();
            var ship = new Shipyard();
            var ship1 = new Shipyard();
            var insur = new InsuranceCompany();
            var insur1 = new InsuranceCompany();
            var lib = new Library();
            var lib1 = new Library();

            Organisation[] arr = { org, org1, fact, fact1, ship, ship1, insur, insur1, lib, lib1 };
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("=====================================\n");
                }

                arr[i].RandomInit();
                Thread.Sleep(510);
                Console.WriteLine($"Класс: {arr[i].GetType().Name}");
                arr[i].Show();
                Console.WriteLine();
            }

            Console.WriteLine("=====================================");
            Console.WriteLine();
            Console.WriteLine("Выводим массив без использования виртуального метода:");
            PrintArrayNotOverride(arr);
        }

        private static void Task2()
        {
            Console.WriteLine("=====================================\n");
            Console.WriteLine("             Задание номер 2             \n" +
                              "Реализовать не менее трех запросов, соответствующих иерархии классов");
            var lengthRandom = 15; //размер массива, хранящий объекты класса
            Organisation[] arr = new Organisation[lengthRandom];
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
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

            Console.WriteLine();
            Console.WriteLine($"Суммарное количество книг в библиотеках {ShowBooksSum(arr)}");
            Console.WriteLine();
            Console.WriteLine($"Количество инженеров на предприятии НорНикель {EgineersNornikel(arr)}");
            Console.WriteLine();
            Console.WriteLine("Список судостроительных компаний, бюджет которых меньше 3000:");
            ShowOrgBudget(arr);
            Console.WriteLine("=====================================");
        }

        private static void Task3()
        {
            Console.WriteLine("             Задание номер 3             ");
            var lengthRandom = 10; //размер массива, хранящий объекты класса
            Organisation[] arr = new Organisation[lengthRandom];
            Random rand = new Random();
            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = (rand.Next(100) % 5)
                    switch
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

            Console.WriteLine("Часть 2: Реализовать сортировку элементов массива, используя " +
                              "стандартный интерфейс IComparable  и метод Sort класса Array.");
            Array.Sort(arr);
            Console.WriteLine("Отсортированный по имени массив: ");
            //PrintArray(arr);
            Console.WriteLine();
            Console.WriteLine("=====================================");
            Console.WriteLine("Часть 3. Реализовать сортировку и поиск элемента в массиве, используя стандартный " +
                              "интерфейс ICompare  и метод Sort класса Array.");
            Console.WriteLine("Отсортированный величине бюджета массив: ");
            Array.Sort(arr, new SortByBudget());
            PrintArray(arr);
            Console.WriteLine();
            Console.WriteLine("=====================================");
            Console.Write("Часть 4.\nВведите элемент, с указанным бюджетом:\n> ");
            var value = InputDigit();

            var index = BinarySearch(arr, 0, arr.Length - 1, value);
            if (index == -1)
            {
                Console.WriteLine("Элемент не найден");
            }
            else
            {
                Console.WriteLine("Искомый элемент:\n");
                Console.WriteLine($"Класс: {arr[index].GetType().Name}");
                Console.WriteLine(arr[index]);
            }
        } //end of Task3

        /// <summary>
        /// Проверка корректности ввода и конвертация строки в целое число int
        /// </summary>
        /// <returns>Возвращает целое число, конвертированное из строки</returns>
        static int InputDigit()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Ошибка! Должен быть тип int\nПовторите ввод\n> ");
            }

            return result;
        }

        /// <summary>
        /// Бинарый поиск элемента с указанным размером бюджета в массиве из объектов класса Organisation
        /// </summary>
        /// <param name="array">Передаваемый массив</param>
        /// <param name="start">Индекс начала массива, с которого нужно начать поиск</param>
        /// <param name="end">Индекс окончания массива</param>
        /// <param name="value">Искомое значение</param>
        /// <returns></returns>
        static int BinarySearch(Organisation[] array, int start, int end, int value)
        {
            while (true)
            {
                if (start > end)
                {
                    return -1;
                }

                var middle = (start + end) / 2; //средний индекс массива
                if (array[middle].Budget == value) //сравниваем значение элемента в середине массива с искомым
                {
                    return middle;
                }

                /* если значение в середине массива больше искомого, значит работаем с левой частью подмассива.
                 В противном случае работаем с правой частью.
                 */
                if (array[middle].Budget > value)
                {
                    end = middle - 1;
                    continue;
                }

                start = middle + 1;
            }
        }

        static void PrintArray(Organisation[] arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine($"Класс: {item.GetType().Name}");
                item.Show();
                Console.WriteLine();
            }
        }

        static void PrintArrayNotOverride(Organisation[] arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine($"Класс: {item.GetType().Name}");
                item.ShowNotOverride();
                Console.WriteLine();
            }
        }

        static IInit[] ManualInit(int arrLength)
        {
            IInit[] arr = new IInit[arrLength];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arrLength switch
                {
                    0 => new Organisation(),
                    1 => new Factory(),
                    2 => new Shipyard(),
                    3 => new Library(),
                    4 => new InsuranceCompany(),
                    5 => new Star(),
                    _ => new Organisation()
                };
            }

            return arr;
        }

        static IInit[] RandomInit(int arrLength)
        {
            IInit[] arr = new IInit[arrLength];
            Random rand = new Random();
            for (int i = 0; i < arrLength; i++)
            {
                var randSeed = rand.Next(100) % 6;
                arr[i] = randSeed switch
                {
                    0 => new Organisation(),
                    1 => new Factory(),
                    2 => new Shipyard(),
                    3 => new Library(),
                    4 => new InsuranceCompany(),
                    5 => new Star(),
                    _ => new Organisation()
                };
                arr[i].RandomInit();
                Console.WriteLine(arr[i]);
            }

            return arr;
        } // end of RandomObjectArray

        /// <summary>
        /// Метод, который выводит информацию об общем количестве книг в библиотеке.
        /// </summary>
        /// <param name="arr">Принимает аргументом созданный массив из объектов одной иерархии</param>
        /// <returns>Кол-во книг в библиотеках</returns>
        static ulong ShowBooksSum(Organisation[] arr)
        {
            ulong booksSum = 0;
            foreach (Organisation item in arr)
            {
                if (item is Library p)
                    booksSum += p.BooksTotalNum;
            }

            return booksSum;
        }

        /// <summary>
        /// Метод, выводящий информаци о количестве инженеров на фабрике с названием НорНикель
        /// </summary>
        /// <param name="arr">Принимает аргументом созданный массив из объектов одной иерархии</param>
        /// <returns>Кол-во инженеров на фабрике Норкинель</returns>
        static uint EgineersNornikel(Organisation[] arr)
        {
            uint engNum = 0;
            string factory = "НорНикель";
            foreach (Organisation item in arr)
            {
                if (item is not Factory p)
                    continue;
                if (string.CompareOrdinal(p.OrgName, factory) == 0)
                    engNum += p.EngeneersCount;
            }

            return engNum;
        } //end of EgineersNornikel

        /// <summary>
        /// Метод, выводящий информацию о всех организациях, бюджет которых меньше 3000.
        /// </summary>
        /// <param name="arr">Принимает аргументом созданный массив из объектов одной иерархии.</param>
        static void ShowOrgBudget(Organisation[] arr)
        {
            foreach (Organisation item in arr)
            {
                if (item is Shipyard p)
                {
                    if (p.Budget < 3000)
                    {
                        Console.WriteLine($"Название: {p.OrgName}\n" +
                                          $"Бюджет: {p.Budget} рублей\n");
                        Console.WriteLine();
                    }
                }
            }
        } //end of ShowOrgBudget
    } //end of class Program
}