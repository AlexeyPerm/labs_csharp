using System;
using System.Linq;
using System.Threading;

/*
1.	Сформировать динамический одномерный массив, заполнить его случайными числами и вывести на печать.
2.	Выполнить указанное в варианте задание и вывести полученный массив на печать.
3.	Сформировать динамический двумерный массив, заполнить его случайными числами и вывести на печать.
4.	Выполнить указанное в варианте задание и вывести полученный массив на печать.
5.	Сформировать динамический двумерный массив, заполнить его случайными числами и вывести на печать.
6.	Выполнить указанное в варианте задание и вывести полученный массив на печать.
7.	При реализации функций необходимо продемонстрировать использование параметров разных типов и различные
способы организации функций (параметры по умолчанию, перегрузку функций, и .т.д.)


Удалить все элементы с четными индексами	
Добавить К столбцов, начиная со столбца с номером N	
Добавить строку с заданным номером

1)	Для организации взаимодействия с пользователем использовать текстовое меню.
2)	Предусмотреть 2 способа формирования массивов: вручную (ввод значений с клавиатуры) и с помощью датчика случайных чисел.
3)	Предусмотреть возникновение исключительных ситуаций при вводе символов вместо цифр числа.
4)	При удалении элементов (строк, столбцов) предусмотреть ошибочные ситуации, т. е. ситуации, в которых 
будет выполняться попытка удаления  элемента (строки, столбца) из пустого массива или количество удаляемых элементов
будет превышать количество имеющихся элементов (строк, столбцов). В этом случае должно быть выведено сообщение об ошибке. 
5)	При попытке вывода пустого массива должно выводиться сообщение о том, что массив пустой.
6)	Рекомендуется при отладке программы сначала полностью отладить выполнение одной задачи и только после этого переходить к следующей.

 */

namespace Lab5 {
	internal class Lab5 {
		static void Main() {
			Console.WriteLine("Практическая работа №5");
			int variantNumber = 549 % 50 - 1;   //номер варианта 23
			Console.WriteLine($"Номер варианта = {variantNumber}\n");

			MainMenu();
		}

		//Основное меню
		static void MainMenu() {
			bool exit = false;   //Используется для корректного выхода из программы, а именно из зацикленного switch
			while (!exit) {
				Console.WriteLine();
				Console.WriteLine("1. Работа с одномерным массивом. ");
				Console.WriteLine("2. Работа с двумерным массивом.");
				Console.WriteLine("3. Работа с зубчатым массивом.");
				Console.WriteLine("0. Выход");
				Console.Write("> ");

				int input = InputDigit();
				switch (input) {
					default: Console.WriteLine("Введены некорректные данные"); break;
					case 1: MenuSingleDimensionalArray(); break;    //Работа с одномерным массивом	
					case 2: MenuMultidimensionalArray(); break;     //Работа с двумерным массивом		   
					case 3: MenuJaggedArray(); break;               //Работа с зубчатым массивом
					case 0:                                         //Выход
						Console.WriteLine("Выход...");
						exit = true;
						break;
				}
			}       // end of while
		}           // end of MainMenu()

		//Меню одномерного массива
		static void MenuSingleDimensionalArray() {
			int sizeArray = SizeArray();
			int [] array  = new int [sizeArray];

			bool exit = false;
			while (!exit) {
				Console.WriteLine();
				Console.WriteLine("1. Заполнить массив автоматически. ");
				Console.WriteLine("2. Заполнить массив вручную.");
				Console.WriteLine("3. Удалить элементы с чётными индексами.");
				Console.WriteLine("4. Распечатать массив.");
				Console.WriteLine("0. Назад");
				Console.Write("> ");

				int input = InputDigit();
				switch (input) {
					default: Console.WriteLine("Введены некорректные данные"); break;
					case 1: RandomFilling(array); break;
					case 2: ManualFilling(array); break;
					case 3: RemoveEvenIndex(ref array); break;
					case 4: PrintArray(array); break;
					case 0: exit = true; break; //Назад в предыдущее меню
				}   //end of switch
			}       //end of while
		}           //end of MenuSingleDimensionalArray()

		//Меню двумерного массива
		static void MenuMultidimensionalArray() {
			int rows = SizeArray();     //строки
			int cols = SizeArray();     //столбцы
			int [,] array  = new int [rows,cols];

			bool exit = false;
			while (!exit) {
				Console.WriteLine();
				Console.WriteLine("1. Заполнить массив автоматически. ");
				Console.WriteLine("2. Заполнить массив вручную.");
				Console.WriteLine("3. Добавить К столбцов, начиная со столбца с номером N");
				Console.WriteLine("4. Распечатать массив.");
				Console.WriteLine("0. Назад");
				Console.Write("> ");

				int input = InputDigit();
				switch (input) {
					default: Console.WriteLine("Введены некорректные данные"); break;
					case 1: RandomFilling(array); break;
					case 2: ManualFilling(array); break;
					case 3: AddColumns(ref array, rows, cols); break;
					case 4: PrintArray(array); break;
					case 0: exit = true; break; //Назад в предыдущее меню
				}   //end of switch
			}       //end of while
		}           //end of MenuMultidimensionalArray()

