using System.Data;

namespace Lab12_1;

public class Node<T>
{
    public T _data;
    public Node<T> _next;
    public Node<T> _prev;

    public Node()
    {
        _data = default;
        _next = null;
        _prev = null;
    }

    public Node(T data)
    {
        _data = data;
        _next = null;
        _prev = null;
    }

    public override string ToString()
    {
        return _data + " ";
    }
}