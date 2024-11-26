namespace Task_1;

class Program
{
    static void Main()
    {
        var myCollection = new MyCollection<Organisation>();
        myCollection.CreateNewCollection();
        Console.WriteLine($"Созданный размер коллекции: {myCollection.Count}");
        BudgetRequest(myCollection); //Выборка
        BudgetRequestNew(myCollection); //Получение счетчика (количества объектов с заданным параметром).
        BooksSum(myCollection); //Агрегирование
        GroupByOrgName(myCollection); //Группировка
        AnyOperations(myCollection);
    }

    private static void AnyOperations(MyCollection<Organisation> myCollection)
    {
        var tempCollection = new MyCollection<Organisation>();
        tempCollection.Add(myCollection[1]);
        tempCollection.Add(myCollection[3]);
        tempCollection.Add(new Shipyard("testShipyard", 7777, 55555, 33333));
        Console.WriteLine("==========================================");
        Console.WriteLine("Пересечение коллекций (выводятся только имена объектов): ");
        var intersectCollections = myCollection.Intersect(tempCollection);
        foreach (var item in intersectCollections)
        {
            Console.WriteLine(item.OrgName);
        }

        Console.WriteLine();
        Console.WriteLine("Объединение коллекций (выводятся только имена объектов): ");
        var unionCollections = myCollection.Union(tempCollection);
        foreach (var item in unionCollections)
        {
            Console.WriteLine(item.OrgName);
        }

        Console.WriteLine("Разность коллекций (выводятся только имена объектов): ");
        var exceptCollections = myCollection.Except(tempCollection);
        foreach (var item in exceptCollections)
        {
            Console.WriteLine(item.OrgName);
        }
        
        Console.WriteLine("==========================================");
        Console.WriteLine("Метод расширения: ");
        myCollection.AnyOperationsExtension();
    }


    private static void BooksSum(MyCollection<Organisation> myCollection)
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("Суммарное количество книг в библиотеках:");
        //BooksTotalNum имеет тип uint, в Sum() работает с int, поэтому преобразуем в int,
        //С помощью checked происходит проверка на переполнение
        var bookSum =
            checked(from book in myCollection where book is Library select (int)((Library)book).BooksTotalNum).Sum();
        Console.WriteLine($"LINQ запрос: {bookSum}");
        Console.WriteLine($"Метод расширения: {myCollection.ShowBooksSum()}");
    }

    private static void GroupByOrgName(MyCollection<Organisation> myCollection)
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("Группировка названий организаций:");
        Console.WriteLine("******************************************");
        Console.WriteLine("LINQ запрос:");

        var companies = myCollection.GroupBy(x => x.GetType().Name);

        foreach (var item in companies)
        {
            Console.WriteLine(item.Key + ": ");
            foreach (var companyName in item)
            {
                Console.WriteLine(companyName.OrgName);
            }

            Console.WriteLine();
        } //end of foreach

        Console.WriteLine("******************************************");
        Console.WriteLine("Метод расширения: ");
        myCollection.GroupByCompany();
    } //end of  GroupByOrgName

    private static void BudgetRequest(MyCollection<Organisation> myCollection)
    {
        Console.WriteLine();
        Console.WriteLine("==========================================");
        Console.WriteLine("Информация обо всех организациях, бюджет которых меньше 3000:");
        Console.WriteLine("LINQ запрос (вывод только названий организаций: ");
        var budget = myCollection.Where(x => x.Budget < 3000);
        foreach (var item in budget)
        {
            Console.Write(item.OrgName + "; ");
        }

        Console.WriteLine();
        Console.WriteLine("Метод расширения: ");
        myCollection.ShowOrgBudget();
    } // end of BudgetRequest

    //Получение счетчика (количества объектов с заданным параметром).
    private static void BudgetRequestNew(MyCollection<Organisation> myCollection)
    {
        Console.WriteLine();
        Console.WriteLine("==========================================");
        Console.WriteLine("Количество организаций, бюджет которых меньше 3000:");
        Console.WriteLine("LINQ запрос: ");
        var budget = myCollection.Count(x => x.Budget < 3000);
        Console.WriteLine($"Количество организаций с бюджетом меньше 3000: " + budget);
        Console.WriteLine();
        Console.WriteLine("Метод расширения: ");
        Console.Write("Количество организаций с бюджетом меньше 3000: ");
        myCollection.ShowOrgBudget1();
    } // end of BudgetRequest
}