namespace Lab13_new;

using ClassLibraryLab10;

class Program
{
    static void Main()
    {
        var firstCollection = new MyNewCollection<Organisation>("Первая коллекция", 3);
        var secondCollection = new MyNewCollection<Organisation>("Вторая коллекция", 5);
        var firstJournal = new Journal();
        var secondJournal = new Journal();

        //Создать два объекта типа Journal, один объект Journal подписать
        //на события CollectionCountChanged и CollectionReferenceChanged из первой коллекции,
        firstCollection.CollectionCountChanged += firstJournal.CollectionCountChanged;
        firstCollection.CollectionReferenceChanged += firstJournal.CollectionReferenceChanged;

        //Другой объект Journal подписать на события CollectionReferenceChanged из обеих коллекций. 
        firstCollection.CollectionCountChanged += secondJournal.CollectionReferenceChanged;
        secondCollection.CollectionCountChanged += secondJournal.CollectionReferenceChanged;

        for (int i = 0; i < firstCollection.Count; i++)
        {
            var newItem = RandObjectOrganisation();
            newItem.RandomInit();
            firstCollection[i] = newItem;
        }

        var temp = RandObjectOrganisation();
        temp.RandomInit();
        firstCollection.Add(temp);
        var removedItem = firstCollection[1];
        firstCollection.Remove(removedItem);


        Console.WriteLine("==========================================");
        Console.WriteLine("============= First Journal ==============");
        Console.WriteLine("==========================================");

        firstJournal.PrintJournal();

        for (int i = 0; i < secondCollection.Count; i++)
        {
            var newItem = RandObjectOrganisation();
            newItem.RandomInit();
            secondCollection[i] = newItem;
        }

        var temp1 = RandObjectOrganisation();
        temp1.RandomInit();
        secondCollection.Add(temp);
        var removedItem1 = secondCollection[1];
        secondCollection.Remove(removedItem1);


        Console.WriteLine("==========================================");
        Console.WriteLine("============= Second Journal =============");
        Console.WriteLine("==========================================");

        secondJournal.PrintJournal();
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