		//Меню рваного массива
		static void MenuJaggedArray() {
			int [][] array = CreateJuggedArray();

			bool exit = false;
			while (!exit) {
				Console.WriteLine();
				Console.WriteLine("1. Заполнить массив автоматически. ");
				Console.WriteLine("2. Заполнить массив вручную.");
				Console.WriteLine("3. Добавить строку с заданным номером");
				Console.WriteLine("4. Распечатать массив.");
				Console.WriteLine("0. Назад");
				Console.Write("> ");

				int input = InputDigit();
				switch (input) {
					default: Console.WriteLine("Введены некорректные данные"); break;
					case 1: RandomFilling(array); break;
					case 2: ManualFilling(array); break;
					case 3: AddRows(ref array); break;
					case 4: PrintArray(array); break;
					case 0: exit = true; break; //Назад в предыдущее меню
				}   //end of switch
			}       //end of while
		}           //end of MenuJaggedArray()


		//Удаление элементов с чётными индаксами. Передаётся ссылка на адрес массива, т.к. эта ссылка будет модифицирована
		static void RemoveEvenIndex(ref int[] array) {
			int [] tempArray = new int [array.Length / 2];      //размер массива - это результат целочисленного деления

			try {
				for (int i = 1, k = 0; i < array.Length; i += 2, k++) {
					tempArray[k] = array[i];
				}
				array = tempArray;
			} catch (IndexOutOfRangeException) {
				Console.WriteLine("Ошибка! Выход за границы массива.");
			}
		}

		//Функция добавления К столбцов, начиная со столбца с номером N
		static void AddColumns(ref int[,] array, int rows, int cols) {
			Console.Write("Введите число k столбцов\n> ");
			int k;
			while (!int.TryParse(Console.ReadLine(), out k) || k <= 0) {   //количество столбцов для добавления
				Console.Write("Ошибка! Число должно быть положительным целым\nПовторите ввод\n> ");
			}

			int n;
			Console.Write("Введите число n, с которого необходимо добавлять столбцы\n> ");
			while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n > array.GetLength(1)) {   //столбец, с которого нужно добавить новые столбцы
				Console.Write($"Ошибка! Число должно быть положительным целым и не больше {array.GetLength(1)}\nПовторите ввод\n> ");
			}

			int [,] newArray = new int[rows, cols + k];

			for (int i = 0; i < rows; i++) {
				for (int j = 0; j < cols; j++) {
					if (j < n) {
						newArray[i, j] = array[i, j];
					} else {
						newArray[i, j + k] = array[i, j];
					}
				}
			}
			array = newArray;
		}

		//Функция добавления строки с заданным номером в рваный массив
		static void AddRows(ref int[][] array) {
			Console.Clear();
			Console.WriteLine($"Введите индекс строки для добавления (индекс должен быть строго меньше {array.Length})");
			//номер добавляемой строки
			int indexRow;
			while (!int.TryParse(Console.ReadLine(), out indexRow) | indexRow < 0 || indexRow >= array.Length) {
				Console.Write("Ошибка! Число должно быть положительным целым\nПовторите ввод\n> ");
			}

			int [][] newArray = new int[array.Length + 1][];
			newArray[indexRow] = new int[SizeArray()];
			for (int i = 0; i < array.Length; i++) {
				if (i < indexRow) {
					newArray[i] = array[i];
				} else {
					newArray[i + 1] = array[i];
				}
			}
			array = newArray;
		}

		//Проверка корректности ввода и конвертация строки в число int
		static int InputDigit() {
			int result;
			while (!int.TryParse(Console.ReadLine(), out result)) {
				Console.Write("Ошибка! Должен быть тип int\nПовторите ввод\n> ");
			}
			return result;
		}

		//Создание рваного массива
		static int[][] CreateJuggedArray() {
			int cols = SizeArray();     //столбцы в рваном массиве
			int [][] array  = new int [cols][];
			for (int i = 0; i < array.Length; i++) {
				Console.Write($"Введите размер строки массива {i}\n> ");
				array[i] = new int[SizeArray()];
			}
			return array;
		}

		//Задание размера массива
		static int SizeArray() {        //Границы массива ограничил 30, для удобства работы с ним и вывода на экран
			Console.Write("Введите размер массива от 0 до 30\n> ");
			int sizeArray = InputDigit();
			while (sizeArray < 0 || sizeArray > 30) {
				Console.Write("Не корректная длина массива.Повторите ввод от 0 до 30\n> ");
				sizeArray = InputDigit();
			}
			return sizeArray;
		}

