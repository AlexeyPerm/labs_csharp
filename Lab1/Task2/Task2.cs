using System;

namespace Task2
{
    class Program
    {
        private static void Main()
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

        /// <summary>
        /// Проверка корректности ввода и конвертация строки в целое число int
        /// </summary>
        /// <param name="str">Передаваемая строка для конвертации в число</param>
        /// <returns>Возвращает целое число, конвертированное из строки</returns>
        private static int ParseToInt(string str) //
        {
            bool isParse = int.TryParse(str, out int result);
            while (!isParse)
            {
                Console.Write("Ошибка! Должен быть тип int\nПовторите ввод> ");
                str = Console.ReadLine();
                isParse = int.TryParse(str, out result);
            }

            return result;
        }
    }
}