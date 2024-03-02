using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using System.Web;

/*
Постановка задачи 1.
1.	Создать динамический массив (одномерный, двумерный, рваный) из элементов заданного типа. При заполнении массива использовать 2 способа (ручной и с помощью ДСЧ).
2.	Массив вывести на печать.
3.	Выполнить операции с массивом, указанные в варианте, используя, по возможности, методы класса Array.
4.	Результаты обработки вывести на печать.

Постановка задачи 2.
1.	Ввести строку символов с клавиатуры. Строка состоит из слов, разделенных пробелами (пробелов может быть несколько) и знаками препинания (, ;:).  В строке может быть несколько предложений, в конце каждого предложения стоит знак препинания (.!?).
2.	Выполнить обработку строки в соответствии с вариантом.
3.	Результаты обработки вывести на печать.
 */

namespace Lab6 {
	internal class Program {
		static void Main() {
			Console.WriteLine("Практическая работа №6");
			int variantNumber = 549 % 25 - 1;   //номер варианта 23
			Console.WriteLine($"Номер варианта = {variantNumber}\n");
			MainMenu();
		}

		//Основное меню
		static void MainMenu() {
			bool exit = false;
			while (!exit) {
				Console.WriteLine();
				Console.WriteLine("1. Работа с символьным массивом");
				Console.WriteLine("2. Работа со строкой.");
				Console.WriteLine("0. Выход");
				Console.Write("> ");

				int input = InputDigit();
				switch (input) {
					default: Console.WriteLine("Введены некорректные данные"); break;
					case 1: MenuCharArray(); break;
					case 2: MenuStringArray(); break;
					case 0: exit = true; break;     //Назад в предыдущее меню
				}   //end of switch
			}       //end of while
		}           //end of MainMenu()

		static void MenuCharArray() {
			Console.Write("Введите количество строк массива от 0 до 30:\n>");
			int rows = SizeArray();     //строки
			Console.Write("Введите количество столбцов массива от 0 до 30:\n>");
			int cols = SizeArray();     //столбцы
			char [,] array  = new char [rows,cols];

			bool exit = false;
			while (!exit) {
				Console.WriteLine();
				Console.WriteLine("1. Заполнить массив автоматически. ");
				Console.WriteLine("2. Заполнить массив вручную.");
				Console.WriteLine("3. Удалить все строки, в которых нет цифр.");
				Console.WriteLine("4. Распечатать массив.");
				Console.WriteLine("0. Выход");
				Console.Write("> ");

				int input = InputDigit();
				switch (input) {
					default: Console.WriteLine("Введены некорректные данные"); break;
					case 1: RandomFilling(array); break;
					case 2: ManualFilling(array); break;
					case 3: RemoveRows(ref array); break;
					case 4: PrintArray(array); break;
					case 0: exit = true; break;     //Назад в предыдущее меню
				}   //end of switch
			}       //end of while
		}

		static void MenuStringArray() {
			bool exit = false;
			string stroke = "";
			while (!exit) {
				Console.WriteLine();
				Console.WriteLine("1. Ввести строку.");
				Console.WriteLine("2. Использовать готовую строку.");
				Console.WriteLine("3. Перевернуть все слова в предложении.");
				Console.WriteLine("4. Распечатать строку.");
				Console.WriteLine("0. Выход");
				Console.Write("> ");

				int input = InputDigit();
				switch (input) {
					default: Console.WriteLine("Введены некорректные данные"); break;
					case 1: stroke = InputString(); break;
					case 2: stroke = ReadyString(); break;
					case 3: ReverseSortWords(ref stroke); break;
					case 4: Console.WriteLine(stroke); break;
					case 0: exit = true; break;     //Назад в предыдущее меню
				}   //end of switch
			}       //end of while
		}

		static string InputString() {
			Console.WriteLine("\nВведите строку: ");
			return Console.ReadLine();
		}

