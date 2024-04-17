using ClassLibraryLab10;

namespace Lab12_3;

public class Htable
{
    /// <summary>
    /// Элемент хэш-таблицы, в котором хранится объект
    /// </summary>
    private class HashPoint
    {
        public int key;
        public Organisation Data;
        public HashPoint _next;

        public HashPoint(Organisation data)
        {
            Data = data;
            key = data.GetHashCode() + 777;
            _next = null;
        }


        public override string ToString()
        {
            return $"{key} + {Data}";
        }
    }


    public int Size = 10; //Размер хэш-таблицы
    private HashPoint[] _table; // Хэш-таблица

    /// <summary>
    /// Конструктор, создающий массив из элементов. 
    /// </summary>
    public Htable()
    {
        _table = new HashPoint[Size];
    }

    /// <summary>
    /// Добавление элемента в хэш-таблицу
    /// </summary>
    /// <param name="data">Элемент данных</param>
    public void Insert(Organisation data)
    {
        var point = new HashPoint(data);
        if (data == null) return;

        int index = Math.Abs(point.key) % Size;
        if (_table[index] == null)
        {
            _table[index] = point;
        }
        else
        {
            HashPoint current = _table[index];
            if (current == point) return;
            while (current._next != null)
            {
                if (current == point) return;
                current = current._next;
            }

            current._next = point;
        }
    }

    /// <summary>
    /// Вывод на экран всех элементов хэш-таблицы.
    /// </summary>
    public void Print()
    {
        for (var i = 0; i < Size; i++)
        {
            if (_table[i] == null) continue;
            //Временный элемент, с помощью которого двигаемся по таблице горизонтально. Без него произойдёт зануление
            //всех элементов в таблице из-за использования такой конструкции _table[i] = _table[i]._next;
            var temp = new HashPoint(_table[i].Data);
            while (temp != null)
            {
                temp.Data.Show();
                temp = temp._next;
                Console.WriteLine();
            }
        }
    }

    public bool FindElement(Organisation data)
    {
        var searchHashPoint = new HashPoint(data);
        int index = Math.Abs(searchHashPoint.key) % Size;

        //Без _table[index] может произойти сравнение числа с null, что вызовет исключение NullReferenceException
        if (_table[index] != null && searchHashPoint.key == _table[index].key)
        {
            return true;
        }

        while (_table[index] != null)
        {
            if (searchHashPoint.key == _table[index].key)
            {
                return true;
            }

            _table[index] = _table[index]._next;
        }

        return false;
    }

    /// <summary>
    /// Удалить элемент из хэш-таблицы.
    /// </summary>
    /// <param name="data">Удаляемый элемент</param>
    public void DeleteElement(Organisation data)
    {
        var hashPoint = new HashPoint(data);
        int index = Math.Abs(hashPoint.key) % Size;
        if (_table[index] == null)
        {
            Console.WriteLine("Элемент не найден.");
            return;
        }

        if (_table[index] != null && hashPoint.key == _table[index].key)
        {
            Console.WriteLine("Элемент найден. Произведено удаление.");
            _table[index] = _table[index]._next;
            return;
        }

        while (hashPoint != null && hashPoint.key == _table[index].key)
        {
            hashPoint = hashPoint._next;
            Console.WriteLine("Элемент найден. Произведено удаление.");
            hashPoint.Data = hashPoint._next.Data;
            hashPoint._next = hashPoint._next._next;
        }
        Console.WriteLine("Элемент не найден.");
    }
}