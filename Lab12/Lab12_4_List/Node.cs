namespace Lab12_4_list;

public class Node<T>
{
    public T data;
    public Node<T> Next { get;  set; }
    public Node<T> Previous { get;  set; }
    

    public Node(T data)
    {
        this.data = data;
        Next = Previous = null;
    }

    public override string ToString()
    {
        return data + " ";
    }
}