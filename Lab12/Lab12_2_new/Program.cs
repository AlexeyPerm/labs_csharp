namespace Lab12_2_new;

using ClassLibraryLab10;
using ExtMethods;
static class Program
{
    private static void Main()
    {
        const int arrSize = 6;
        var organisations = RandomOrganisations(arrSize);

        //Создаём сбалансированное дерево.
        var balancedTree = new BalancedBinaryTree(organisations);
        balancedTree.Print2D(balancedTree.Root);
        //var bst = new BinarySearchTree(balancedTree);
        //bst.Print2D(bst.Root);

        Console.WriteLine(balancedTree.NodesCount(balancedTree.Root));
        Console.ReadLine();
    }


    private static Organisation[] RandomOrganisations(int arrSize)
    {
        var tempListOfOrganisations = new Organisation[arrSize];
        for (int i = 0; i < arrSize; i++)
        {
            var tmp = RandObjectOrganisation();
            tmp.RandomInit();
            tempListOfOrganisations[i] = tmp;
        }

        return tempListOfOrganisations;
    }

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