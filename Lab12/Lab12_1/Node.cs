namespace Lab12_1;

public class Node<T>
{
    public T Data { get; private set; }
    public Node<T> Next { get; set; } //указатель на следующую  ячейку данных
    public Node<T> Prev { get; set; } //указатель на предыдущую ячейку данных

    public Node(T data)
    {
        Data = data;
    }

    public override string ToString()
    {
        return $"{Data}";
    }
}