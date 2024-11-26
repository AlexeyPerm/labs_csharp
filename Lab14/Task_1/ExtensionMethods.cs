namespace Task_1;

public static class ExtensionMethods
{
    //Метод расширения для создания коллекции из различных объектов класса Organisation
    public static void CreateNewCollection(this MyCollection<Organisation> collection, int sizeCollection = 10)
    {
        var rand = new Random();
        for (var i = 0; i < sizeCollection; i++)
        {
            //Рандомно выбираем, объект какого класса будет создан
            var newItem = (rand.Next(100) % 5) switch
            {
                0 => new Organisation(),
                1 => new Factory(),
                2 => new Shipyard(),
                3 => new Library(),
                4 => new InsuranceCompany(),
                _ => new Organisation()
            };


            newItem.RandomInit();
            collection.Add(newItem);
        } //end of for
    } //end of CreateNewCollection

    /// <summary>
    /// Суммарное количество книг в библиотеках
    /// </summary>
    /// <param name="collection">Коллекция, в которой происходит подсчёт</param>
    /// <returns>Суммарное количество книг</returns>
    public static ulong ShowBooksSum(this MyCollection<Organisation> collection)
    {
        ulong booksSum = 0;
        foreach (var item in collection)
        {
            if (item is Library p)
                booksSum += p.BooksTotalNum;
        }

        return booksSum;
    } //end of ShowBooksSum

    /// <summary>
    /// Список организаций с бюджетом меньше 3000
    /// </summary>
    /// <param name="collection">Коллекция, в которой происходит поиск</param>
    public static void ShowOrgBudget(this MyCollection<Organisation> collection)
    {
        foreach (var item in collection)
        {
            if (item.Budget < 3000)
            {
                Console.Write(item.OrgName + "; ");
            }
        } //end of foreach
    } //end of ShowOrgBudget

    /// <summary>
    /// Количество организаций с бюджетом меньше 3000
    /// </summary>
    /// <param name="collection">Коллекция, в которой происходит поиск</param>
    public static void ShowOrgBudget1(this MyCollection<Organisation> collection)
    {
        Console.WriteLine(collection.Count(item => item.Budget < 3000));
    } //end of ShowOrgBudget

    /// <summary>
    /// Вывод сгруппированной по видам деятельности организаций
    /// </summary>
    /// <param name="collection"></param>
    public static void GroupByCompany(this MyCollection<Organisation> collection)
    {
        var dict = new Dictionary<string, List<Organisation>>();
        dict["Organisation"] = [];
        dict["Factory"] = [];
        dict["Shipyard"] = [];
        dict["InsuranceCompany"] = [];
        dict["Library"] = [];

        foreach (var item in collection)
        {
            if (item.GetType() == typeof(Organisation))
            {
                dict["Organisation"].Add(item);
            }
            else if (item.GetType() == typeof(Factory))
            {
                dict["Factory"].Add(item);
            }
            else if (item.GetType() == typeof(InsuranceCompany))
            {
                dict["InsuranceCompany"].Add(item);
            }
            else if (item.GetType() == typeof(Library))
            {
                dict["Library"].Add(item);
            }
            else if (item.GetType() == typeof(Shipyard))
            {
                dict["Shipyard"].Add(item);
            }
        } //end of foreach

        foreach (var item in dict.Where(item => item.Value.Count != 0))
        {
            Console.WriteLine(item.Key + ": ");
            foreach (var value in item.Value)
            {
                Console.WriteLine(value.OrgName);
            }

            Console.WriteLine();
        }
    } //end of GroupByCompany

    public static void AnyOperationsExtension(this MyCollection<Organisation> collection)
    {
        var tempCollection = new MyCollection<Organisation>();
        tempCollection.Add(collection[1]);
        tempCollection.Add(collection[3]);
        tempCollection.Add(new Shipyard("testShipyard", 7777, 55555, 33333));
        Console.WriteLine("==========================================");
        Console.WriteLine("Пересечение коллекций (выводятся только имена объектов): ");
        var intersectCollections = collection.Intersect(tempCollection);
        foreach (var item in intersectCollections)
        {
            Console.WriteLine(item.OrgName);
        }

        Console.WriteLine();
        Console.WriteLine("Объединение коллекций (выводятся только имена объектов): ");
        var unionCollections = collection.Union(tempCollection);
        foreach (var item in unionCollections)
        {
            Console.WriteLine(item.OrgName);
        }

        Console.WriteLine("Разность коллекций (выводятся только имена объектов): ");
        var exceptCollections = collection.Except(tempCollection);
        foreach (var item in exceptCollections)
        {
            Console.WriteLine(item.OrgName);
        }
    }
}