		static string ReadyString() {
			return "As the Internet is developed and network applications grow, IPv4 addresses are running out," +
				" which constrains network development. Before IPv6 is widely used to replace IPv4 that has" +
				" been running on various network devices and bearing a majority of existing applications, " +
				"some IPv4-to-IPv6 transition techniques can be used to alleviate IPv4 address shortage.";
		}

		static void ReverseSortWords(ref string stroke) {
			string[] words = stroke.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			words = words.OrderByDescending(i => i).ToArray();      //сортировка по убыванию
			stroke = string.Join(" ", words);
		}

		static int InputDigit() {
			int result;
			while (!int.TryParse(Console.ReadLine(), out result)) {
				Console.Write("Ошибка! Должен быть тип int\nПовторите ввод\n> ");
			}
			return result;
		}

		static int SizeArray() {        //Границы массива ограничил 30, для удобства работы с ним и вывода на экран
			int sizeArray = InputDigit();
			while (sizeArray < 0 || sizeArray > 30) {
				Console.Write("Не корректная длина.Повторите ввод от 0 до 30\n> ");
				sizeArray = InputDigit();
			}
			return sizeArray;
		}

		static void RemoveRows(ref char[,] array) {
			int [] rowIndex = new int[0];       //массив, в котором хранятся индексы удаляемых строк
			for (int i = 0; i < array.GetLength(0); i++) {
				for (int k = 0; k < array.GetLength(1); k++) {
					if (Char.IsDigit(array[i, k])) {
						break;
					} else if (k == array.GetLength(1) - 1) {       //если дошли до последнего элемента в строке и он буква
						Array.Resize(ref rowIndex, rowIndex.Length + 1);    //передаём ссылку на массив и изменяем его размер
						rowIndex[rowIndex.Length - 1] = i;                  //добавляем индекс строки, которую нужно добавить в новый массив
					}
				}
			}

			char [,] newArray = new char [rowIndex.Length, array.GetLength(1)]; //создаём новый массив, в который копируются строки без цифр
			for (int i = 0; i < newArray.GetLength(0); i++) {
				for (int k = 0; k < newArray.GetLength(1); k++) {
					newArray[i, k] = array[rowIndex[i], k];
				}
			}

			array = newArray;
		}       //end of RemoveRows()

		//Заполнение массива случайными символами
		static void RandomFilling(char[,] array) {
			Random rand = new Random();
			for (int i = 0; i < array.GetLength(0); i++) {
				for (int k = 0; k < array.GetLength(1); k++) {
					if (rand.Next(0, 2) == 0) {
						array[i, k] = Convert.ToChar(rand.Next('a', 'z'));
					} else {
						array[i, k] = Convert.ToChar(rand.Next('1', '9'));
					}
				}
			}

			Console.Clear();
			Console.Write("Заполнение массива");
			for (int i = 0; i < 3; i++) {
				Thread.Sleep(200);
				Console.Write(".");
			}
			Thread.Sleep(200);
			Console.WriteLine();
		}   //end of RandomFilling()

		//Ручное заполнение двумерного массива числами
		static void ManualFilling(char[,] array) {
			if (array.Length == 0) {
				Console.WriteLine("Введёный размер массива равен нулю");
				return;
			}
			for (int i = 0; i < array.GetLength(0); i++) {
				for (int k = 0; k < array.GetLength(1); k++) {
					try {
						Console.Write("> ");
						array[i, k] = Convert.ToChar(Console.ReadLine());
					} catch (System.FormatException) {
						Console.WriteLine("Ошибка! Нужно ввести один символ");
					}
				}
			}
		}       //end of ManualFilling()

		//Печать двумерного массива
		static void PrintArray(char[,] array) {
			Console.WriteLine("\nЭлементы массива:");
			for (int i = 0; i < array.GetLength(0); i++) {
				for (int k = 0; k < array.GetLength(1); k++) {
					Console.Write(array[i, k] + "  ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}       //end of PrintArray()

	}       //end of class Program
}       //end of namespace
