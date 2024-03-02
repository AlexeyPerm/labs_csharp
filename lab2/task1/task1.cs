//17. Дана последовательность из n целых чисел. Определить, каких чисел в этой последовательности больше:
//положительных или отрицательных.

namespace task1
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

			Console.WriteLine("Задание 1");
			int variantNumber = 549 % 59 - 1;   //номер варианта 17
			Console.WriteLine($"Номер варианта = {variantNumber}\n");

			int digitCount = 10;		//количество вводимых чисел
			int gtZero = 0;
			int ltZero = 0;
			for (int i = 0, curDigit; i < digitCount; i++)  //curDigit вводимое число, которое сравнивается с нулём
			{
				curDigit = ParseInt(Console.ReadLine()!);
				if (curDigit == 0)
				{
					continue;
				}
				else if (curDigit > 0)
				{
					gtZero++;
				}
				else
				{
					ltZero++;
				}
			}

			if (gtZero > ltZero)
			{
				Console.WriteLine("Положительных чисел больше, чем отрицательных");
			}
			else if (gtZero < ltZero)
			{
				Console.WriteLine("Отрицательных чисел больше, чем положительных");
			}
			else if (gtZero > 0 && gtZero == ltZero) //Проверяем, что есть числа, отличные от нуля
			{
				Console.WriteLine("Одинаковое количество положительных и отрицательных чисел");
			}
			else
			{
				Console.WriteLine("Все введёные числа равны нулю");
			}
		}
	}
}