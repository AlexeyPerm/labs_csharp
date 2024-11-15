using ClassLibraryLab10;

namespace Lab12_2_new;

using ExtMethods;

#nullable disable
public class BinarySearchTree
{
    public TreeNode Root { get; private set; }

    public BinarySearchTree(BalancedBinaryTree bst)
    {
        //Создаём массив для хранения нод дерева
        var nodesList = new List<Organisation>();
        Run(bst.Root, nodesList);
        foreach (var item in nodesList)
        {
            Insert(item);
        }
    }

    private void Insert(Organisation data)
    {
        Root = Insert(Root, data);
    }

    private TreeNode Insert(TreeNode node, Organisation data)
    {
        if (node == null)
        {
            return new TreeNode(data);
        }

        if (data.Budget < node.Data.Budget)
        {
            node.Left = Insert(node.Left, data);
        }
        else
        {
            node.Right = Insert(node.Right, data);
        }

        return node;
    }

    /// <summary>
    /// Обход дерева сверху вниз
    /// </summary>
    /// <param name="root">Дерево, в котором нужно выполнить обход</param>
    /// <param name="nodes">Коллекция, в которую помещаются узлы дерева</param>
    private static void Run(TreeNode root, List<Organisation> nodes)

    {
        if (root == null)
        {
            return;
        }

        Run(root.Left, nodes);
        nodes.Add(root.Data);
        Run(root.Right, nodes);
    }

    /// <summary>
    /// Печать иерархической структуры дерева 
    /// </summary>
    /// <param name="root">Передаваемое дерево</param>
    public void Print2D(TreeNode root)
    {
        //Передаваемое дерево и базовое значение количества пробелов в отступе слева
        Print2DUtil(root, 0);
    }

    /// <summary>
    /// Вывод на экран дерева
    /// </summary>
    /// <param name="root">Передаваемое дерево</param>
    /// <param name="space">Количество пробелов слева, с которрых начнётся печать</param>
    private static void Print2DUtil(TreeNode root, int space)
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

    public void DeleteTree()
    {
        if (Root == null)
        {
            Console.Clear();
            Console.WriteLine("Дерево не существует");
            return;
        }
        Root = null;
        Console.Clear();
        Console.WriteLine("Удаление дерева прошло успешно");
    }
}