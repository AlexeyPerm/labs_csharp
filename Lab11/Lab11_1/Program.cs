using System.Collections;
using ClassLibraryLab10;

namespace Lab11_1;
static class Lab111
{
    private static void Main()
    {
        MainMenu();
        Console.Clear();
        Console.WriteLine("\nПрограмма успешно завершена\n");
    }

    //Основное меню
    private static void MainMenu()
    {
        const int variantNumber = 549 % 30 - 1; //номер варианта 8
        Console.WriteLine($"Номер варианта = {variantNumber}\n");
        const int length = 1000; //Размер коллекции 
        var ht = CreateHashtable(length);
        var exit = false;
        while (!exit)
        {
            Console.WriteLine();
            Console.WriteLine("1. Добавить элементы в коллекцию.");
            Console.WriteLine("2. Удалить элемент из коллекции.");
            Console.WriteLine("3. Распечатать элементы выбранного класса.");
            Console.WriteLine("4. Количество объектов класса в коллекции.");
            Console.WriteLine("5. Суммарный бюджет всех организаций.");
            Console.WriteLine("6. Клонировать хэш-таблицу и продемонстрировать работу.");
            Console.WriteLine("7. Поиск в хэш-таблице объекта класса.");
            Console.WriteLine("8. Распечатать все элементы коллекции.");
            Console.WriteLine("0. Выход");
            Console.Write("> ");

            var input = InputDigit();
            switch (input)
            {
                case 1:
                    AddItem(ht);
                    break;
                case 2:
                    RemoveItem(ht);
                    break;
                case 3:
                    PrintSpecificClass(ht);
                    break;
                case 4:
                    CountSpecificCLass(ht);
                    break;
                case 5:
                    SummaryBudget(ht);
                    break;
                case 6:
                    Hashtable newHashTable = CloneHashTable(ht);
                    DemonstrateCloneHashTable(ht, newHashTable);
                    break;
                case 7:
                    //Для демонстрации работы поиска будет создан объект, который уже существует в хэш-таблице, после
                    //чего будет произведён его же поиск
                    var rd = new Random();
                    Organisation temp = (Organisation)ht[rd.Next(ht.Count)]!;
                    FindItem(ht, temp);
                    break;
                case 8:
                    PrintHashtable(ht);
                    break;
                case 0:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Введены некорректные данные");
                    break;
            } //end of switch
        } //end of while
    } //end of MainMenu()

    /// <summary>
    /// Создание и заполнение хэш-таблицы заданной размерности и заполнение элементами класса Organisation
    /// </summary>
    /// <param name="length">Размер коллекции</param>
    /// <returns></returns>
    private static Hashtable CreateHashtable(int length)
    {
        var ht = new Hashtable(length);
        for (var i = 0; i < length; i++)
        {
            var tmp = RandObjectOrganisation();
            tmp.RandomInit();
            ht.Add(i + 1, tmp);
        }

        return ht;
    }

    /// <summary>
    /// Вывод на экран всех элементов хэш-таблицы
    /// </summary>
    /// <param name="ht">Передаваемая в качестве аргумента хэш-таблица</param>
    private static void PrintHashtable(Hashtable ht)
    {
        var c = ht.Keys;
        foreach (int item in c)
        {
            Console.WriteLine(item + ": " + ht[item]);
        }
    }

    /// <summary>
    /// Создание случайным образом объекта одного из классов: Organisation, Factory, Shipyard, Library, InsuranceCompany 
    /// </summary>
    /// <returns>Возвращает созданный объект класса</returns>
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
    /// Добавляет элемент в хэш-таблицу
    /// </summary>
    /// <param name="ht">Передаваемая в качестве аргумента хэш-таблица</param>
    private static void AddItem(Hashtable ht)
    {
        var tmp = RandObjectOrganisation();
        tmp.RandomInit();
        ht.Add(ht.Count + 1, tmp);
    }

