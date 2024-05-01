
using ClassLibraryLab10;
using ExtMethods;

namespace Lab12_4_tree;

public class MyCollection<T> where T : IComparable
{
    public Node<T> Root { get; set; }


    public void Insert(T newData)
    {
        var newNode = new Node<T> { Data = newData };
        if (Root == null) Root = newNode;
        var current = Root;

        //Пока текущий узел не будет равен null, будет происходить проход по узлам и сравнение новых данных с текущими
        while (current != null)
        {
            if (newNode > current)
            {
                if (current.Right != null)
                {
                    current = current.Right;
                    continue;
                }

                current.Right = newNode;
                continue;
            }

            if (newNode < current)
            {
                if (current.Left != null)
                {
                    current = current.Left;
                    continue;
                }

                current.Left = newNode;
                continue;
            }

            return;
        }
    }

    public void Run(Node<T> root)

    {
        if (Root == null)
        {
            return;
        }

        Run(root.Left);
        Run(root.Right);
    }

    public void ShowTree(Node<T> root)
    {
        if (root == null) return;
        ShowTree(root.Left); //переход к левому поддереву
        Console.WriteLine(root.Data); //печать узла
        ShowTree(root.Right); //переход к правому поддереву
    }
}