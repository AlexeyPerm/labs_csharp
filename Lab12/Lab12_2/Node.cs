using ClassLibraryLab10;

namespace Lab12_2;

public class Node
{
    public Organisation _data;
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node()
    {
        _data = new Organisation();
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
        _data = new Organisation();
        _data.RandomInit();
        Left = null;
        Right = null;
    }

    public Node(Organisation data)
    {
        _data = data;
        Left = null;
        Right = null;
    }

    public override string ToString()
    {
        return _data.ToString();
    }
}