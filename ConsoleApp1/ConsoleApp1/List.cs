using System.Collections;
using System.Security.Cryptography;

namespace ConsoleApp1;

public class List<T> : IEnumerable<T>
{
    class MyNumerator<T> : IEnumerator<T>
    {
        private Point<T> begin;
        private Point<T> current;

        public MyNumerator(List<T> collection)
        {
            begin = collection._begin;
            current = null;
        }

        public bool MoveNext()
        {
            current = current == null ? begin : current.next;
            return current != null;
        }

        public void Reset() => current = begin;

        T IEnumerator<T>.Current => current.data;
        object IEnumerator.Current => current.data;


        public void Dispose()
        { }
    }


    private Point<T> _begin;

    public int Length
    {
        get
        {
            if (_begin == null) return 0;
            var p = _begin;
            var length = 0;
            while (p != null)
            {
                p = p.next;
                length++;
            }

            return length;
        }
    }

    public List()
    { }

    public List(int size)
    {
        _begin = new Point<T>();
        var pointer = _begin;

        for (var i = 1; i < size; i++)
        {
            var temp = new Point<T>();
            pointer.next = temp;
            pointer = temp;
        }
    }

    public List(params T[] array)
    {
        _begin = new Point<T>(array[0]);
        var pointer = _begin;
        for (var i = 1; i < array.Length; i++)
        {
            var temp = new Point<T>(array[i]);
            pointer.next = temp;
            pointer = temp;
        }
    }

    public void PrintList()
    {
        if (_begin == null) Console.WriteLine("Пустой список");
        var pointer = _begin;
        while (pointer != null)
        {
            Console.WriteLine(pointer.data);
            pointer = pointer.next;
        }

        Console.WriteLine();
    }


    public void AddPointToBegin(T data)
    {
        var temp = new Point<T>(data);
        if (_begin == null)
        {
            _begin = temp;
            return;
        }

        temp.next = _begin;
        _begin = temp;
    }

    public void RemovePoint(int number)
    {
        if (_begin == null)
        {
            return;
        }

        if (number > Length)
        {
            Console.WriteLine("Номер элемента больше длины списка");
            return;
        }

        if (_begin.next == null)
        {
            _begin = null;
            return;
        }

        if (number == 1)
        {
            _begin = _begin.next;
            return;
        }

        var pointer = _begin;
        for (int i = 1; i < number - 1; i++)
        {
            pointer = pointer.next;
        }

        pointer.next = pointer.next.next;
    }

    #region Методы для нумератора

    public IEnumerator<T> GetEnumerator()
    {
        Point<T> current = _begin;
        while (current != null)
        {
            yield return current.data;
            current = current.next;
        }
    }

    //public IEnumerator<T> GetEnumerator() => new MyNumerator<T>(this);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    #endregion
}