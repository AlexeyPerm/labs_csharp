using System;

namespace Lab9
{
    class Program
    {
        static void Main()
        {
            const int variantNumber = 549 % 15 - 1; //номер варианта 8
            Console.WriteLine($"Номер варианта = {variantNumber}\n");

            //Part1();
            //Part2();

            Part3();
        }

        private static void Part3()
        {
            Console.WriteLine("Создаём массив с 10 элементами и заполняем его автоматически");
            var arr = new MoneyArray(10);
            arr.Print();
            Console.Write("\nМаксимальный элемент в массиве:\n");
            arr.Max().Print();
            Console.WriteLine("\n==========================================");

            Console.WriteLine("Создаём массив с 3 элементами и заполняем его вручную");
            var arrManual = new MoneyArray(3, false);
            Console.WriteLine("\nВведённый массив:");
            arrManual.Print();
            Console.WriteLine("Выводим на экран элемент с индексом 0:");
            arrManual[0].Print();
            Console.WriteLine();
            Console.WriteLine("Попытка получить доступ к элементу с индексом 8." +
                              "Получаем исключение ArgumentException():");
            arrManual[8].Print();
        }   //end of Part3()

        private static void Part2()
        {
            Console.WriteLine();
            var m2 = new Money(423, 99);
            m2.Print();
            m2++;
            Console.Write("Унарный ++, добавляющий копейки: ");
            m2.Print();

            Console.WriteLine("\n==========================================");

            var m3 = new Money(213, 0);
            m3.Print();
            m3--;
            Console.Write("Унарный --, вычитающий копейки: ");
            m3.Print();

            Console.WriteLine("\n==========================================");
            var m1 = new Money(199, 23);
            m1.Print();
            int x = m1;
            Console.WriteLine("Неявное приведение типа int: " + x);

            Console.WriteLine("\n==========================================");

            double y = (double)m1;
            Console.WriteLine("Неявное приведение типа double: " + y);

            Console.WriteLine("\n==========================================");

            var m4 = new Money(1, 23);
            m4.Print();
            m4 = 10000 - m4;
            Console.Write("Правосторонняя операция вычитания 10000 - 1,23: ");
            m4.Print();

            Console.WriteLine("\n==========================================");

            var m5 = new Money(1, 24);
            m5.Print();
            Console.Write("Левосторонняя операция вычитания 1,22 - 1,24: ");
            m5 = 122 - m5;
            m5.Print();

            Console.WriteLine("\n==========================================");

            var m6 = new Money(29, 54);
            var m7 = new Money(3, 56);
            m6.Print();
            m7.Print();
            Console.Write("Вычитание объекта Money из другого объекта Money 29,54 - 3,36: ");
            var m8 = m6 - m7;
            m8.Print();
            Console.WriteLine("\n==========================================");
            Console.Write("Вычитание объекта Money из другого объекта Money 3,36 - 29,54. " +
                          "Обнуление результата:\n");
            var m9 = m7 - m6;
            m9.Print();
        } //end of Part2()

        private static void Part1()
        {
            Console.WriteLine("\n==========================================");
            Console.WriteLine("Переменная m0 c параметрами по умолчанию:");
            var m0 = new Money();
            m0.Print();

            Console.WriteLine("\n==========================================");

            var m1 = new Money(-100, 1);
            Console.WriteLine("Переменная m1 указанным отрицательным значением поля rubles:");
            Console.WriteLine($"Свойство Rubles: {m1.Rubles}");
            Console.WriteLine($"Свойство Kopeks: {m1.Kopeks}");
            Console.Write("Метод Print(): ");
            m1.Print();

            Console.WriteLine("\n==========================================");

            Console.WriteLine();
            var m2 = new Money(199, 23);
            Console.WriteLine("Переменная m2:");
            Console.WriteLine($"Свойство Rubles: {m2.Rubles}");
            Console.WriteLine($"Свойство Kopeks: {m2.Kopeks}");
            Console.Write("Метод Print(): ");
            m2.Print();
            Console.WriteLine();

            var m3 = new Money(1875, 1215);
            Console.WriteLine("Переменная m3:");
            Console.WriteLine($"Свойство Rubles: {m3.Rubles}");
            Console.WriteLine($"Свойство Kopeks: {m3.Kopeks}");
            Console.Write("Метод Print(): ");
            m3.Print();

            Console.WriteLine("\n==========================================");

            Console.WriteLine("\nВычисление с помощью метода класса:");
            Console.Write("Разница между m3 и m2: ");
            var m4 = m3.Minus(m2);
            m4.Print();

            Console.WriteLine("\n==========================================");

            Console.WriteLine("\nВычисление с помощью статического метода класса:");
            Console.Write("Разница между m3 и m2: ");
            var m5 = Money.Minus(m3, m2);
            m5.Print();
            Console.WriteLine();

            Console.WriteLine("Количество созданных объектов класса Money: " + Money.CreatedObjectCount());
        } //end of Part1()
    }
}