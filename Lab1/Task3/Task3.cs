using System;

namespace Task3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Задание 3");
            int variantNumber = 549 % 25 - 1; //номер варианта 23
            Console.WriteLine($"Номер варианта = {variantNumber}\n");
            CalcFloat();
            CalcDouble();
        }

        /// <summary>
        /// Вычисление выражение с типом данных float
        /// </summary>
        static void CalcFloat()
        {
            const float a = 1000f;
            const float b = 0.0001f;
            //Функция Math.Pow() возвращает значение типа double, поэтому используется явное преобразование типа,
            //так как автоматически преобразовать невозможно(Compiler Error CS0266)
            float numerator = (float)Math.Pow(a - b, 3) - ((float)Math.Pow(a, 3) - 3 * (float)Math.Pow(a, 2) * b);
            float denominator = 3 * a * (float)Math.Pow(b, 2) - (float)Math.Pow(b, 3);
            float result = numerator / denominator;
            Console.WriteLine("Результат вычисления выражение с типом данных float: " + result);
        }

        /// <summary>
        /// Вычисление выражение с типом данных double
        /// </summary>
        static void CalcDouble()
        {
            const double a = 1000;
            const double b = 0.0001;
            double numerator = Math.Pow(a - b, 3) - (Math.Pow(a, 3) - 3 * Math.Pow(a, 2) * b); // числитель
            double denominator = 3 * a * Math.Pow(b, 2) - Math.Pow(b, 3); //знаменатель
            double result = numerator / denominator;
            Console.WriteLine("Результат вычисления выражение с типом данных double: " + result);
        }
    }
}