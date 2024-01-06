using System;

namespace Lab9
{
    public class Money
    {
        // --------------------------- Поля ---------------------------- //

        private int _rubles;
        private int _kopeks;

        // ------------------------- Свойства -------------------------- //

        public int Rubles
        {
            get => _rubles;
            set
            {
                if (value < 0)
                    Console.WriteLine("Нельзя присвоить отрицательное значение в рублях. Будет присвоен 0");
                else
                    _rubles = value;
            }
        }

        public int Kopeks
        {
            get => _kopeks;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("\nНельзя присвоить отрицательное значение в копейках. Будет присвоен 0");
                    value = 0;
                }

                if (value > 99)
                {
                    _rubles += value / 100;
                    _kopeks = value % 100;
                }
                else
                    _kopeks = value;
            }
        }

        private static int ObjectCount { get; set; }

        // ------------------------ Конструкторы ------------------------ //

        public Money()
        {
            Rubles = 0;
            Kopeks = 0;
            ObjectCount++;
        }

        public Money(int rubles, int kopeks) : this()
        {
            Rubles = rubles;
            Kopeks = kopeks;
        }

        // ------------------------- Деструктор ------------------------- //
        
        public void Deconstruct()
        {
            --ObjectCount;
        }

        // --------------------------- Методы --------------------------- //
        /// <summary>
        /// Вычитание переменной типа Money
        /// </summary>
        /// <param name="right">Вычитаемое</param>
        /// <returns>Возвращает результат типа Money</returns>
        public Money Minus(Money right)
        {
            long lhsTotalKopeks = Rubles * 100 + Kopeks;
            long rhsTotalKopeks = right.Rubles * 100 + right.Kopeks;
            var tmp = new Money();
            if (lhsTotalKopeks >= rhsTotalKopeks)
            {
                var result = lhsTotalKopeks - rhsTotalKopeks;
                tmp.Rubles = (int)(result / 100);
                tmp.Kopeks = (int)(result % 100);
                return tmp;
            }

            Console.WriteLine("Разница отрицательно число. Обнуление результата.");
            return tmp;
        }

        public void Print()
        {
            Console.WriteLine($"Money = {Rubles} руб. {Kopeks} коп.");
        }

        /// <summary>
        /// Вычисляет разницу между двумя объектами класса Money
        /// </summary>
        /// <param name="left">Уменьшаемое</param>
        /// <param name="right">Вычитаемое</param>
        /// <returns>Разность объектов</returns>
        public static Money Minus(Money left, Money right)
        {
            long lhsTotalKopeks = left.Rubles * 100 + left.Kopeks;
            long rhsTotalKopeks = right.Rubles * 100 + right.Kopeks;
            var tmp = new Money();
            if (lhsTotalKopeks >= rhsTotalKopeks)
            {
                var result = lhsTotalKopeks - rhsTotalKopeks;
                tmp.Rubles = (int)result / 100;
                tmp.Kopeks = (int)result % 100;
                return tmp;
            }

            Console.WriteLine("Разница отрицательно число. Обнуление результата.");
            return tmp;
        }

        /// <summary>
        /// Возвращает количество созданных объектов Money
        /// </summary>
        public static int CreatedObjectCount()
        {
            return ObjectCount;
        }

        // ---------------------- Унарные операции ---------------------- //

        public static Money operator ++(Money m)
        {
            m.Kopeks++;
            return m;
        }

        public static Money operator --(Money m)
        {
            long tmp = m.Rubles * 100 + m.Kopeks; //общее количество копеек
            tmp--;
            m.Rubles = (int)tmp / 100;
            m.Kopeks = (int)tmp % 100;
            return m;
        }

        // ---------------------- Приведение типов ---------------------- //

        public static implicit operator int(Money m)
        {
            return m.Rubles;
        }

        public static explicit operator double(Money m)
        {
            return m.Kopeks * 0.01;
        }

        // ---------------------- Бинарные операции ---------------------- //

        public static Money operator -(Money m, int kop)
        {
            long totalKop = (m.Rubles * 100 + m.Kopeks) - kop;
            var tmp = new Money();
            if (totalKop <= 0)
                return tmp;
            tmp.Rubles = (int)totalKop / 100;
            tmp.Kopeks = (int)totalKop % 100;
            return tmp;
        }

        public static Money operator -(int kop, Money m)
        {
            long totalKop = kop - (m.Rubles * 100 + m.Kopeks);
            var tmp = new Money();
            if (totalKop <= 0)
                return tmp;
            tmp.Rubles = (int)totalKop / 100;
            tmp.Kopeks = (int)totalKop % 100;
            return tmp;
        }

        public static Money operator -(Money left, Money right)
        {
            long totalKop = (left.Rubles * 100 + left.Kopeks) - (right.Rubles * 100 + right.Kopeks);
            var tmp = new Money();
            if (totalKop <= 0)
                return tmp;
            tmp.Rubles = (int)totalKop / 100;
            tmp.Kopeks = (int)totalKop % 100;
            return tmp;
        }

        public static bool operator <(Money left, Money right) =>
            left.Rubles < right.Rubles || (left.Rubles == right.Rubles && left.Kopeks < right.Kopeks);

        public static bool operator >(Money left, Money right) =>
            left.Rubles > right.Rubles || (left.Rubles == right.Rubles && left.Kopeks > right.Kopeks);

        public override bool Equals(object obj)
        {
            if (obj is Money)
            {
                var m = (Money)obj;
                return Rubles == m.Rubles && Kopeks == m.Kopeks;
            }

            return false;
        }
    } //end of class Money;
} //end of namespase Lab9