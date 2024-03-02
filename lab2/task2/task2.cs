//18. Дана последовательность целых чисел, за которой следует 0. Найти среднее арифметическое этой последовательности.

namespace task2
{
	internal class Program
	{

		static int ParseInt(string str)   //проверка корректности ввода и конвертация строки в число int
		{
			bool isConversion = int.TryParse(str, out int result);
			while (!isConversion)
			{
				Console.WriteLine("Ошибка! Должен быть тип int\nПовторите ввод");
				str = Console.ReadLine()!;
				isConversion = int.TryParse(str, out result);
			}
			return result;
		}

		static void Main()
		{
			Console.WriteLine("Задание 2");
			int variantNumber = 549 % 59 - 1;   //номер варианта 17
			Console.WriteLine($"Номер варианта = {variantNumber}\n");

			int curDigit;
			int sum = 0;
			int countDigit = 0;
			do
			{
				curDigit = ParseInt(Console.ReadLine()!);
				sum += curDigit;
				countDigit++;
			}
			while (curDigit != 0);
			double result = (double)sum / countDigit;
			Console.WriteLine($"Среднее арифметическое = {result}");
		}
	}
}