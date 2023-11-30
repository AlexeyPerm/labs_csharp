//Для задачи 3 вычислить значение выражения, используя различные вещественные типы данных (float и double).
//((a-b)^3 - (a^3 - 3a^2*b)) // (3ab^2 - b^3)


namespace Lab1_task3
{
	class Program
	{

		static void CalcFloat()     //вычисление выражение с типом данных float
		{
			float a = 1000;
			float b = 0.0001f;
			//Функция Math.Pow() возвращает значение типа double, поэтому используется явное преобразование типа,
			//так как автоматически преобразовать невозможно(Compiler Error CS0266)
			float numerator =  (float)Math.Pow((a - b), 3) - ((float) Math.Pow((a), 3) - 3 * (float)Math.Pow(a, 2) * b);     // числитель
			float denominator = 3 * a * (float) Math.Pow(b, 2) - (float) Math.Pow(b, 3);                                     //знаменатель
			float result = numerator / denominator;
			Console.WriteLine("Результат вычисления выражение с типом данных float: " + result);
		}

		static void CalcDouble()    //вычисление выражение с типом данных double
		{
			double a = 1000;
			double b = 0.0001f;
			double numerator =  Math.Pow((a - b), 3) - (Math.Pow((a), 3) - 3 * Math.Pow(a, 2) * b);     // числитель
			double denominator = 3 * a *  Math.Pow(b, 2) - Math.Pow(b, 3);                              //знаменатель
			double result = numerator / denominator;
			Console.WriteLine("Результат вычисления выражение с типом данных double: " + result);
		}

		static void Main()
		{
			Console.WriteLine("Задание 3");
			int variantNumber = 549 % 25 - 1;   //номер варианта 23
			Console.WriteLine($"Номер варианта = {variantNumber}\n");
			CalcFloat();
			CalcDouble();
		}
	}
}