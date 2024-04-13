using System.Runtime.InteropServices.JavaScript;
using ClassLibraryLab10;
using ExtMethods;

namespace Lab12_2;

class Program
{
    private static void Main()
    {
        const int variantNumber = 549 % 25 - 1; //номер варианта 23
        Console.WriteLine($"Номер варианта = {variantNumber}\n");

        const int treeSize = 17;
        var firstElement = RandObjectOrganisation();
        firstElement.RandomInit();
        Node tree = First(firstElement);
        var idealTree = IdealTree(treeSize, tree);
        var bstTree = CreateBST(idealTree);

        Print2D(bstTree);
    }


    /// <summary>
    /// Построение идеально сбалансированного дерева
    /// </summary>
    /// <param name="size">Размер создаваемого дерева</param>
    /// <param name="root">Корень дерева</param>
    /// <returns></returns>
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


    static int NodesCount(Node root)
    {
        if (root == null)
        {
            return 0;
        }

        return NodesCount(root.Left) + NodesCount(root.Right) + 1;
    }


    static void ArrayToBst(Organisation[] arr, Node tree)
    {
        int middle = arr.Length / 2;
        tree = new Node(arr[middle]);

        
        
    }
    
    static void binaryTreeToBST(Node root)
    {
        if (root == null)
        {
            return;
        }

        //Количество узлов в дереве
        int n = NodesCount(root);
        Organisation[] arr = new Organisation[n];
        Array.Sort(arr);

        // Copy array elements back to Binary Tree
        ArrayToBst(arr, root);
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
    ///Функция для обхода дерева сниву вверх
    /// </summary>
    /// <param name="root">Дерево, в котором нужно выполнить обход</param>
    private static void RunBottomToTop(Node root)
    {
        if (root != null)
        {
            Run(root.Left);
            Run(root.Right);
            Console.WriteLine(root.Data);
        }
    }


    /// <summary>
    /// Добавление узла в дерево
    /// </summary>
    /// <param name="root">Передаваемый корень дерева</param>
    /// <param name="newData">Добавляемые данные</param>
    /// <returns></returns>
    private static void Add(Node root, Organisation newData)
    {
        //Новой переменной p назначаем адрес дерева, чтобы все манипуляции продожлать выполнять с ней, а не root
        Node currentNode = root;
        Node tempNode = null;

        //флаг для проверки существования элемента newData в дереве
        var exist = false;
        while (currentNode != null && !exist)
        {
            tempNode = currentNode;
            //элемент уже существует
            if (newData.OrgName == currentNode.Data.OrgName)
            {
                return;
            }

            if (newData.Budget < tempNode.Data.Budget)
            {
                currentNode = currentNode.Left; //пойти в левое поддерево
            }
            else
            {
                currentNode = currentNode.Right; //пойти в правое поддерево
            }
        }

        //создаём узел
        Node NewPoint = new Node(newData); //выделили память
        // если бюджет организации newData < r, то добавляем его в левое поддерево
        if (newData.Budget < tempNode.Data.Budget)
        {
            tempNode.Left = NewPoint;
        }
        // если newData > r, то добавляем его в правое поддерево
        else
        {
            tempNode.Right = NewPoint;
        }
    }


    /// <summary>
    /// Обход дерева сверху вниз
    /// </summary>
    /// <param name="root">Дерево, в котором нужно выполнить обход</param>
    private static void Run(Node root)

    {
        if (root != null)
        {
            Run(root.Left); //переход к левому поддереву
            Add(root, root.Data);
            Run(root.Right); //переход к правому поддереву
        }
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
}