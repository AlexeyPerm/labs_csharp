using ClassLibraryLab10;

namespace Lab12_3_new;

class Program
{
    static void Main(string[] args)
    {
        // 1. Создать хеш-таблицу и заполнить ее элементами
        var ht = new HTable(10); // Установим размер таблицы 5 для наглядности
        var random = new Random();
        for (var i = 0; i < 9; i++)
        {
            var tmp = RandObjectOrganisation();
            tmp.RandomInit();
            ht.Add(tmp);
        }
        var randItem = RandObjectOrganisation();
        randItem.RandomInit();
        ht.Add(randItem);

        Console.WriteLine("После заполнения таблицы:");
        ht.PrintTable();

        // 2. Выполнить поиск элемента в хеш-таблице
        var searchKey = randItem;
        var index = ht.Search(searchKey);
        if (index != -1)
        {
            Console.WriteLine($"Элемент '{searchKey}' найден на позиции {index}");
        }
        else
        {
            Console.WriteLine($"Элемент '{searchKey}' не найден");
        }
        
        var addItem = RandObjectOrganisation();
        addItem.RandomInit();
        // 3. Попытка добавить элемент в полную хеш-таблицу
        Console.WriteLine($"Попытка добавить элемент '{addItem}' в полную таблицу...");
        ht.Add(addItem);

        // 4. Удаление найlенного элемент из хеш-таблицы
        Console.WriteLine($"Удаление элемента '{searchKey}'");
        ht.Remove(searchKey);
        ht.PrintTable();

        // 5. Выполнить поиск элемента в хеш-таблице после удаления
        index = ht.Search(searchKey);
        if (index != -1)
        {
            Console.WriteLine($"Элемент '{searchKey}' найден на позиции {index}");
        }
        else
        {
            Console.WriteLine($"Элемент '{searchKey}' после удаления не найден");
        }


        ht.PrintTable();
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