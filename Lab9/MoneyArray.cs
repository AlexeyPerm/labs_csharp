using System;

namespace Lab9 {
    internal class MoneyArray {
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

        public MoneyArray(int size) {
            _arr = new Money[size];
            for (var i = 0; i < size; i++) {
                var m = new Money(Rnd.Next(0, 1000), Rnd.Next(0, 100));
                _arr[i] = m;
            }
        }

        public void Print() {
            foreach (var item in _arr) {
                item.Print();
            }
        }
    }
}