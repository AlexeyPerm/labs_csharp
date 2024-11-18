namespace Lab12_3_new;

using ClassLibraryLab10;

#nullable disable
public class HTable
{
    public int Length { get; private set; } = 10;

    private Organisation[] _table;

    public HTable() //Конструктор по умолчанию создаёт таблицу с 10 элементами
    {
        _table = new Organisation[Length];
    }

    public HTable(int length)
    {
        if (length <= 0)
        {
            throw new ArgumentException("Размер таблицы должен быть больше 0", nameof(length));
        }

        _table = new Organisation[length];
        Length = length;
    }

    // Хеш-функция
    private int Hash(Organisation item)
    {
        var hash = 0;
        hash += item.GetHashCode() + 323;
        return hash % Length;
    }

    // Метод для добавления элемента в хеш-таблицу с открытой адресацией
    public bool Add(Organisation item)
    {
        var itemHash = int.Abs(Hash(item));
        for (var i = 0; i < Length; i++)
        {
            var indexNum = (itemHash + i) % Length;
            if (_table[indexNum] == default)
            {
                _table[indexNum] = item;
                return true;
            }
        }

        Console.WriteLine("Хеш-таблица заполнена, невозможно добавить элемент.");
        return false;
    }

    /// <summary>
    /// Поиск элемента
    /// </summary>
    /// <param name="item">Искомый элемент</param>
    /// <returns>Возвращаем индекс элемента в хэш-таблице</returns>
    public int Search(Organisation item)
    {
        var itemHash = int.Abs(Hash(item));
        for (var i = 0; i < Length; i++)
        {
            var indexNum = (itemHash + i) % Length;
            if (_table[indexNum] != default)
            {
                return indexNum;
            }

            if (_table[indexNum] == default)
                break; // Если встретили пустую ячейку, значит элемента нет
        }

        return -1; // Элемент не найден
    }

    // Метод для удаления элемента из хеш-таблицы
    public bool Remove(Organisation item)
    {
        var index = Search(item);
        if (index == -1) return false;
        _table[index] = default;
        Length--;
        return true;
    }

    // Печать таблицы
    public void PrintTable()
    {
        Console.WriteLine("Хеш-таблица:");
        for (var i = 0; i < Length; i++)
        {
            Console.WriteLine($"[{i}]: {_table[i]}");
        }
    }

    public Organisation this[int index] => _table[index];
}