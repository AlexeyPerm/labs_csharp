using ClassLibraryLab10;

namespace Lab12_2;

public class Node
{
    public Organisation Data;
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node()
    {
        Data = new Organisation();
        Left = null;
        Right = null;
    }

    /// <summary>
    /// Рандомное заполнение элемента
    /// </summary>
    /// <param name="random">Рандом или не рандом?</param>
    public Node(bool random)
    {
        if (!random) return;
        Data = new Organisation();
        Data.RandomInit();
        Left = null;
        Right = null;
    }

    public Node(Organisation data)
    {
        Data = data;
        Left = null;
        Right = null;
    }

    public override string ToString()
    {
        return Data.ToString();
    }
}