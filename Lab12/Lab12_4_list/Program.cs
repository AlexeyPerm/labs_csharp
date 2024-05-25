using System.Runtime.InteropServices.JavaScript;

namespace Lab12_4_list;

using ClassLibraryLab10;

static class Program
{
    private static void Main()
    {
        const int variantNumber = 549 % 25 - 1; //номер варианта 23
        Console.WriteLine($"Номер варианта = {variantNumber}\n");

        MainMenu();
    }


    private static void MainMenu()
    {
        var exit = false;
        var collection = new MyCollection<Organisation>();
        while (!exit)
        {
            Console.WriteLine();
            Console.WriteLine("1. Создать коллекцию из 10 элементов.");
            Console.WriteLine("2. Добавить элемент в коллекцию.");
            Console.WriteLine("3. Добавить рандомно до 10 элементов в коллекцию.");
            Console.WriteLine("4. Вывести количество элементов в коллекции.");
            Console.WriteLine("5. Удалить элемент из коллекции по номеру.");
            Console.WriteLine("6. Удалить рандомно 3 элемента из коллекции по номеру.");


            Console.WriteLine("7. Вывести элемент по номеру в коллекции на экран.");
            Console.WriteLine("8. Вывести всю коллекцию на экран.");
            Console.WriteLine("9. Удалить коллекцию.");
            Console.WriteLine("0. Выход");
            Console.Write("> ");

            var input = InputDigit();
            switch (input)
            {
                default:
                    Console.WriteLine("Введены некорректные данные");
                    break;
                case 1:
                    collection = CreateNewCollection();
                    break;
                case 2:
                    AddElement(collection);
                    break;
                case 3:
                    AddMultipleElements(collection);
                    break;
                case 4:
                    Console.WriteLine($"Количество элементов в коллекции:{collection.Count}");
                    break;
                case 5:
                    RemoveElementByNumber(collection);
                    break;
                case 6:
                    RemoveMultipleElements(collection);
                    break;
                case 7:
                    PrintByNumber(collection);
                    break;
                case 8:
                    PrintCollection(collection);
                    break;
                case 9:
                    collection.Clear();
                    Console.WriteLine("Список очищен");
                    break;
                case 0:
                    exit = true;
                    break;
            } //end of switch
        } //end of while
    }

    private static void AddMultipleElements(MyCollection<Organisation> collection)
    {
        var rand = new Random();
        var countAddElements = rand.Next(100) % 8;
        var array = new Organisation [countAddElements];
        for (var i = 0; i < countAddElements; i++)
        {
            var tempElement = RandObjectOrganisation();
            tempElement.RandomInit();
            array[i] = tempElement;
        }

        Console.WriteLine($"Было добавлено элементов в количестве: {countAddElements}");
        collection.AddMultiple(array);
    }
    //end of MainMenu()


    private static void AddElement(MyCollection<Organisation> collection)
    {
        var addElement = RandObjectOrganisation();
        addElement.RandomInit();
        collection.Add(addElement);
    }


    private static void RemoveMultipleElements(MyCollection<Organisation> collection)
    {
        if (collection.Count < 3)
        {
            throw new ArgumentOutOfRangeException(nameof(collection),
                "Количество элементов в коллекции меньше кол-ва удаляемых элементов");
        }

        var rand = new Random();
        const int countRemovedElements = 3;
        var array = new Organisation [3];
        for (var i = 0; i < countRemovedElements; i++)
        {
            array[i] = collection[rand.Next(10) % collection.Count];
        }

        collection.RemoveMultiple(array);
    }


    private static void RemoveElementByNumber(MyCollection<Organisation> collection)
    {
        Console.WriteLine("Введите номер элемента:");
        Console.Write("> ");
        var removeElement = InputDigit();
        collection.Remove(collection[removeElement]);
    }


    /// <summary>
    /// Печать элемента по номеру в коллекции
    /// </summary>
    private static void PrintByNumber(MyCollection<Organisation> collection)
    {
        Console.WriteLine("Введите номер элемента:");
        Console.Write("> ");
        var number = InputDigit();
        PrintCollectionByNumber(collection, number);
    }

    /// <summary>
    /// Печать всех элементов коллекции
    /// </summary>
    private static void PrintCollection(MyCollection<Organisation> collection)
    {
        if (collection.IsEmpty)
        {
            Console.WriteLine("Список пустой");
            return;
        }

        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
    }

    private static void PrintCollectionByNumber(MyCollection<Organisation> collection, int number)
    {
        Console.WriteLine(collection[number - 1]);
    }


    private static MyCollection<Organisation> CreateNewCollection()
    {
        var sizeCollection = 10;
        var tempCollection = new MyCollection<Organisation>();
        for (var i = 0; i < sizeCollection; i++)
        {
            var elem = RandObjectOrganisation();
            elem.RandomInit();
            tempCollection.Add(elem);
        }

        return tempCollection;
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
}