using ClassLibraryLab10;
using ExtMethods;

namespace Lab12_2_new;
#nullable disable

/// <summary>
/// Класс, который преобразовываем бинарное дерево в сбалансированное бинарное дерево
/// </summary>
public class BalancedBinaryTree
{
    public TreeNode Root { get; private set; }
    public int CountNodes { get; private set; } //счётчик листьев дерева

    /// <summary>
    /// Конструктор, в который нужно передать массив из элементов класса Organisation. 
    /// </summary>
    /// <param name="orgArray">Массив из элементов класса Organisation</param>
    public BalancedBinaryTree(Organisation[] orgArray)
    {
        CountNodes = orgArray.Length;
        const int startElement = 0;
        var endElement = orgArray.Length - 1;
        Root = BuildBalancedTree(orgArray, startElement, endElement);
    }

    /// <summary>
    /// Метод, создающий сбалансированное бинарное дерево
    /// </summary>
    /// <param name="orgArray">Массив из элементов класса Organisation</param>
    /// <param name="start">Стартовая позиция в массиве, с которой будут помещаться элементы в дерево</param>
    /// <param name="end">Конечная позиция в массиве, с которой будут помещаться элементы в дерево</param>
    /// <returns></returns>
    private TreeNode BuildBalancedTree(Organisation[] orgArray, int start, int end)
    {
        if (start > end) return null;

        var mid = (start + end) / 2;
        var node = new TreeNode(orgArray[mid]);

        node.Left = BuildBalancedTree(orgArray, start, mid - 1);
        node.Right = BuildBalancedTree(orgArray, mid + 1, end);

        return node;
    }

    //Обход слева направо
    public void Print(TreeNode node)
    {
        // Пример обработки: вывод значений
        if (node == null) return;
        Print(node.Left);
        Console.WriteLine(" " + node.Data);
        Print(node.Right);
    }

    /// <summary>
    /// Печать иерархической структуры дерева 
    /// </summary>
    /// <param name="root">Передаваемое дерево</param>
    public void Print2D(TreeNode root)
    {
        //Передаваемое дерево и базовое значение количества пробелов в отступе слева
        const int spaces = 0;
        Print2DUtil(root, spaces);
    }

    /// <summary>
    /// Вывод на экран дерева
    /// </summary>
    /// <param name="root">Передаваемое дерево</param>
    /// <param name="space">Количество пробелов слева, с которрых начнётся печать</param>
    private void Print2DUtil(TreeNode root, int space)
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