using System;

namespace task1
{
    static class Program
    {
        static void Main()
        {
            Console.WriteLine("Задание 1");
            int variantNumber = 549 % 59 - 1; //номер варианта 17
            Console.WriteLine($"Номер варианта = {variantNumber}\n");
            Console.Write("Введите количество элементов в последовательности\n> ");
            int digitCount = ParseInt(Console.ReadLine()); //количество вводимых чисел

            while (digitCount <= 0)
            {
                Console.WriteLine("Нужно ввести положительное число");
                Console.Write("Введите количество элементов в последовательности\n> ");
                digitCount = ParseInt(Console.ReadLine());
            }

            int positiveNumCount = 0; //счётчик положительных чисел
            int negativNumCount = 0; //счётчик отрицательных чисел
            Console.WriteLine("Введите числа для их сравнения:");
            for (int i = 0; i < digitCount; i++)
            {
                //curDigit вводимое число, которое сравнивается с нулём
                Console.Write("> ");
                int curDigit = ParseInt(Console.ReadLine());
                if (curDigit > 0)
                {
                    positiveNumCount++;
                }
                else if (curDigit < 0)
                {
                    negativNumCount++;
                }
            }

            if (positiveNumCount > negativNumCount)
            {
                Console.WriteLine("Положительных чисел больше, чем отрицательных");
            }
            else if (positiveNumCount < negativNumCount)
            {
                Console.WriteLine("Отрицательных чисел больше, чем положительных");
            }
            else if (positiveNumCount > 0 &&
                     positiveNumCount == negativNumCount) //Проверяем, что есть числа, отличные от нуля
            {
                Console.WriteLine("Одинаковое количество положительных и отрицательных чисел");
            }
            else
            {
                Console.WriteLine("Все числа равны нулю");
            }
        }

        /// <summary>
        /// Проверка корректности ввода и конвертация строки в целое число int
        /// </summary>
        /// <param name="str">Передаваемая строка для конвертации в целое число</param>
        /// <returns>Возвращает целое число, конвертированное из строки</returns>
        static int ParseInt(string str) //проверка корректности ввода и конвертация строки в число int
        {
            bool isConversion = int.TryParse(str, out int result);
            while (!isConversion)
            {
                Console.Write("Ошибка! Должен быть тип int\nПовторите ввод\n> ");
                str = Console.ReadLine()!;
                isConversion = int.TryParse(str, out result);
            }

            return result;
        }
    }
}