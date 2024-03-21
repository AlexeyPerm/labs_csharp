namespace Lab12_1;

public class MyList<T>
{
    private Point<T> _begin;

    public int Length
    {
        get
        {
            Point<T> p = _begin;
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
        _begin = new Point<T>();
        Point<T> p = _begin;
        for (int i = 1; i < size; i++)
        {
            var temp = new Point<T>();
            p._next = temp;
            p = temp;
        }
    }

    public MyList(params T[] arr)
    {
        _begin = new Point<T>();
        Point<T> p = _begin;
        _begin._data = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            var temp = new Point<T>(arr[i]);
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

        Point<T> tmp = _begin;
        while (tmp != null)
        {
            Console.WriteLine(tmp.ToString());
            tmp = tmp._next;
        }
    }
}