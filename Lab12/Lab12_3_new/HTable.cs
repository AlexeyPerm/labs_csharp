namespace Lab12_3_new;
using ClassLibraryLab10;

public class HTable(int size)
{
    private Organisation[] _table = new Organisation[size];

    // Хеш-функция
    private int Hash(Organisation item)
    {
        var hash = 0;
        hash += item.GetHashCode() + 323;
        return hash % size;
    }
    
    // Метод для добавления элемента в хеш-таблицу с открытой адресацией
    public void Add(Organisation item)
    {
        var itemHash = Hash(item);
        for (var i = 0; i < size; i++)
        {
            var indexNum = (itemHash + i) % size;
            if (_table[indexNum] == default)
            {
                _table[indexNum] = item;
                return;
            }
        }
        Console.WriteLine("Хеш-таблица заполнена, невозможно добавить элемент.");
    }
    
    /// <summary>
    /// Поиск элемента
    /// </summary>
    /// <param name="item">Искомый элемент</param>
    /// <returns>Возвращаем индекс элемента в хэш-таблице</returns>
        public int Search(Organisation item)
        {
            var itemHash = Hash(item);
            for (var i = 0; i < size; i++)
            {
                var indexNum = (itemHash + i) % size;
                if (_table[indexNum].CompareTo(item) == 0)
                {
                    return indexNum;
                }
                if (_table[indexNum] == 0) break; // Если встретили пустую ячейку, значит элемента нет
            }
            return -1; // Элемент не найден
        }
    
    // Метод для удаления элемента из хеш-таблицы
    public bool Remove(Organisation item)
    {
        var index = Search(item);
        if (index == -1) return false;
        _table[index] = default;
        return true;
    }

    // Печать таблицы
    public void PrintTable()
    {
        Console.WriteLine("Хеш-таблица:");
        for (var i = 0; i < size; i++)
        {
            Console.WriteLine($"[{i}]: {_table[i]}");
        }
    }
    
    private static Organisation RandObjectOrganisation()
    {
        var rand = new Random();
        var randSeed = rand.Next(100) % 5;
        var newItem = randSeed switch
        {
            0 => new Organisation(),
            1 => new Factory(),
            2 => new Shipyard(),
            3 => new Library(),
            4 => new InsuranceCompany(),
            _ => new Organisation()
        };
        return newItem;
    }
}