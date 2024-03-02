
namespace task1
{
	internal class Program
	{
		static void Main()
		{
			Console.WriteLine("Практическая работа №1");
			int variantNumber = 549 % 30 - 1;   //номер варианта 8
			Console.WriteLine($"Номер варианта = {variantNumber}\n");

			int k = 10; //из условия
			int n = 40; //количество итерация для вычисления 
						//диапазон изменения аргумента x. float - для понижения точности, если сделать double, то точного значения 
						//аргумента x = 0.8 достигнуто не будет.
			float a= 0.1f, b = 0.8f;
			double step = ((b - a) / k); //step = 0,07. шаг аргумента x из условия.
			double eps = 0.0001;
			double y, x;

			//x = a, так как первый шаг при a = 0.1. Далее x изменяется c шагом 0,07
			for (x = a; x <= b; x += step)
			{
				//Высчитываем точное значение функции
				y = (x * Math.Sin(Math.PI / 4)) / (1 - 2 * x * Math.Cos(Math.PI / 4) + Math.Pow(x, 2));

				//Высчитываем значение SN
				double sn = 0;
				for (int i = 1; i <= n; i++)
				{
					sn += Math.Pow(x, i) * Math.Sin(i * (Math.PI / 4));
				}

				//Вычисение выражения для указанной точности epsilon
				double tempValue = 0;
				double se = 0;
				int j = 1;  //переменная, заменяющая n в вычисляемом выражении 
				do
				{
					tempValue = Math.Pow(x, j) * Math.Sin(j * (Math.PI / 4));
					se += tempValue;
					j++;
				} while (tempValue > eps);


				string displayX = String.Format("{0:f2}", x);   //форматируем строку. Видим 2 цифры после запятой
				string displayY = String.Format("{0:f15}", y);   //форматируем строку. Видим 6 цифр  после запятой
				string displaySN = String.Format("{0:f15}", sn);
				string displaySE = String.Format("{0:f15}", se);
				Console.WriteLine(
					  $"X = {displayX}   "
					+ $"SN = {displaySN}   "
					+ $"SE = {displaySE}   "
					+ $"Y = {displayY}");
			}
		}
	}
}