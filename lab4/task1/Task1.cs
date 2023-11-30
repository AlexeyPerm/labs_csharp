namespace task1 {
	internal class Program {

		static void Main() {
			Console.WriteLine("Практическая работа №4");
			int variantNumber = 549 % 25 - 1;   //номер варианта 23
			Console.WriteLine($"Номер варианта = {variantNumber}\n");

			int sizeArray = InputSizeArray();
			int [] array  = new int [sizeArray];
			bool exit     = false;   //Используется для корректного выхода из программы, а именно из зацикленного switch
			Console.Clear();

			while (!exit) {
				Console.WriteLine();
				Console.WriteLine("1. Заполнить массив автоматически. ");
				Console.WriteLine("2. Заполнить массив вручную.");
				Console.WriteLine("3. Удалить все чётные элементы.");
				Console.WriteLine("4. Добавить n элементов, начиная с номера k.");
				Console.WriteLine("5. Сдвинуть циклически на M элементов вправо.");
				Console.WriteLine("6. Найти элемент в неотсортированном массиве.");
				Console.WriteLine("7. Найти элемент в отсортированном выбором массиве.");
				Console.WriteLine("9. Распечатать массив.");
				Console.WriteLine("0. Выход");
				Console.Write("> ");
				int input = ParseInt();

				switch (input) {
					case 1: {    //заполнение массива рандомными числа и его вывод
							RandomFilling(array, sizeArray);
							break;
						}
					case 2: {      //Ручное заполнение массива числами и его вывод
							ManualFilling(array, sizeArray);
							break;
						}
					case 3: {     //Удаление всех чётных элементов
							RemoveEvenElements(ref array, ref sizeArray);   //размер массива передаём по ссылке
							break;
						}
					case 4: {    //Добавление N элементов, начиная с K
							InputN_K(ref sizeArray, out int n, out int k);
							AddElementsInPosition(ref array, ref sizeArray, n, k);
							break;
						}
					case 5: {   //Сдвинуть циклически на M элементов вправо
							ShiftArray(ref array, sizeArray);
							break;
						}
					case 6: {   //Поиск элемента с заданным ключом в несортированном массиве 
							Console.Write("Найти элемент в неотсортированном массиве:\n> ");
							int searchElement = ParseInt();
							SearchInUnsortedArray(array, sizeArray, searchElement);
							break;
						}
					case 7: {   //Поиск элемента с заданным ключом в сортированном методов выбора массиве 
							Console.Write("Найти элемент в неотсортированном массиве:\n> ");
							int searchElement = ParseInt();
							SearchInSortedArray(array, sizeArray, searchElement);
							break;
						}
					case 9: {
							PrintArray(array);
							break;
						}
					case 0: {     //Выход
							Console.WriteLine("Выход...");
							exit = true;
							break;
						}
					default:
						Console.WriteLine("Введены некорректные данные");
						break;
				}   // end of switch
			}       // end of while

			//Ввод размера массива
			static int InputSizeArray() {
				Console.Write("Введите размер массива от 5 до 30\n> ");
				int sizeArray = ParseInt();
				while (sizeArray < 5 || sizeArray > 30) {
					Console.Write("Не корректная длина массива.Повторите ввод от 5 до 30\n> ");
					sizeArray = ParseInt();
				}
				return sizeArray;
			}

			//Ручное заполнение массива
			static void ManualFilling(int[] array, int size) {
				try {
					Console.WriteLine("\nВведите элементы массива:");
					for (int i = 0; i < size; i++) {
						Console.Write("> ");
						array[i] = ParseInt();
					}
				} catch (IndexOutOfRangeException) {
					Console.WriteLine("Ошибка! Выход за границы массива. Новые числа добавлены не будут");
				}
			}

			//Заполнение массива случайными числами
			static void RandomFilling(int[] array, int size) {
				//Используем хеш текущей даты/времени, для указания seed, чтобы генерировались случайные числа
				Random rand = new(DateTime.Now.GetHashCode());
				for (int i = 0; i < size; i++) {
					array[i] = rand.Next(0, 100);
				}
				Console.Write("Заполнение массива");
				for (int i = 0; i < 3; i++) {
					Thread.Sleep(200);
					Console.Write(".");
				}
				Thread.Sleep(200);
				Console.WriteLine();
			}

			//Вывод на экран массива
			static void PrintArray(int[] array) {
				Console.WriteLine("\nЭлементы массива:");
				foreach (var item in array) {
					Console.Write($"{item} ");
				}
				Console.WriteLine();
			}

			//Проверка корректности ввода и конвертация строки в число int
			static int ParseInt() {
				int result;
				while (!int.TryParse(Console.ReadLine()!, out result)) {
					Console.Write("Ошибка! Должен быть тип int\nПовторите ввод\n> ");
				}
				return result;
			}

			//Удаление чётных элеметнов. Передаётся ссылка на адрес массива, т.к. она будет модифицирована
			static void RemoveEvenElements(ref int[] array, ref int sizeArray) {
				/*	
				 *	Корявый способ удаления чётных элементов.
				 *	Сначала вычесляем кол-во notEvenCount нечётных элементов, затем создаём временный 
				 *	массив tempArray размерности evenCount. Затем опять прогоняем в цикле массив и 
				 *	значения нечётных элементов копируются в tempArray
				 */
				Console.Write("Удаляются все чётные элементы");
				for (int i = 0; i < 3; i++) {
					Thread.Sleep(200);
					Console.Write(".");
				}
				Thread.Sleep(200);
				Console.WriteLine();


				int notEvenCount =  0;
				foreach (int item in array) {
					if (item % 2 != 0) {
						notEvenCount++;
					}
				}

				int [] tempArray   = new int [notEvenCount];
				int indexTempArray = 0;

				foreach (int item in array) {
					if (item % 2 != 0) {
						tempArray[indexTempArray] = item;
						indexTempArray++;
					}
				}
				array     = tempArray;
				sizeArray = indexTempArray;
			}

			//Добавление в массив n-элементов, начиная с k. Передаётся ссылка на адрес массива, т.к. она будет модифицирована
			static void AddElementsInPosition(ref int[] array, ref int sizeArray, int n, int k) {
				int newSizeArray = sizeArray + n;
				//Временный массив tempArray, в котором хранятся элементы текущего массива и n новых элементов
				int [] tempArray = new int[newSizeArray];

				Console.WriteLine("Введите число: ");
				//Вставка n элементов после k
				for (int i = 0; i < n; i++) {
					Console.Write("> ");
					tempArray[i + k] = ParseInt();
				}

				/* Вставка всех элементов из массива array в tempArray
				 * Если элемент с индексом i >= k, тогда вставляем копируемый элемент на позицию i + n;
				 * n = 2, k = 3
				 * n1 = 333, n2 = 444;
				 * |  123  |  665  | 767  |  799  |  342  |  286 |  133  |
				 * |  [0]  |  [1]  | [2]  |  [3]  |  [4]  |  [5] |  [6]  |
				 *           
				 *	   
				 * |    123    |    665    |   767    |  333  |  444  |    799    |    342    |   286   |    133    |
				 * |  [i = 0]  |  [i = 1]  | [i = 2]  | ----- | ----- |  [i=3+n]  |  [i=4+n]  | [i=5+n] |  [i=6+n]  |
				 */
				for (int i = 0; i < sizeArray; i++) {
					if (i < k) {
						tempArray[i] = array[i];
					} else {
						tempArray[i + n] = array[i];
					}
				}
				array     = tempArray;
				sizeArray = newSizeArray;
			}

			static void InputN_K(ref int sizeArray, out int n, out int k) {
				Console.Write("Количество добавляемых элементов n:\n> ");
				n = ParseInt();
				do {
					Console.Write("Позиция k в массиве, с которой добавляются элементы:\n> ");
					k = ParseInt();
				} while (k >= sizeArray);
			}

			static void ShiftArray(ref int[] array, int sizeArray) {
				Console.Write("Число m для циклического сдвига массива вправо:\n> ");
				int m            = ParseInt();
				int [] tempArray = new int [sizeArray];

				for (int i = 0; i < sizeArray; i++) {
					tempArray[(i + m) % sizeArray] = array[i];  //Остаток от деления - это новый индекс элемента.
				}
				array = tempArray;
			}

			static void SearchInUnsortedArray(int[] array, int sizeArray, int searchElement) {
				for (int i = 0; i < sizeArray; i++) {
					if (searchElement == array[i]) {
						Console.WriteLine(
							$"\nИскомый элемент \"{searchElement}\" найден на позиции {i + 1}.\n" +
							$"Количество сравнений, необходимых для поиска нужного элемента: {i}");
						return;
					}
				}
				Console.WriteLine("\nИскомый элемент отсутствует в массиве");
			}

			static void SearchInSortedArray(int[] array, int sizeArray, int searchElement) {
				SortArray(array, sizeArray);    //сортировка массива выбором

				int leftIndex   = 0;
				int rightIndex  = sizeArray - 1;
				int iterCount   = 0;        //счётчик кол-ва сравнений. Необходим для выполнения задания
				int middleIndex;

				//Пополамим массив, если искомый элемент больше элемента, стоящего в середине массива,
				//значит пополамим правую часть массива, иначе левую. И так до тех пока, пока индекс левого
				//и правого элемента массива не будут равны. 
				do {
					middleIndex = (leftIndex + rightIndex) / 2;     //средний элемент
					if (array[middleIndex] < searchElement) {
						leftIndex  = middleIndex + 1;
					} else {
						rightIndex = middleIndex;
					}
					iterCount++;
				} while (leftIndex != rightIndex);

				if (array[leftIndex] == searchElement) {
					Console.WriteLine(
						$"\nИскомый элемент \"{searchElement}\" найден на позиции {leftIndex + 1}.\n" +
						$"Количество сравнений, необходимых для поиска нужного элемента: {iterCount}");
				} else {
					Console.WriteLine("\nИскомый элемент отсутствует в массиве");
				}
			}

			static void SortArray(int[] array, int sizeArray) {
				int minElement;
				int indexMinElement;
				//Проход по всему массиву
				for (int i = 0; i < sizeArray - 1; i++) {
					minElement = array[i];
					indexMinElement = i;
					//Поиск минимального элемента в массиве и присваивание его значения и индекса в переменные
					for (int j = i + 1; j < sizeArray; j++)
						if (array[j] < minElement) {
							minElement = array[j];
							indexMinElement = j;
						}
					//Формирование отсортированного массива после каждой итерации поиска минимального элемента и его индекса
					array[indexMinElement] = array[i];
					array[i] = minElement;
				}
			}
		}   //end of main
	}
}