    /// <summary>
    /// Удаляет элемент из хэш-таблицы
    /// </summary>
    /// <param name="ht">Передаваемая в качестве аргумента хэш-таблица</param>
    private static void RemoveItem(Hashtable ht)
    {
        Console.Write("Введите удаляемый ключ из таблицы:\n> ");
        var numberItem = InputDigit();
        if (!ht.ContainsKey(numberItem))
        {
            Console.WriteLine($"Не найден элемент с ключом {numberItem}");
            Thread.Sleep(500);
            return;
        }

        try
        {
            ht.Remove(numberItem);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Исключение: {ex}");
        }
    } //end of RemoveItem

    /// <summary>
    /// Выводит на экран элемента определённого вида (объекта класса)
    /// </summary>
    /// <param name="ht">Передаваемая в качестве аргумента хэш-таблица</param>
    private static void PrintSpecificClass(Hashtable ht)
    {
        Console.WriteLine("Выбор класса для распечатки:");
        var exit = false;
        while (!exit)
        {
            Console.WriteLine();
            Console.WriteLine("1. Базовый класс Organization.");
            Console.WriteLine("2. Фабрика.");
            Console.WriteLine("3. Судостроительная компания.");
            Console.WriteLine("4. Страховая компания.");
            Console.WriteLine("5. Библиотека.");
            Console.WriteLine("0. Возврат в предыдущее меню");
            Console.Write("> ");
            var input = InputDigit();
            IEnumerable<Organisation> temp;
            switch (input)
            {
                case 1:
                    temp = ht.Values.OfType<Organisation>()
                        .Where(x => x.GetType() == typeof(Organisation));
                    foreach (Organisation item in temp)
                    {
                        item.Show();
                        Console.WriteLine();
                    }

                    break;
                case 2:
                    temp = ht.Values.OfType<Factory>()
                        .Where(x => x.GetType() == typeof(Factory));
                    foreach (Organisation item in temp)
                    {
                        item.Show();
                        Console.WriteLine();
                    }

                    break;
                case 3:
                    temp = ht.Values.OfType<Shipyard>()
                        .Where(x => x.GetType() == typeof(Shipyard));
                    foreach (Organisation item in temp)
                    {
                        item.Show();
                        Console.WriteLine();
                    }

                    break;
                case 4:
                    temp = ht.Values.OfType<InsuranceCompany>()
                        .Where(x => x.GetType() == typeof(InsuranceCompany));
                    foreach (Organisation item in temp)
                    {
                        item.Show();
                        Console.WriteLine();
                    }

                    break;
                case 5:
                    temp = ht.Values.OfType<Library>()
                        .Where(x => x.GetType() == typeof(Library));
                    foreach (Organisation item in temp)
                    {
                        item.Show();
                        Console.WriteLine();
                    }

                    exit = true;
                    break;
                case 0:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Введены некорректные данные");
                    break;
            } //end of switch
        } //end of while
    } // end of PrintSpecificClass

    /// <summary>
    /// Выводит на экран количество элементов определённого вида (объекта класса)
    /// </summary>
    /// <param name="ht">Передаваемая в качестве аргумента хэш-таблица</param>
    private static void CountSpecificCLass(Hashtable ht)
    {
        Console.WriteLine("Количество объектов класса в коллекции:");
        var exit = false;
        while (!exit)
        {
            Console.WriteLine();
            Console.WriteLine("1. Базовый класс Organization.");
            Console.WriteLine("2. Фабрика.");
            Console.WriteLine("3. Судостроительная компания.");
            Console.WriteLine("4. Страховая компания.");
            Console.WriteLine("5. Библиотека.");
            Console.WriteLine("0. Возврат в предыдущее меню");
            Console.Write("> ");
            var input = InputDigit();
            IEnumerable<Organisation> temp;
            switch (input)
            {
                case 1:
                    temp = ht.Values.OfType<Organisation>()
                        .Where(x => x.GetType() == typeof(Organisation));
                    Console.WriteLine("Количество объектов: " + temp.Count());
                    break;
                case 2:
                    temp = ht.Values.OfType<Factory>()
                        .Where(x => x.GetType() == typeof(Factory));
                    Console.WriteLine("Количество объектов: " + temp.Count());
                    break;
                case 3:
                    temp = ht.Values.OfType<Shipyard>()
                        .Where(x => x.GetType() == typeof(Shipyard));
                    Console.WriteLine("Количество объектов: " + temp.Count());
                    break;
                case 4:
                    temp = ht.Values.OfType<InsuranceCompany>()
                        .Where(x => x.GetType() == typeof(InsuranceCompany));
                    Console.WriteLine("Количество объектов: " + temp.Count());

                    break;
                case 5:
                    temp = ht.Values.OfType<Library>()
                        .Where(x => x.GetType() == typeof(Library));
                    Console.WriteLine("Количество объектов: " + temp.Count());

                    exit = true;
                    break;
                case 0:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Введены некорректные данные");
                    break;
            } // end of switch
        } //end of while
    } //end of CountSpecificCLass

