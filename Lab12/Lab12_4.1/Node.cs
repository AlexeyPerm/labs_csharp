using ClassLibraryLab10;

namespace Lab12_4._1;

public class Node<T> : IComparable<T> where T : Organisation
{
    public T Data { get; }
    public Node<T> Left { get; private set; }
    public Node<T> Right { get; private set; }

    public Node(T data)
    {
        Data = data;
    }

    public Node(T data, Node<T> left, Node<T> right)
    {
        Data = data;
        Left = left;
        Right = right;
    }


    public void Add(T data)
    {
        var node = new Node<T>(data);
        if (node.Data.CompareTo(Data) == -1)
        {
            if (Left == null) Left = node;
            else Left.Add(data);
        }
        else
        {
            if (Right == null) Right = node;
            else Right.Add(data);
        }
    }

    public int CompareTo(T other)
    {
        return string.CompareOrdinal(Data.OrgName, other.OrgName);
    }

    public override string ToString() => Data.ToString();
}