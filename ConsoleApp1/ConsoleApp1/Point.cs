namespace ConsoleApp1;

public class Point<T>
{
    public T data;
    public Point<T> next;

    public Point()
    {
        data = default;
        next = null;
    }

    public Point(T data)
    {
        this.data = data;
        next = null;
    }

    public override string ToString()
    {
        return data + " ";
    }
}