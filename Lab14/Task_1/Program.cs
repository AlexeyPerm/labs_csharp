using ClassLibraryLab10;
using Lab12_4_list;

namespace Task_1;

class Program
{
    static void Main()
    {
        var myCollection = CreateNewCollection();
        foreach (var item in  myCollection)
        {
            Console.WriteLine(item);
        }
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