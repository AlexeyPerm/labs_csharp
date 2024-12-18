﻿namespace Lab12_1;

using ClassLibraryLab10;
using System.Collections;

public class DoublyLinkedList : IEnumerable
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
            current = current == null ? Reset() : current.Next;
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

    private Node First { get; set; } //Первый элемент списка
    private Node CurrentNode { get; set; } //Текущие элемент списка
    private Node Last { get; set; } //Последний элемент списка

    public int Count { get; private set; } //Количество элементов в списке

    public bool IsEmpty => Count == 0; //Метод проверки на пустоту

    public DoublyLinkedList()
    {
        Count = 0;
        First = CurrentNode = Last = null;
    }

    public DoublyLinkedList(params Organisation[] arr)
    {
        foreach (var item in arr)
        {
            PushBack(item);
        }
    }

    /// <summary>
    /// Удаление списка из памяти
    /// </summary>
    public void Clear()
    {
        First = CurrentNode = Last = null;
        Count = 0;
    }

    /// <summary>
    /// Добавление элемента в начало списка
    /// </summary>
    /// <param name="data">Добавляемых элемент</param>
    public void PushFront(Organisation data)
    {
        Node newNode = new Node(data);
        Node tempFirstNode = First;
        // В новом элементе указатель на следующий элемент указывает на первый элемент коллекции, тем самым
        // новый элемент сам становится первым элементом.
        newNode.Next = tempFirstNode;
        First = newNode;
        if (Count == 0)
        {
            Last = First;
        }
        else
        {
            tempFirstNode.Prev = newNode;
        }

        Count++;
        Console.Clear();
        Console.WriteLine("Элемент успешно добавлен в начало списка");
    }

    /// <summary>
    /// Добавление элемента в конец списка
    /// </summary>
    /// <param name="data">Добавляемых элемент</param>
    public void PushBack(Organisation data)
    {
        var newNode = new Node(data);
        var tempLastNode = Last;
        // В новом элементе указатель на предыдущий элемент указывает на последний элемент коллекции, тем самым
        // новый элемент сам становится последним элементом.
        newNode.Prev = tempLastNode;
        Last = newNode;
        if (Count == 0)
        {
            First = Last;
        }
        else
        {
            tempLastNode.Next = newNode;
        }

        Count++;

        Console.Clear();
        Console.WriteLine("Элемент успешно добавлен в конец списка");
    }

    /// <summary>
    /// Удаление первого элемента коллекции
    /// </summary>
    public void PopFront()
    {
        if (IsEmpty)
        {
            Console.Clear();
            Console.WriteLine("Коллекция пустая");
            return;
        }

        if (First.Next != null)
        {
            First.Next.Prev = null; //Удаление указателя следующего элемента на предыдущий элемент 
        }

        First = First.Next;
        Count--;

        Console.Clear();
        Console.WriteLine("Элемент успешно удалён из начала списка");
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

        Console.Clear();
        Console.WriteLine("Элемент успешно удалён из конца списка");
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

        Console.Clear();
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
            throw new ArgumentOutOfRangeException(nameof(index));
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

        Node node = First;
        for (var i = 1; i < index - 1; i++)
        {
            node = node.Next;
        }

        node.Next.Next.Prev = node;
        node.Next = node.Next.Next;
        Count--;

        Console.Clear();
        Console.WriteLine($"Элемент с номером {index} успешно удалён");
    }

    /// <summary>
    /// Проверяет, существует ли в коллекции заданный элемент
    /// </summary>
    /// <param name="data">Искомый элемент</param>
    /// <returns>Возвращает значение, указывающее, существует ли указанный элемент в коллекции</returns>
    public bool Contains(Organisation data)
    {
        Node current = First;
        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                return true;
            }

            current = current.Next;
        } //end of while

        return false;
    }

    /// <summary>
    /// Удалить из списка элемент с указанным названием организации
    /// </summary>
    /// <param name="findedItem">Удаляемый элемент</param>
    private void RemoveElementByOrgName(Organisation findedItem)
    {
        var count = 1; //Номер удаляемого элемента в списке
        foreach (var item in this)
        {
            if (item.OrgName == findedItem.OrgName)
            {
                Console.WriteLine($"Элемент {findedItem.OrgName} найден! Удаляем");
                RemoveElement(count);
                break;
            }

            count++;
        } //end of foreach

        Console.Clear();
        Console.WriteLine($"Элемент в названием организации {findedItem.OrgName} успешно удалён");
    }

    public IEnumerator<Organisation> GetEnumerator()
    {
        Node current = First;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}