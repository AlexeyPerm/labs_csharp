namespace Lab12_4;

public class HashPoint<T>
{
    private int _key;
    private T _data;
    public HashPoint<T> _next;

    public int Key
    {
        get => _key;
        private set => _key = value;
    }


    public HashPoint(T data)
    {
        _data = data;
        Key = data.GetHashCode() + 777;
        _next = null;
    }


    public override string ToString()
    {
        return $"{Key} + {_data}";
    }
}