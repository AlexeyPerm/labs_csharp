using System.Collections;
using ClassLibraryLab10;

#nullable disable
namespace Lab12_3_new;

class Program
{
    static void Main(string[] args)
    {
        MainMenu();
        Console.ReadLine();
        var test = new Hashtable(10);
        test[2] = 10;
    }

    private static void MainMenu()
    {
        var exit = false;
        HTable ht = null; //Создаём переменную. Память выделится тогда, когда будет известно кол-во элементов.
        while (!exit)
        {
            Console.WriteLine();
            Console.WriteLine("1. Создать хэш-таблицу с 10 элементами");
            Console.WriteLine("2. Создать хэш-таблицу из указанного кол-ва элементов");
            Console.WriteLine("3. Выполнить поиск существующего элемента по имени в хэш-таблице");
            Console.WriteLine("4. Добавление элемента в заполненную хэш-таблицу");
            Console.WriteLine("5. Удалить элемент из хэш-таблицу и выполнить последующий его поиск");
            Console.WriteLine("6. Вывести на экран хэш-таблицу");
            Console.WriteLine("9. Удалить хэш-таблицу");
            Console.WriteLine("0. Выход");
            Console.Write("> ");
            var input = InputDigit();
            switch (input)
            {
                default:
                    Console.WriteLine("Введены некорректные данные");
                    break;
                case 1: //Создаём хэш-таблицу с 10 элементами и заполняем её случайными элементами
                    ht = CreateHashTableTenElements();
                    break;
                case 2: //Создаём хэш-таблицу с заданным количеством элементам и заполняем её случайными элементами
                    ht = CreateHashTable();
                    break;
                case 3: //Поиск элемента. Для простоты искомый элемент уже "зашит" в функцию
                    SearchElement(ht);
                    break;
                case 4: //Добавление элемента в полную хэш-таблицу
                    AddItem(ht);
                    break;
                case 5: //Удаление найденного элемента из хеш-таблицы
                    RemoveItem(ht);
                    break;
                case 6: //Вывод на экран хэш-таблицы
                    PrintHashTable(ht);
                    break;
                case 9:
                    DeleteHashTable(ref ht);
                    break;
                case 0:
                    exit = true;
                    Console.Clear();
                    Console.WriteLine("Программа успешно завершена");
                    break; //Назад в предыдущее меню
            } //end of switch
        } // end of while
    }

    private static void DeleteHashTable(ref HTable ht)
    {
        if (ht == null)
        {
            Console.WriteLine("Хэш-таблица пуста");
        }
        else
        {
            ht = null;
            Console.WriteLine("Хэш-таблица удалена");
        }
    }

    private static void RemoveItem(HTable ht)
    {
        if (ht == null)
        {
            throw new ArgumentNullException(nameof(ht), "Хэш-таблица пустая");
        }

        var itemNum = ht.Length - 1;
        var item = ht[itemNum];
        Console.WriteLine("Удаляемый элемент:");
        item.Show();
        
        if (ht.Remove(item))
        {
            Console.WriteLine("Удаление прошло успешно");
        }
        else
        {
            Console.WriteLine("Элемент не удалён");
        }
        
        var index = ht.Search(item);    //Поиск удалённого элемента
        if (index != -1)
        {
            Console.WriteLine($"Элемент найден на позиции {index}");
        }
        else
        {
            Console.WriteLine($"Элемент после удаления не найден");
        }
    }

    private static void AddItem(HTable ht)
    {
        var addItem = RandObjectOrganisation();
        addItem.RandomInit();
        Console.WriteLine("Попытка добавить элемент в полную таблицу...");
        if (ht == null)
        {
            throw new ArgumentNullException(nameof(ht), "Хэш-таблица пустая");
        }

        ht.Add(addItem);
    }

    private static void PrintHashTable(HTable ht)
    {
        if (ht == null)
        {
            throw new ArgumentNullException(nameof(ht), "Хэш-таблица пустая");
        }

        ht.PrintTable();
    }

    private static void SearchElement(HTable ht)
    {
        if (ht == null)
        {
            Console.Clear();
            Console.WriteLine("Хэш-таблица пустая");
            return;
        }

        var searchData = ht[0];
        var index = ht.Search(searchData);
        if (index != -1)
        {
            Console.WriteLine($"Элемент с именем '{searchData.OrgName}' найден на позиции {index}");
        }
        else
        {
            Console.WriteLine($"Элемент с именем '{searchData.OrgName}' не найден");
        }
    }

    /// <summary>
    /// Метод для создания Хэш-таблицы с дефолтным размером равным 10
    /// </summary>
    /// <returns>Возвращает Хэш-таблицу размерностью 10</returns>
    private static HTable CreateHashTableTenElements()
    {
        var ht = new HTable();
        for (var i = 0; i < ht.Length; i++)
        {
            var item = RandObjectOrganisation();
            item.RandomInit();
            ht.Add(item);
        }

        Console.Clear();
        Console.WriteLine("Хэш-таблица создана\n");
        return ht;
    }

    /// <summary>
    /// Метод для создания Хэш-таблицы с заданным размером
    /// </summary>
    /// <returns></returns>
    private static HTable CreateHashTable()
    {
        Console.WriteLine("Введите размер Хэш-таблицы:");
        Console.Write("> ");
        var size = InputDigit();
        HTable ht = new HTable(size);
        Console.Clear();
        Console.WriteLine("Хэш-таблица создана\n");

        for (var i = 0; i < size; i++)
        {
            var item = RandObjectOrganisation();
            item.RandomInit();
            ht.Add(item);
        }

        return ht;
    }

    /// <summary>
    /// Метод, заполняющий объекты класса Organization случайными данными
    /// </summary>
    /// <returns>Возвращает объект класса Organization</returns>
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

    /// <summary>
    /// Проверка корректности ввода и конвертация строки в целое число int
    /// </summary>
    /// <returns>Возвращает целое число, конвертированное из строки</returns>
    private static int InputDigit()
    {
        int result;
        while (!int.TryParse(Console.ReadLine(), out result))
        {
            Console.Write("Ошибка! Должен быть тип int\nПовторите ввод\n> ");
        }

        return result;
    }
}