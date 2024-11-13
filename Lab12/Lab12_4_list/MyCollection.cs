using System.Collections;

namespace Lab12_4_list;

public class MyCollection<T> : ICollection<T>, ICloneable
{
    private Node<T> Head { get; set; }
    public int Count { get; private set; }
    public bool IsReadOnly { get; }

    public bool IsEmpty => Count == 0;
    public virtual T this[int index] => FindIndex(index);

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

    /// <summary>
    /// Поиск элемента в списке
    /// </summary>
    /// <param name="match">Искомый элемент</param>
    /// <returns>Возвращает найденый элемент</returns>
    /// <exception cref="Exception">Список пуст</exception>
    /// <exception cref="ArgumentNullException">Искомый элемент пустой</exception>
    public T Find(T match)
    {
        if (Count == 0) throw new Exception("Список пустой");
        if (match == null) throw new ArgumentNullException(nameof(match), "Нечего искать");
        foreach (var item in this)
        {
            if (item.Equals(match))
            {
                return item;
            }
        }

        return default;
    }


    public void CopyTo(T[] array, int arrayIndex)
    {
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
    /// Множественное удаление данных из списка
    /// </summary>
    /// <param name="arr">Передаваемый массив данных</param>
    public void RemoveMultiple(params T[] arr)
    {
        foreach (var item in arr)
        {
            Remove(item);
        }
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

        //Магия указателей
        item.Previous = Head.Previous; //Head.Previous - указатель на последний элемент списка. Сцепляем его с новым
        item.Next = Head; //item.Next - указатель на головной элемент списк.
        Head.Previous.Next = item; //Head.Previous.Next - в последнем элементе списка указатель Next на новый элемент
        Head.Previous = item; //Указатель головного элемента новый, ставшим последним элемент списка 
        Count++;
    }

    /// <summary>
    /// Множественное добавление элементов в список
    /// </summary>
    /// <param name="arr">Передаваемый массив данных</param>
    public void AddMultiple(params T[] arr)
    {
        foreach (var item in arr)
        {
            Add(item);
        }
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
            if (current.data.Equals(data))
                return true;
            current = current.Next;
        } while (current != Head);

        return false;
    }

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

    public object Clone()
    {
        var newCollection = new MyCollection<T>();
        foreach (var item in this)
        {
            newCollection.Add(item);
        }

        return newCollection;
    }

    public object ShallowCopy() => (MyCollection<T>)MemberwiseClone();

    private T FindIndex(int index)
    {
        if (Count == 0) throw new Exception("Список пустой");
        if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index), "Неправильный индекс");

        var current = Head;
        for (var i = 0; i < index; i++)
        {
            current = current.Next;
        }

        return current.data;
    }
}