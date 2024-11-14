namespace Lab12_1;

using ClassLibraryLab10;

public class Node
{
    public Organisation Data { get; }
    public Node Next { get; set; } //указатель на следующую  ячейку данных
    public Node Prev { get; set; } //указатель на предыдущую ячейку данных

    public Node(Organisation data)
    {
        Data = data;
    }

    public override string ToString()
    {
        return $"{Data}";
    }
}