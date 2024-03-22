// namespace Lab12_1;
//
// public class MyList<T>
// {
//     private Node<T> _begin;
//
//     public int Length
//     {
//         get
//         {
//             Node<T> p = _begin;
//             int len = 0;
//             while (p != null)
//             {
//                 p = p._next;
//                 len++;
//             }
//
//             return len;
//         }
//     }
//
//     public MyList(uint size)
//     {
//         _begin = new Node<T>();
//         Node<T> currentNode = _begin;
//         for (int i = 1; i < size; i++)
//         {
//             var newNode = new Node<T>();
//             currentNode._next = newNode;
//             currentNode = newNode;
//         }
//     }
//
//     public MyList(params T[] arr)
//     {
//         _begin = new Node<T>();
//         Node<T> currentNode = _begin;
//         _begin._data = arr[0];
//         for (int i = 1; i < arr.Length; i++)
//         {
//             var newNode = new Node<T>(arr[i]);
//             currentNode._next = newNode;
//             currentNode = newNode;
//         }
//     }
//
//     public void Print()
//     {
//         if (_begin == null)
//         {
//             Console.WriteLine("Пустой список");
//             return;
//         }
//
//         Node<T> tmp = _begin;
//         while (tmp != null)
//         {
//             Console.WriteLine(tmp.ToString());
//             tmp = tmp._next;
//         }
//     }
//
//     public void AddBack(T data)
//     {
//         Node<T> dt = new Node<T>(data);
//         if (_begin == null)
//         {
//             _begin = dt;
//             return;
//         }
//
//         Node<T> currentNode = _begin;
//
//         while (currentNode._next != null)
//         {
//             currentNode = currentNode._next;
//         }
//
//         currentNode._next = dt;
//     }
//
//     public void AddToBegin(T data)
//     {
//         Node<T> currentNode = new Node<T>(data);
//         if (_begin == null)
//         {
//             _begin = currentNode;
//             return;
//         }
//
//         currentNode._next = _begin;
//         _begin = currentNode;
//     }
//
//     public void RemoveNode(int index)
//     {
//         if (_begin == null)
//         {
//             Console.WriteLine("Список пуст");
//             return;
//         }
//
//         if (index > Length)
//         {
//             Console.WriteLine("Ошибка. Индекс больше размера массива");
//             return;
//         }
//
//         if (_begin._next == null)
//         {
//             _begin = null;
//             return;
//         }
//
//         Node<T> currentNode = _begin;
//         for (int i = 0; i < index - 1; i++)
//         {
//             currentNode = currentNode._next;
//         }
//
//         currentNode._next = currentNode._next._next;
//     }
//
//     ~MyList()
//     { }
// }