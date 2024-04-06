namespace Lab12_1;

using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    /* //Замена на yield
    class MyNumerator<T> : IEnumerator<T>
    {
        private Node<T> first;
        private Node<T> current;

        public MyNumerator(DoublyLinkedList<T> collection)
        {
            first = collection.First;
            current = null;
        }

        public void Dispose()
        { }

        public bool MoveNext()
        {
            current = current == null ? first : current.Next;
            return current != null;
        }

        public void Reset()
        {
            current = first;
        }

        public T Current => current.Data;
        object IEnumerator.Current => current;
    }
    */
    private Node<T> First { get; set; }
    private Node<T> CurrentNode { get; set; }
    private Node<T> Last { get; set; }

    public int Count { get; private set; }

    //Метод проверки на пустоту
    public bool IsEmpty => Count == 0;

    public DoublyLinkedList()
    {
        Count = 0;
        First = CurrentNode = Last = null;
    }

    /// <summary>
    /// Добавление элемента в начало
    /// </summary>
    /// <param name="data">Добавляемых элемент</param>
    public void Push_Front(T data)
    {
        var node = new Node<T>(data);
        var temp = First;
        // В новом элементе указатель на следующий элемент указывает на первый элемент коллекции, тем самым
        // новый элемент сам становится первым элементом.
        node.Next = temp;
        First = node;
        if (Count == 0)
        {
            Last = First;
        }
        else
        {
            temp.Prev = node;
        }

        Count++;
    }

    /// <summary>
    /// Удаление первого элемента коллекции
    /// </summary>
    public void PopFront()
    {
        if (IsEmpty)
        {
            Console.WriteLine("Коллекция пустая");
            return;
        }

        if (First.Next != null)
        {
            First.Next.Prev = null;
        }

        First = First.Next;
        Count--;
    }

    /// <summary>
    /// Удаление последнего элемента коллекции
    /// </summary>
    public void PopBack()
    {
        if (IsEmpty)
        {
            Console.WriteLine("Коллекция пустая");
            return;
        }

        Count--;
        Last = Last.Prev;
        Last.Next = null;
    }

    /// <summary>
    /// Вывод на экран элементов коллекции
    /// </summary>
    public void PrintLinkedList()
    {
        if (IsEmpty)
        {
            Console.WriteLine("Коллекция пустая");
            return;
        }

        CurrentNode = First;
        while (CurrentNode != null)
        {
            Console.WriteLine(CurrentNode.ToString());
            CurrentNode = CurrentNode.Next;
        }
    }

    /// <summary>
    /// Удаление элемента по его порядковому номеру
    /// </summary>
    /// <param name="index">Порядковый номер удаляемого элемента</param>
    public void RemoveElement(int index)
    {
        if (IsEmpty)
        {
            Console.WriteLine("Коллекция пустая");
            return;
        }

        if (index > Count || index <= 0)
        {
            Console.WriteLine("Ошибка");
            return;
        }

        if (index == 1)
        {
            PopFront();
            return;
        }

        if (index == Count)
        {
            PopBack();
            return;
        }

        Node<T> node = First;
        for (var i = 1; i < index - 1; i++)
        {
            node = node.Next;
        }

        node.Next.Next.Prev = node;
        node.Next = node.Next.Next;
        Count--;
    }

    /// <summary>
    /// Проверяет, существует ли в коллекции заданный элемент
    /// </summary>
    /// <param name="data">Искомый элемент</param>
    /// <returns>Возвращает значение, указывающее, существует ли указанный элемент в коллекции</returns>
    public bool Contains(T data)
    {
        Node<T> current = First;
        while (current != null)
        {
            if (current.Data.Equals(data))
                return true;
            current = current.Next;
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T> current = First;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        //throw new NotImplementedException();
        return GetEnumerator();
    }
}