using ClassLibraryLab10;
namespace Lab11_2;

static class Program
{
    static void Main() => MainMenu();


    //Основное меню
    private static void MainMenu()
    {
        const int length = 1000; //Размер коллекции 
        var dict = CreateHashtable(length);
        var exit = false;
        while (!exit)
        {
            Console.WriteLine();
            Console.WriteLine("1. Добавить элементы в коллекцию.");
            Console.WriteLine("2. Удалить элемент из коллекции.");
            Console.WriteLine("3. Распечатать элементы выбранного класса.");
            Console.WriteLine("4. Количество объектов класса в коллекции.");
            Console.WriteLine("5. Суммарный бюджет всех организаций.");
            Console.WriteLine("6. Склонировать словарь и продемонстрировать работу.");
            Console.WriteLine("7. Поиск в словаре объекта класса.");
            Console.WriteLine("8. Распечатать все элементы коллекции.");
            Console.WriteLine("0. Выход");
            Console.Write("> ");

            var input = InputDigit();
            switch (input)
            {
                case 1:
                    AddItem(dict);
                    break;
                case 2:
                    RemoveItem(dict);
                    break;
                case 3:
                    PrintSpecificClass(dict);
                    break;
                case 4:
                    CountSpecificCLass(dict);
                    break;
                case 5:
                    SummaryBudget(dict);
                    break;
                case 6:
                    Dictionary<int, Organisation> newDict = CloneDictionary(dict);
                    DemonstrateCloneHashTable(dict, newDict);
                    break;
                case 7:
                    //Для демонстрации работы поиска будет создан объект, который уже существует в словаре, после
                    //чего будет произведён его же поиск
                    var rd = new Random();
                    Organisation temp = dict[rd.Next(dict.Count)];
                    FindItem(dict, temp);
                    break;
                case 8:
                    PrintDictionary(dict);
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
    /// Вывод на экран всех элементов словаря
    /// </summary>
    /// <param name="dict">Передаваевый в качестве аргумента словарь</param>
    private static void PrintDictionary(Dictionary<int, Organisation> dict)
    {
        var c = dict.Keys;
        foreach (int item in c)
        {
            Console.WriteLine(item + ": " + dict[item]);
        }
    }

    /// <summary>
    /// Поиск объъекта класса в словаре.
    /// </summary>
    /// <param name="dict">Передаваевый в качестве аргумента клонируемый словарь</param>
    /// <param name="searchElement">Передаваевый в качестве аргумента искомый объект класса</param>
    private static void FindItem(Dictionary<int, Organisation> dict, Organisation searchElement)
    {
        Console.Clear();
        Console.WriteLine("Ищется объект:");
        searchElement.Show();
        Console.WriteLine(dict.ContainsValue(searchElement) ? "Объект найден" : "Объект отсутствует");

        Console.WriteLine();
        var temp = new Library("test", 2, 1);
        Console.WriteLine("Ищется несуществующий в коллекции объект:");
        temp.Show();
        Console.WriteLine(dict.ContainsValue(temp) ? "Объект найден" : "Объект отсутствует");
    }

    /// <summary>
    /// Функция, демонстрирующая работу клонирования. В каждой таблице изменяется элемент с индексом 0 и выводится
    /// на экран.
    /// </summary>
    /// <param name="current">Текущая словарь</param>
    /// <param name="cloned">Клонированная словарь</param>
    private static void DemonstrateCloneHashTable
        (Dictionary<int, Organisation> current, Dictionary<int, Organisation> cloned)
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine($"Первый элемент в текущей словаре:\n{current[1]}");
        Console.WriteLine();
        Console.WriteLine($"Первый элемент в новой словаре:\n{cloned[1]}");
        Thread.Sleep(500);

        Console.WriteLine();
        Console.WriteLine("Изменяем в первом элементе текущей словаря бюджет организации да 555555:");
        Organisation temp = current[1];
        temp.Budget = 555555;

        Console.WriteLine($"Первый элемент в текущей словаре:\n{current[1]}");
        Console.WriteLine($"Первый элемент в новой словаре:\n{cloned[1]}");
        Thread.Sleep(500);
    }


    /// <summary>
    /// Выполняется клонировение словаря
    /// </summary>
    /// <param name="dict">Передаваевый в качестве аргумента клонируемый словарь</param>
    /// <returns>Возвращает склонированную словарь</returns>
    private static Dictionary<int, Organisation> CloneDictionary(Dictionary<int, Organisation> dict)
    {
        var newDictionary = new Dictionary<int, Organisation>(dict.Count);
        foreach (KeyValuePair<int, Organisation> item in dict)
        {
            Organisation tmp = item.Value;
            newDictionary.Add(item.Key, (Organisation)tmp.Clone());
        }

        return newDictionary;
    }

    /// <summary>
    /// Подсчитывает и выводит на экран бюджет всех организаций, содержашихся в словаре
    /// </summary>
    /// <param name="dict">Передаваевый в качестве аргумента словарь</param>
    private static void SummaryBudget(Dictionary<int, Organisation> dict)
    {
        long result = 0;
        foreach (Organisation item in dict.Values)
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
    /// Выводит на экран количество элементов определённого вида (объекта класса)
    /// </summary>
    /// <param name="dict">Передаваевый в качестве аргумента словарь</param>
    private static void CountSpecificCLass(Dictionary<int, Organisation> dict)
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
                    temp = dict.Values.OfType<Organisation>()
                        .Where(x => x.GetType() == typeof(Organisation));
                    Console.WriteLine("Количество объектов: " + temp.Count());
                    break;
                case 2:
                    temp = dict.Values.OfType<Factory>()
                        .Where(x => x.GetType() == typeof(Factory));
                    Console.WriteLine("Количество объектов: " + temp.Count());
                    break;
                case 3:
                    temp = dict.Values.OfType<Shipyard>()
                        .Where(x => x.GetType() == typeof(Shipyard));
                    Console.WriteLine("Количество объектов: " + temp.Count());
                    break;
                case 4:
                    temp = dict.Values.OfType<InsuranceCompany>()
                        .Where(x => x.GetType() == typeof(InsuranceCompany));
                    Console.WriteLine("Количество объектов: " + temp.Count());

                    break;
                case 5:
                    temp = dict.Values.OfType<Library>()
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
    /// Выводит на экран элемента определённого вида (объекта класса)
    /// </summary>
    /// <param name="dict">Передаваевый в качестве аргумента словарь</param>
    private static void PrintSpecificClass(Dictionary<int, Organisation> dict)
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
                    temp = dict.Values.OfType<Organisation>()
                        .Where(x => x.GetType() == typeof(Organisation));
                    foreach (Organisation item in temp)
                    {
                        item.Show();
                        Console.WriteLine();
                    }

                    break;
                case 2:
                    temp = dict.Values.OfType<Factory>()
                        .Where(x => x.GetType() == typeof(Factory));
                    foreach (Organisation item in temp)
                    {
                        item.Show();
                        Console.WriteLine();
                    }

                    break;
                case 3:
                    temp = dict.Values.OfType<Shipyard>()
                        .Where(x => x.GetType() == typeof(Shipyard));
                    foreach (Organisation item in temp)
                    {
                        item.Show();
                        Console.WriteLine();
                    }

                    break;
                case 4:
                    temp = dict.Values.OfType<InsuranceCompany>()
                        .Where(x => x.GetType() == typeof(InsuranceCompany));
                    foreach (Organisation item in temp)
                    {
                        item.Show();
                        Console.WriteLine();
                    }

                    break;
                case 5:
                    temp = dict.Values.OfType<Library>()
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
    /// Удаляет элемент из словаря
    /// </summary>
    /// <param name="dict">Передаваевый в качестве аргумента словарь</param>
    private static void RemoveItem(Dictionary<int, Organisation> dict)
    {
        Console.Write("Введите удаляемый ключ из таблицы:\n> ");
        var numberItem = InputDigit();
        if (!dict.ContainsKey(numberItem))
        {
            Console.WriteLine($"Не найден элемент с ключом {numberItem}");
            Thread.Sleep(500);
            return;
        }

        try
        {
            dict.Remove(numberItem);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Исключение: {ex}");
        }
    } //end of RemoveItem


    /// <summary>
    /// Добавляет элемент в словарь
    /// </summary>
    /// <param name="dict">Передаваевый в качестве аргумента словарь</param>
    private static void AddItem(Dictionary<int, Organisation> dict)
    {
        var tmp = RandObjectOrganisation();
        tmp.RandomInit();
        dict.Add(dict.Count + 1, tmp);
    }


    /// <summary>
    /// Создание словаря
    /// </summary>
    /// <param name="length">Размер коллекции</param>
    /// <returns></returns>
    private static Dictionary<int, Organisation> CreateHashtable(int length)
    {
        var ht = new Dictionary<int, Organisation>(length);
        for (var i = 0; i < length; i++)
        {
            var tmp = RandObjectOrganisation();
            tmp.RandomInit();
            ht.Add(i + 1, tmp);
        }

        return ht;
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