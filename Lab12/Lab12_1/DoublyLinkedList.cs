namespace Lab12_1;

public class DoublyLinkedList<T>
{
    private Node<T> First { get; set; }
    private Node<T> Current { get; set; }
    private Node<T> Last { get; set; }
    private uint Count { get; set; }

    //Метод проверки на пустоту
    public bool IsEmpty => Count == 0;

    public DoublyLinkedList()
    {
        Count = 0;
        First = Current = Last = null;
    }

    /// <summary>
    /// Добавление ячейки в начало коллекции
    /// </summary>
    /// <param name="newElement">Добавляемая ячейка</param>
    public void Push_Front(T newElement)
    {
        var newNode = new Node<T>(newElement);
        //указатель добавляемой ячейкина следующий элемент указывает на существующий стартовый элемент коллекции
        newNode.Next = First;
        //Стартовый элемент коллекции заменяется на добавляемый элемент
        First = newNode;
        //Указатель второй по счёту ячейки указывает на предыдущий элемент. 
        newNode.Next.Prev = First;
        Count++;
    }

    /// <summary>
    /// Удаление первого элемента коллекции
    /// </summary>
    public void Pop_Front()
    {
        if (First == null)
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
}