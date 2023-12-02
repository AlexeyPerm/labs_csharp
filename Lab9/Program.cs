using System;
using System.Globalization;

namespace Lab9 {
    class Program {
        static void Main() {
            const int variantNumber = 549 % 15 - 1; //номер варианта 8
            Console.WriteLine($"Номер варианта = {variantNumber}\n");


            // var m1 = new Money(-100, 1);
            // Console.WriteLine("Переменная m1:");
            // Console.WriteLine($"Свойство Rubles: {m1.Rubles}");
            // Console.WriteLine($"Свойство Kopeks: {m1.Kopeks}");
            // Console.Write("Метод Print(): ");
            // m1.Print();
            //
            //
            // Console.WriteLine();
            //
            // var m2 = new Money(199, 23);
            // Console.WriteLine("Переменная m2:");
            // Console.WriteLine($"Свойство Rubles: {m2.Rubles}");
            // Console.WriteLine($"Свойство Kopeks: {m2.Kopeks}");
            // Console.Write("Метод Print(): ");
            // m2.Print();
            //
            // Console.WriteLine();
            //
            // var m3 = new Money(1875, 1215);
            // Console.WriteLine("Переменная m3:");
            // Console.WriteLine($"Свойство Rubles: {m3.Rubles}");
            // Console.WriteLine($"Свойство Kopeks: {m3.Kopeks}");
            // Console.Write("Метод Print(): ");
            // m3.Print();
            //
            // Console.WriteLine("\nВычисление с помощью метода класса:");
            // Console.Write("Разница между m3 и m2: ");
            // var m4 = m3.Minus(m2);
            // m4.Print();
            //
            // Console.WriteLine("\nВычисление с помощью статического метода класса:");
            // Console.Write("Разница между m3 и m2: ");
            // var m5 = Money.Minus(m3, m2);
            // m5.Print();
            // Console.WriteLine();
            //
            // Console.WriteLine("Количество созданных объектов класса Money: " + Money.CreatedObjectCount());
            //
            // Console.WriteLine();
            //
            // var m6 = new Money(423, 99);
            // m6++;
            // Console.Write("Унарный ++, добавляющий копейки: ");
            // m6.Print();
            //
            // Console.WriteLine();
            //
            // var m7 = new Money(213, 0);
            // m7--;
            // Console.Write("Унарный --, вычитающий копейки: ");
            // m7.Print();
            //
            // Console.WriteLine();
            //
            // int x = m2;
            // Console.WriteLine("Неявное приведение типа int: " + x);
            //
            // Console.WriteLine();
            //
            // double y = (double)m2;
            // Console.WriteLine("Неявное приведение типа double: " + y);
            //
            // Console.WriteLine();
            //
            // var m8 = new Money(9655, 23);
            // m8.Print();
            // m8 -= 224;
            // Console.Write("Правосторонняя операция вычитания: ");
            // m8.Print();
            //
            // Console.WriteLine();
            //
            // var m9 = new Money(1, 24);
            // m9.Print();
            // Console.Write("Левосторонняя операция вычитания: ");
            // m9 = 122 - m9;
            // m9.Print();
            //
            // Console.WriteLine();
            //
            // var m10 = new Money(29, 54);
            // var m11 = new Money(3, 56);
            // Console.Write("Вычитание объекта Money из другого объекта Money: ");
            // var m12 = m10 - m11;
            // m12.Print();

            var arr = new MoneyArray(8);
            arr.Print();
            //var arr1 = new MoneyArray(m2, m3, m11);
            //arr1.Print();

            Console.WriteLine("Max = ");
            arr.Max().Print();

        }
    }
}