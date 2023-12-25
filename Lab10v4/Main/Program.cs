using System;
using System.Threading;
using ClassLibraryLab10;

namespace Main {
    class Program {
        static void Main() {
            const int variantNumber = 549 % 16 - 1; //номер варианта 4
            Console.WriteLine($"Номер варианта = {variantNumber}\n");

            Task1();
            Task2();
        }


        private static void Task1() {
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
            for (int i = 0; i < arr.Length; i++) {
                if (i % 2 == 0) {
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

        private static void Task2() {
            Console.WriteLine("=====================================\n");
            Console.WriteLine("             Задание номер 2             \n" +
                              "Реализовать не менее трех запросов, соответствующих иерархии классов");
            var lengthRandom = 15; //размер массива, хранящий объекты класса
            Organisation[] arr = new Organisation[lengthRandom];
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++) {
                var randSeed = rand.Next(100) % 5;
                arr[i] = randSeed switch {
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

        private static void PrintArray(Organisation[] arr) {
            foreach (var item in arr) {
                Console.WriteLine($"Класс: {item.GetType().Name}");
                item.Show();
                Console.WriteLine();
            }
        }

        private static void PrintArrayNotOverride(Organisation[] arr) {
            foreach (var item in arr) {
                Console.WriteLine($"Класс: {item.GetType().Name}");
                item.ShowNotOverride();
                Console.WriteLine();
            }
        }

        private static IInit[] ManualInit(int arrLength) {
            IInit[] arr = new IInit[arrLength];
            for (int i = 0; i < arr.Length; i++) {
                arr[i] = arrLength switch {
                    0 => new Organisation(),
                    1 => new Factory(),
                    2 => new Shipyard(),
                    3 => new Library(),
                    4 => new InsuranceCompany(),
                    _ => new Organisation()
                };
            }

            return arr;
        }

        private static IInit[] RandomInit(int arrLength) {
            IInit[] arr = new IInit[arrLength];
            Random rand = new Random();
            for (int i = 0; i < arrLength; i++) {
                var randSeed = rand.Next(100) % 5;
                arr[i] = randSeed switch {
                    0 => new Organisation(),
                    1 => new Factory(),
                    2 => new Shipyard(),
                    3 => new Library(),
                    4 => new InsuranceCompany(),
                    _ => new Organisation()
                };
                arr[i].RandomInit();
                Console.WriteLine(arr[i]);
            }

            return arr;
        } // end of RandomObjectArray

        static ulong ShowBooksSum(Organisation[] arr) {
            ulong booksSum = 0;
            foreach (Organisation item in arr) {
                if (item is Library p) {
                    booksSum += p.BooksTotalNum;
                }
            }

            return booksSum;
        }

        static uint EgineersNornikel(Organisation[] arr) {
            uint engNum = 0;
            string factory = "НорНикель";
            foreach (Organisation item in arr) {
                if (item is not Factory p) {
                    continue;
                }

                if (string.CompareOrdinal(p.OrgName, factory) == 0) {
                    engNum += p.EngeneersCount;
                }
            }

            return engNum;
        } //end of EgineersNornikel

        static void ShowOrgBudget(Organisation[] arr) {
            foreach (Organisation item in arr) {
                if (item is Shipyard p) {
                    if (p.Budget < 3000) {
                        Console.WriteLine($"Название: {p.OrgName}\n" +
                                          $"Бюджет: {p.Budget} рублей\n");
                        Console.WriteLine();
                    }
                }
            }
        } //end of ShowOrgBudget
    }
}