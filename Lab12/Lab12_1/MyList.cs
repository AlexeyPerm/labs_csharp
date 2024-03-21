namespace Lab12_1;

public class MyList<T>
{
    private Node<T> _begin;

    public int Length
    {
        get
        {
            Node<T> p = _begin;
            int len = 0;
            while (p != null)
            {
                p = p._next;
                len++;
            }

            return len;
        }
    }

    public MyList(uint size)
    {
        _begin = new Node<T>();
        Node<T> p = _begin;
        for (int i = 1; i < size; i++)
        {
            var temp = new Node<T>();
            p._next = temp;
            p = temp;
        }
    }

    public MyList(params T[] arr)
    {
        _begin = new Node<T>();
        Node<T> p = _begin;
        _begin._data = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            var temp = new Node<T>(arr[i]);
            p._next = temp;
            p = temp;
        }
    }

    public void Print()
    {
        if (_begin == null)
        {
            Console.WriteLine("Пустой список");
            return;
        }

        Node<T> tmp = _begin;
        while (tmp != null)
        {
            Console.WriteLine(tmp.ToString());
            tmp = tmp._next;
        }
    }

    public void AddBack(T data)
    {
        Node<T> dt = new Node<T>(data);
        if (_begin == null)
        {
            _begin = dt;
            return;
        }

        Node<T> temp = new Node<T>();
        temp = _begin;
        while (temp._next != null)
        {
            temp = temp._next;
        }

        temp._next = dt;
    }

    public void AddToBegin(T data)
    {
        Node<T> temp = new Node<T>(data);
        if (_begin == null)
        {
            _begin = temp;
            return;
        }

        temp._next = _begin;
        _begin = temp;
    }

    public void RemoveNode(int index)
    {
        if (_begin == null)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        if (index > Length)
        {
            Console.WriteLine("Ошибка. Индекс больше размера массива");
            return;
        }

        if (_begin._next == null)
        {
            _begin = null;
            return;
        }

        Node<T> temp = _begin;
        for (int i = 0; i < index - 1; i++)
        {
            temp = temp._next;
        }

        temp._next = temp._next._next;
    }

    ~MyList()
    { }
}