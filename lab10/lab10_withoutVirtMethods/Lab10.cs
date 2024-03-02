using System;
using System.Threading;

namespace lab10_withoutVirtMethods {
    public class Lab10 {
        static void Main() {
            const int variantNumber = 549 % 16 - 1; //номер варианта 8
            Console.WriteLine($"Номер варианта = {variantNumber}\n");
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
                Thread.Sleep(550);
                Console.WriteLine($"Класс: {arr[i].GetType().Name}");
                arr[i].Show();
                Console.WriteLine();
            }

            Console.WriteLine("=====================================");
        }
    }
}