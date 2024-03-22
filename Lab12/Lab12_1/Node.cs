namespace Lab12_1;

public class Node<T>
{
    private T Data { get; set; }
    public Node<T> Next { get; set; } //указатель на следующую  ячейку данных
    public Node<T> Prev { get; set; } //указатель на предыдущую ячейку данных

    public Node(T data)
    {
        Data = data;
    }
}