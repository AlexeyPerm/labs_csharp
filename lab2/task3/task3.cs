//Дано число k. Определить, является ли оно числом Фибоначчи.    

namespace ConsoleApp1
{
	internal class Program
	{

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

		static void Main()
		{
			Console.WriteLine("Задание 3");
			int variantNumber = 549 % 59 - 1;   //номер варианта 17
			Console.WriteLine($"Номер варианта = {variantNumber}\n");

			bool isFib = false;
			int fib1 = 0, fib2 = 1;
			int fibComputed = 0;    //вычисленное число Фибоначчи fib1 + fib2

			Console.Write("Введите число k\n> ");
			int k = ParseInt(Console.ReadLine()!);  //Число k из условия задачи.

			//Выполняем цикл до тех пор, пока вычесленное число не будет меньше или равно введённому
			while (fibComputed <= k)
			{
				if (fibComputed == k)
				{
					isFib = true;
					break;
				}
				fibComputed = fib1 + fib2;
				fib2 = fib1;
				fib1 = fibComputed;
			}

			if (isFib)
			{
				Console.WriteLine($"Число {k} является числом Фибоначчи");
			}
			else
			{
				Console.WriteLine($"Число {k} не является числом Фибоначчи");
			}
		}
	}
}