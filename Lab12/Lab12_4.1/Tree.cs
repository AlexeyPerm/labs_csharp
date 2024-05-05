using ClassLibraryLab10;
using ExtMethods;

namespace Lab12_4._1;

public class Tree<T> where T : IComparable<T>, IComparable, IEnumerable<T>
{
    public Node<T> Root { get; private set; }
    public int Count { get; private set; }


    public Tree()
    { }

    public bool Find(T item)
    {
        if (Root == null) throw new ArgumentNullException("Дерево пустое");

        Node<T> current = Root;
        if (item.CompareTo(current) != 0) return false;
        Console.WriteLine("Элемент найден");
        return true;
    }


    #region Добавление в дерево

    public void Add(T data)
    {
        if (Root == null)
        {
            Root = new Node<T>(data);
            Count++;
            return;
        }

        Root.Add(data);
        Count++;
    }

    public void AddRange(params T[] data)
    {
        if (data.Length == 0) return;
        foreach (var item in data)
        {
            Add(item);
        }
    }

    #endregion

    #region Обход дерева

    /// <summary>
    /// Публичный метод-обёртка для префиксного обхода дерева (сверху вниз).
    /// </summary>
    /// <returns>Возвращает список данных из каждого узла дерева.</returns>
    public List<T> Preorder()
    {
        //Если корень дерева null, то возвращаем пустой список, иначе вернётся не пустой список
        return Root == null ? [] : Preorder(Root);
    }

    /// <summary>
    /// Префиксный обход дерева (сверху вниз; копирование). Данные -> Левое поддерево -> Правое поддерево.
    /// Метод статический, так как не обращается к данным экземпляров класса.
    /// </summary>
    /// <param name="node">Узел дерева, из которого данные добавятся в список</param>
    /// <returns>Возвращает список данных из каждого узла дерева.</returns>
    private static List<T> Preorder(Node<T> node)
    {
        var list = new List<T>();
        if (node == null) return list;
        list.Add(node.Data);
        //Так как функция Preorder возвращает коллекцию элементов, то нужно в коллекцию list добавлять Range.
        if (node.Left != null) list.AddRange(Preorder(node.Left));
        if (node.Right != null) list.AddRange(Preorder(node.Right));
        return list;
    }

    /// <summary>
    /// Публичный метод-обёртка для постфиксного обхода дерева (снизу вверх).
    /// </summary>
    /// <returns>Возвращает список данных из каждого узла дерева.</returns>
    public List<T> Postorder()
    {
        //Если корень дерева null, то возвращаем пустой список, иначе вернётся не пустой список
        return Root == null ? [] : Postorder(Root);
    }

    /// <summary>
    /// Постфиксный обход дерева (снизу вверх; удаление)
    /// Метод статический, так как не обращается к данным экземпляров класса.
    /// </summary>
    /// <param name="node">Узел дерева, из которого данные добавятся в список</param>
    /// <returns>Возвращает список данных из каждого узла дерева.</returns>
    private static List<T> Postorder(Node<T> node)
    {
        var list = new List<T>();
        if (node == null) return list;
        //Так как функция Preorder возвращает коллекцию элементов, то нужно в коллекцию list добавлять Range.
        if (node.Left != null) list.AddRange(Postorder(node.Left));
        if (node.Right != null) list.AddRange(Postorder(node.Right));
        list.Add(node.Data);
        return list;
    }

    /// <summary>
    /// Публичный метод-обёртка для инфиксного обхода дерева (слева направо).
    /// </summary>
    /// <returns>Возвращает список данных из каждого узла дерева.</returns>
    public List<T> Inorder()
    {
        //Если корень дерева null, то возвращаем пустой список, иначе вернётся не пустой список
        return Root == null ? [] : Inorder(Root);
    }

    /// <summary>
    /// Инфиксный обход дерева (слева направо; сортировка).
    /// Метод статический, так как не обращается к данным экземпляров класса.
    /// </summary>
    /// <param name="node">Узел дерева, из которого данные добавятся в список</param>
    /// <returns>Возвращает список данных из каждого узла дерева.</returns>
    private static List<T> Inorder(Node<T> node)
    {
        var list = new List<T>();
        if (node == null) return list;
        //Так как функция Inorder возвращает коллекцию элементов, то нужно в коллекцию list добавлять Range.
        if (node.Left != null) list.AddRange(Inorder(node.Left));
        list.Add(node.Data);
        if (node.Right != null) list.AddRange(Inorder(node.Right));
        return list;
    }

    #endregion


    
    
    
    
    
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
}