using ClassLibraryLab10;
using ExtMethods;

namespace Lab12_2;

class Program
{
    private static void Main()
    {
        const int variantNumber = 549 % 25 - 1; //номер варианта 23
        Console.WriteLine($"Номер варианта = {variantNumber}\n");

        const int treeSize = 6;
        var firstElement = RandObjectOrganisation();
        firstElement.RandomInit();
        Node tree = First(firstElement);
        var idealTree = IdealTree(treeSize, tree);
        
        Node bst = ConvertToBST(idealTree);
        //Print2D(bst);
        DeleteTree(ref bst);
        Print2D(bst);
        
        
    }

    private static int NodesCount(Node root)
    {
        if (root == null)
        {
            return 0;
        }

        return NodesCount(root.Left) + NodesCount(root.Right) + 1;
    }

    /// <summary>
    /// Построение идеально сбалансированного дерева
    /// </summary>
    /// <param name="size">Размер создаваемого дерева</param>
    /// <param name="root">Корень дерева</param>
    /// <returns>Возвращает построенное идеально сбалансированное дерево</returns>
    private static Node IdealTree(int size, Node root)
    {
        if (size == 0)
        {
            return root;
        }

        var nLeft = size / 2;
        var nRight = size - nLeft - 1;
        var data = RandObjectOrganisation();
        data.RandomInit();

        Node r = new Node(data);
        r.Left = IdealTree(nLeft, r.Left);
        r.Right = IdealTree(nRight, r.Right);
        return r;
    }


    /// <summary>
    /// Формирование дерева поиска
    /// </summary>
    /// <param name="nodes">Передаваемая ссылка на дерево</param>
    private static Node CreateBST(List<Node> nodes, int start, int end)
    {
        if (start > end)
        {
            return null;
        }

        int mid = (start + end) / 2;
        Node root = nodes[mid];
        root.Left = CreateBST(nodes, start, mid - 1);
        root.Right = CreateBST(nodes, mid + 1, end);
        return root;
    }

    /// <summary>
    /// Конвертация бинарного дерева в дерево поиска
    /// </summary>
    /// <param name="root">Передаваемое дерево</param>
    /// <returns>Возвращает ссылку на построенное дерево поиска</returns>
    private static Node ConvertToBST(Node root)
    {
        List<Node> nodes = new List<Node>();
        Run(root, nodes);
        nodes.Sort((a, b) => a.Data.Budget - b.Data.Budget);
        return CreateBST(nodes, 0, nodes.Count - 1);
    }


    /// <summary>
    /// Вывод на экран дерева
    /// </summary>
    /// <param name="root">Передаваемое дерево</param>
    private static void Print2D(Node root)
    {
        //Передаваемое дерево и базовое значение количества пробелов в отступе слева
        Print2DUtil(root, 0);
    }

    /// <summary>
    /// Вывод на экран дерева
    /// </summary>
    /// <param name="root">Передаваемое дерево</param>
    /// <param name="space">Количество пробелов слева, с которрых начнётся печать</param>
    private static void Print2DUtil(Node root, int space)
    {
        if (root == null)
        {
            return;
        }

        space += 10; // Расстояние между уровнями
        Print2DUtil(root.Right, space); // Обработка левых листьев

        root.Data.PrintInTree(space);

        Print2DUtil(root.Left, space); // Обработка левых листьев
    }

    /// <summary>
    /// Функция для обхода дерева обходом слева направо
    /// </summary>
    /// <param name="root">Дерево, в котором нужно выполнить обход</param>
    private static void ShowTree(Node root)
    {
        if (root == null) return;
        ShowTree(root.Left); //переход к левому поддереву
        Console.WriteLine(root.Data); //печать узла
        ShowTree(root.Right); //переход к правому поддереву
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
    /// Обход дерева сверху вниз
    /// </summary>
    /// <param name="root">Дерево, в котором нужно выполнить обход</param>
    /// <param name="nodes">Коллекция, в которую помещаются узлы дерева</param>
    private static void Run(Node root, List<Node> nodes)

    {
        if (root == null)
        {
            return;
        }

        Run(root.Left, nodes);
        nodes.Add(root);
        Run(root.Right, nodes);
    }

    /// <summary>
    /// Формирование первого элемента дерева.
    /// </summary>
    /// <param name="data">Данные, хранящиеся в узле</param>
    /// <returns></returns>
    static Node First(Organisation data)
    {
        Node p = new Node(data);
        return p;
    }

    private static void DeleteTree(ref Node root)
    {
        root = null!;
    }
}