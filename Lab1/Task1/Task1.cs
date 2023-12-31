using System;
using System.Globalization;

//используется для указания формата разделителя чисел с плавающей точкой

namespace Task1
{
    static class Program
    {
        static void Main()
        {
            Console.WriteLine("Задание 1");
            int variantNumber = 549 % 25 - 1; //номер варианта 23
            Console.WriteLine($"Номер варианта = {variantNumber}\n");
            Task1();
        }


        static int ParseInt(string str) //проверка корректности ввода и конвертация строки в число int
        {
            bool isConversion = int.TryParse(str, out int result);
            while (!isConversion)
            {
                Console.Write("Ошибка! Должен быть тип int\nПовторите ввод> ");
                str = Console.ReadLine()!;
                isConversion = int.TryParse(str, out result);
            }

            return result;
        }

        static double ParseDouble(string str) //проверка корректности ввода и конвертация строки в число double
        {
            NumberFormatInfo numFormatInfo = new() //указываем формат разделителя
            {
                NumberDecimalSeparator = ".",
            };

            bool isConversion = double.TryParse(str, out double result);
            while (!isConversion)
            {
                Console.Write("Ошибка! Должен быть тип double\nПовторите ввод> ");
                str = Console.ReadLine()!;
                isConversion = double.TryParse(str, out result);
            }

            return result;
        }

        static void Task1()
        {
            //Первое задание
            Console.WriteLine("Задание 1");
            Console.Write("Введите m> ");

            int m1 = ParseInt(Console.ReadLine());
            Console.Write("Введите n> ");
            int n1 = ParseInt(Console.ReadLine());
            int result1 = --m1 - n1++;
            Console.WriteLine($"m={m1} n={n1}  --m-n++ = {result1}\n");

            //Второе задание
            Console.Write("Введите m> ");
            int m2 = ParseInt(Console.ReadLine());
            Console.Write("Введите n> ");
            int n2 = ParseInt(Console.ReadLine());
            bool result2 = m2 * m2 < n2++;
            Console.WriteLine($"m={m2} n={n2}  m*m < n++ = {result2}\n");

            //Третье задание
            Console.Write("Введите m> ");
            int m3 = ParseInt(Console.ReadLine());
            Console.Write("Введите n> ");
            int n3 = ParseInt(Console.ReadLine());
            bool result3 = n3-- > ++m3;
            Console.WriteLine($"m={m3} n={n3}  n-->++m = {result3}\n");

            //Четвёртое задание
            Console.Write("Для решения уравнения 1 + (1/x) + (1/(x*x)) введите значение x (x != 0):\n>");
            double x = ParseDouble(Console.ReadLine());
            while (x == 0)
            {
                Console.Write("Ошибка! x не должен равняться нулю. Повторите ввод\n>");
                x = ParseDouble(Console.ReadLine());
            }

            double y = 1 + (1 / x) + (1 / (x * x));
            Console.WriteLine($"Решение уравнение = {y}");
        }
    }
}