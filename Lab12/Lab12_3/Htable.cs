using ClassLibraryLab10;

namespace Lab12_3;

public class Htable
{
    private class HashPoint
    {
        public int key;
        public Organisation Data;
        public HashPoint _next;

        public HashPoint(Organisation data)
        {
            Data = data;
            key = data.GetHashCode();
            _next = null;
        }

        public override string ToString()
        {
            return $"{key} + {Data}";
        }
    }

    public int Size = 512;
    private HashPoint[] _table;

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

        int index = Math.Abs(point.GetHashCode()) % Size;
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

    public void Print()
    {
        for (int i = 0; i < Size; i++)
        {
            if (_table[i] == null) continue;
            while (_table[i] != null)
            {
                _table[i].Data.Show();
                _table[i] = _table[i]._next;
            }
        }
    }
}