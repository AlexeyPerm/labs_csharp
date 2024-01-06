//18. Дана последовательность целых чисел, за которой следует 0. Найти среднее арифметическое этой последовательности.

using System;

namespace task2
{
    static class Program
    {
        static void Main()
        {
            Console.WriteLine("Задание 2");
            int variantNumber = 549 % 59 - 1; //номер варианта 17
            Console.WriteLine($"Номер варианта = {variantNumber}\n");

            int curDigit;
            int sum = 0;
            int countDigit = 0;
            Console.WriteLine("Введите числа последовательности. Признак окончания последовательности цифра 0.");
            do
            {
                Console.Write("> ");
                curDigit = ParseInt(Console.ReadLine());
                sum += curDigit;
                countDigit++;
            } while (curDigit != 0);

            double result = (double)sum / (countDigit - 1);
            Console.WriteLine($"Среднее арифметическое = {result}");
        }

        /// <summary>
        /// Проверка корректности ввода и конвертация строки в целое число int
        /// </summary>
        /// <param name="str">Передаваемая строка для конвертации в целое число</param>
        /// <returns>Возвращает целое число, конвертированное из строки</returns>
        static int ParseInt(string str)
        {
            bool isConversion = int.TryParse(str, out int result);
            while (!isConversion)
            {
                Console.WriteLine("Ошибка! Должен быть тип int\nПовторите ввод");
                str = Console.ReadLine();
                isConversion = int.TryParse(str, out result);
            }

            return result;
        }
    }
}