using System.Collections;

namespace Lab12_4_list;

public class MyCollection<T> : ICollection<T>
{
    private Node<T> Head { get; set; }
    public int Count { get; private set; }
    public bool IsReadOnly { get; }

    public MyCollection()
    { }

    public MyCollection(int capacity)
    {
        for (var i = 0; i < capacity; i++)
        {
            Add(default); //Заполняем дефолтным значением выбранного типа данных все элементы списка
        }
    }

    public MyCollection(MyCollection<T> c)
    {
        foreach (var elem in c)
        {
            Add(elem);
        }
    }

    public bool IsEmpty => Count == 0;
    

    
    public void CopyTo(T[] array, int arrayIndex)
    {
        ArgumentNullException.ThrowIfNull(array);
        ArgumentOutOfRangeException.ThrowIfNegative(arrayIndex);
        if (arrayIndex > Count)
        {
            throw new ArgumentException("Указанный индекс больше размера списка");
        }

        var index = 0;
        foreach (var item in this)
        {
            array[index++ + arrayIndex] = item;
        }

    }

    /// <summary>
    /// Удалить данные из списка
    /// </summary>
    /// <param name="data">Удалямые данные</param>
    /// <returns>Возвращает булеву переменную</returns>
    public bool Remove(T data)
    {
        if (Count == 0) return false;

        var current = Head;
        Node<T> removedItem = null;
        // Поиск удаляемого элемента
        do
        {
            if (current.data.Equals(data))
            {
                removedItem = current;
                break;
            }

            current = current.Next;
        } while (current != Head);

        if (Count == 1)
        {
            Clear();
            return true;
        }

        if (removedItem == null) return false;

        //Если удаляемый элемент первый в списке
        if (removedItem == Head) Head = Head.Next;
        //магия указателей
        removedItem.Previous.Next = removedItem.Next;
        removedItem.Next.Previous = removedItem.Previous;
        Count--;

        return true;
    }

    /// <summary>
    /// Доблавление новых данных в двусвязный кольцевой список
    /// </summary>
    /// <param name="data">Добавляемые данные</param>
    public void Add(T data)
    {
        var item = new Node<T>(data);
        //Если список пустой, тогда создаётся первый элемент с указателями Next и Previous, указывающими на себя же
        if (Count == 0)

        {
            Head = item;
            Head.Next = item;
            Head.Previous = item;
            Count = 1;
            return;
        }

        item.Previous = Head.Previous; //Head.Previous - указатель на последний элемент списка. Сцепляем его с новым
        item.Next = Head; //item.Next - указатель на головной элемент списк.
        Head.Previous.Next = item; //Head.Previous.Next - в последнем элементе списка указатель Next на новый элемент
        Head.Previous = item; //Указатель головного элемента новый, ставшим последним элемент списка 
        Count++;
    }

    /// <summary>
    /// Очищает список
    /// </summary>
    public void Clear()
    {
        Head = null;
        Count = 0;
    }

    public bool Contains(T data)
    {
        var current = Head;
        do
        {
            if (current.data.Equals(data)) return true;

            current = current.Next;
        } while (current != Head);

        return false;
    }


    // IEnumerator<T> IEnumerable<T>.GetEnumerator()
    // {
    //     return (IEnumerator<T>)GetEnumerator();
    // }
    //
    // public IEnumerator GetEnumerator()
    // {
    //     var current = Head;
    //     for (var i = 0; i < Count; i++)
    //     {
    //         yield return current;
    //         current = current.Next;
    //     }
    // }

    public IEnumerator<T> GetEnumerator()
    {
        var current = Head;
        for (var i = 0; i < Count; i++)
        {
            yield return current.data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)this).GetEnumerator();
    }
}