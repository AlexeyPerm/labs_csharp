namespace Lab12_4_tree;

public class Node<T>
{
    private T _data;
    public Node<T> Left { get; private set; }
    public Node<T> Right { get; private set; }

    public T Data { get; }

    public Node()
    {
        Data = default;
        Left = null;
        Right = null;
    }


    public Node(T data)
    {
        Data = data;
        Left = null;
        Right = null;
    }

    public override string ToString()
    {
        return Data.ToString();
    }
}