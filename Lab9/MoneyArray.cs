using System;

namespace Lab9 {
	public class MoneyArray {
		// --------------------------- Поля ---------------------------- //

		private readonly Money[] _arr;
		private static readonly Random Rnd = new Random();

		// ------------------------- Свойства -------------------------- //

		public int Length => _arr.Length;

		// ------------------------ Конструкторы ------------------------ //

		public MoneyArray() {
			_arr = Array.Empty<Money>();
		}

		public MoneyArray(params Money[] list) {
			_arr = new Money[list.Length];
			for (var i = 0; i < list.Length; i++) {
				_arr[i] = list[i];
			}
		}

		public MoneyArray(int size, bool random = true) {
			_arr = new Money[size];
			if (random) {
				for (var i = 0; i < size; i++) {
					var m = new Money(Rnd.Next(0, 1000), Rnd.Next(0, 100));
					_arr[i] = m;
				}
			} else {
				for (var i = 0; i < size; i++) {
					Console.Write($"Элемент номер {i + 1}:\n> ");
					var m = new Money(Input(), Input());
					_arr[i] = m;
				}
			}
		}

		// --------------------------- Методы --------------------------- //

		public void Print() {
			foreach (var item in _arr) {
				item.Print();
			}
		}

		public Money this[int index] {
			get {
				if (index >= 0 && index < _arr.Length)
					return _arr[index];
				throw new ArgumentException();
			}
			set {
				if (index >= 0 && index < _arr.Length)
					_arr[index] = value;
				else
					throw new ArgumentException();
			}
		}

		public Money Max() {
			var tmp = _arr[0];
			foreach (var item in _arr) {
				if (tmp < item) {
					tmp = item;
				}
			}

			return tmp;
		}

		private static int Input() {
			int result;
			Console.WriteLine("Введите число: ");
			while (!int.TryParse(Console.ReadLine(), out result)) {
				Console.Write("Ошибка! Должен быть тип int\nПовторите ввод\n> ");
			}

			return result;
		}
	}
}