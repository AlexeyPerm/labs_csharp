using ClassLibraryLab10;
namespace Lab12_4;

public class MyCollection<T>
{
    private MyCollection<T>[] _table; // Хэш-таблица
    private int capacity;

    public MyCollection()
    {
        _table = new MyCollection<T>();
    }

    public MyCollection(int capacity)
    {
        this.capacity = capacity;
        _table = new MyCollection<T>[capacity];
    }

    public MyCollection(MyCollection<T> c)
    {
        capacity = c.capacity;
        _table = c._table;
    }
    
    public void Insert(T data)
    {
        var point = new HashPoint<T>(data);
        if (data == null) return;

        int index = Math.Abs(point.Key) % capacity;
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
    
}