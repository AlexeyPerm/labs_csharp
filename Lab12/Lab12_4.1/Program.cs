using ClassLibraryLab10;

namespace Lab12_4._1;

internal static class Program
{
    private static void Main()
    {
        var tree = new Tree<int>();
        tree.AddRange(4, 5, -10, 53, 56, 45, 2, 566);
        tree.Find(3);




        // foreach (var item in tree.Preorder())
        // {
        //     Console.Write(item + " ");
        // }
        //
        // Console.WriteLine();
        //
        //
        //
        // foreach (var item in tree.Postorder())
        // {
        //     Console.Write(item + " ");
        // }
        //
        // Console.WriteLine();
        //
        //
        //
        // foreach (var item in tree.Inorder())
        // {
        //     Console.Write(item + " ");
        // }
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