using System;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Задание 1");
            int variantNumber = 549 % 25 - 1; //номер варианта 23
            Console.WriteLine($"Номер варианта = {variantNumber}\n");
            //Уравнение окружностей, указанных в задании x^2+y^2=5^2 и (x+5)^2+y^2=5^2
            Console.Write("Введите координаты точки x\n>");
            int x = ParseToInt(Console.ReadLine());
            Console.Write("Введите координаты точки y\n>");
            int y = ParseToInt(Console.ReadLine());
            Console.WriteLine((x * x + y * y <= 5 * 5) || Math.Pow((x + 5), 2) + y * y <= 5 * 5);
        }

        static int ParseToInt(string str) //проверка корректности ввода и конвертация строки в число int
        {
            bool isParse = int.TryParse(str, out int result);

            while (!isParse)
            {
                Console.Write("Ошибка! Должен быть тип int\nПовторите ввод> ");
                str = Console.ReadLine()!;
                isParse = int.TryParse(str, out result);
            }

            return result;
        }
    }
}