using ClassLibraryLab10;

namespace Lab12_4._1;

internal static class Program
{
    private static void Main()
    {
        const int itemCount = 10;

        var myCollection = new Tree<Organisation>();


        for (var i = 0; i < itemCount; i++)
        {
            var temp = RandObjectOrganisation();
            temp.RandomInit();
            myCollection.Add(temp);
        }


        foreach (var item in myCollection.Preorder())
        {
            Console.WriteLine(item);
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
}