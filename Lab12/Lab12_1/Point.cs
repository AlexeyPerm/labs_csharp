using System.Data;

namespace Lab12_1;

public class Point<T>
{
    public T _data;
    public Point<T> _next;
    public Point<T> _prev;

    public Point()
    {
        _data = default;
        _next = null;
        _prev = null;
    }

    public Point(T data)
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