		//Заполнение одномерного массива случайными числами
		static void RandomFilling(int[] array) {
			Random rand = new Random();
			for (int i = 0; i < array.Length; i++) {
				array[i] = rand.Next(100);
			}
			Console.Write("Заполнение массива");
			for (int i = 0; i < 3; i++) {
				Thread.Sleep(200);
				Console.Write(".");
			}
			Thread.Sleep(200);
			Console.WriteLine();
		}

		//Заполнение двумерного массива случайными числами
		static void RandomFilling(int[,] array) {
			Random rand = new Random();
			for (int i = 0; i < array.GetLength(0); i++) {
				for (int k = 0; k < array.GetLength(1); k++) {
					array[i, k] = rand.Next(100);
				}
			}

			Console.Write("Заполнение массива");
			for (int i = 0; i < 3; i++) {
				Thread.Sleep(200);
				Console.Write(".");
			}
			Thread.Sleep(200);
			Console.WriteLine();
		}

		//Заполнение рваного массива случайными числами
		static void RandomFilling(int[][] array) {
			Random rand = new Random();
			for (int i = 0; i < array.Length; i++) {
				for (int k = 0; k < array[i].Length; k++) {
					array[i][k] = rand.Next(100);
				}
			}

			Console.Write("Заполнение массива");
			for (int i = 0; i < 3; i++) {
				Thread.Sleep(200);
				Console.Write(".");
			}
			Thread.Sleep(200);
			Console.WriteLine();
		}

		//Ручное заполнение одномерного массива числами
		static void ManualFilling(int[] array) {
			if (array.Length == 0) {
				Console.WriteLine("Введёный размер массива равен нулю");
				return;
			}
			try {
				Console.WriteLine("\nВведите элементы массива:");
				for (int i = 0; i < array.Length; i++) {
					Console.Write("> ");
					array[i] = InputDigit();
				}
			} catch (IndexOutOfRangeException) {
				Console.WriteLine("Ошибка! Выход за границы массива. Новые числа добавлены не будут");
			}
		}

		//Ручное заполнение двумерного массива числами
		static void ManualFilling(int[,] array) {
			if (array.Length == 0) {
				Console.WriteLine("Введёный размер массива равен нулю");
				return;
			}
			try {
				Console.WriteLine("\nВведите элементы массива:");
				for (int i = 0; i < array.GetLength(0); i++) {
					for (int k = 0; k < array.GetLength(1); k++) {
						Console.Write("> ");
						array[i, k] = InputDigit();
					}
				}
			} catch (IndexOutOfRangeException) {
				Console.WriteLine("Ошибка! Выход за границы массива. Новые числа добавлены не будут");
			}
		}

		//Ручное заполнение рваного массива числами
		static void ManualFilling(int[][] array) {
			if (array.Length == 0) {
				Console.WriteLine("Введёный размер массива равен нулю");
				return;
			}
			try {
				Console.WriteLine("\nВведите элементы массива:");
				for (int i = 0; i < array.Length; i++) {
					for (int k = 0; k < array[i].Length; k++) {
						Console.Write("> ");
						array[i][k] = InputDigit();
					}
				}
			} catch (IndexOutOfRangeException) {
				Console.WriteLine("Ошибка! Выход за границы массива. Новые числа добавлены не будут");
			}
		}

		//Печать одномерного массива
		static void PrintArray(int[] array) {
			if (array.All(x => x == 0)) {      //если значения в массиве нулевые или его длина нулевая
				Console.WriteLine("Массив пустой");
				return;
			}

			Console.Clear();
			Console.WriteLine("\nЭлементы массива:");
			foreach (var item in array) {
				Console.Write($"{item} ");
			}
			Console.WriteLine();
		}

		//Печать двумерного массива
		static void PrintArray(int[,] array) {
			if (array.Rank == 0) {
				Console.WriteLine("Массив пустой");
				return;
			}
			foreach (var item in array) {
				if (item != 0) {
					break;
				} else {
					Console.WriteLine("Массив пустой");
					return;
				}
			}

			Console.Clear();
			Console.WriteLine("\nЭлементы массива:");
			for (int i = 0; i < array.GetLength(0); i++) {
				for (int k = 0; k < array.GetLength(1); k++) {
					Console.Write(array[i, k] + "\t");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}

		//Печать рваного массива
		static void PrintArray(int[][] array) {

			bool emptyArray = false; ;		//проверка на пустоту массива
			for (int i = 0; i < array.Length; i++) {
				if (!array[i].All(x => x == 0)) {        
					break;
				} else {
					emptyArray = true;
				}
			}
			if (emptyArray) {
				Console.WriteLine("Массив пустой");
				return;
			}

			Console.Clear();
			Console.WriteLine("\nЭлементы массива:");
			for (int i = 0; i < array.Length; i++) {
				foreach (var item in array[i]) {
					Console.Write($"{item} ");
				}
				Console.WriteLine();
			}
		}


	}   //end of class Lab5
}		//end of namespace Lab5