    /// <summary>
    /// Подсчитывает и выводит на экран бюджет всех организаций, содержащихся в хэш-таблице
    /// </summary>
    /// <param name="ht">Передаваемая в качестве аргумента хэш-таблица</param>
    private static void SummaryBudget(Hashtable ht)
    {
        long result = 0;
        foreach (Organisation item in ht.Values)
        {
            try
            {
                result += item.Budget;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Ошибка переполнения: {ex}");
                return;
            }
        }

        Console.WriteLine($"Суммарный бюджет всех организаций: {result}");
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

    /// <summary>
    /// Выполняется клонирование хэш-таблицы
    /// </summary>
    /// <param name="ht">Передаваемая в качестве аргумента клонируемая хэш-таблица</param>
    /// <returns>Возвращает клонированную хэш-таблицу</returns>
    private static Hashtable CloneHashTable(Hashtable ht)
    {
        var newHashTable = new Hashtable(ht.Count);
        foreach (DictionaryEntry item in ht)
        {
            Organisation tmp = (Organisation)item.Value!;
            newHashTable.Add(item.Key, tmp.Clone());
        }

        return newHashTable;
    }


    /// <summary>
    /// Функция, демонстрирующая работу клонирования. В каждой таблице изменяется элемент с индексом 0 и выводится
    /// на экран.
    /// </summary>
    /// <param name="current">Текущая хэш-таблица</param>
    /// <param name="cloned">Клонированная хэш-таблица</param>
    private static void DemonstrateCloneHashTable(Hashtable current, Hashtable cloned)
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine($"Первый элемент в текущей хэш-таблице:\n{current[1]}");
        Console.WriteLine();
        Console.WriteLine($"Первый элемент в новой хэш-таблице:\n{cloned[1]}");
        Thread.Sleep(500);

        Console.WriteLine();
        Console.WriteLine("Изменяем в первом элементе текущей хэш-таблицы бюджет организации да 555555:");
        Organisation temp = (Organisation)current[1]!;
        temp.Budget = 555555;

        Console.WriteLine($"Первый элемент в текущей хэш-таблице:\n{current[1]}");
        Console.WriteLine($"Первый элемент в новой хэш-таблице:\n{cloned[1]}");
        Thread.Sleep(500);
    }

    /// <summary>
    /// Поиск объекта класса в хэш-таблице.
    /// </summary>
    /// <param name="ht">Передаваемая в качестве аргумента клонируемая хэш-таблица</param>
    /// <param name="searchElement">Передаваемый в качестве аргумента искомый объект класса</param>
    private static void FindItem(Hashtable ht, Organisation searchElement)
    {
        Console.Clear();
        Console.WriteLine("Ищется объект:");
        searchElement.Show();
        Console.WriteLine(ht.ContainsValue(searchElement) ? "Объект найден" : "Объект отсутствует");

        Console.WriteLine();
        var temp = new Library("test", 2, 1);
        Console.WriteLine("Ищется несуществующий в коллекции объект:");
        temp.Show();
        Console.WriteLine(ht.ContainsValue(temp) ? "Объект найден" : "Объект отсутствует");
    }
}