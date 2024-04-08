using ClassLibraryLab10;

namespace Lab12_2;

public class NodeTree
{
    private Organisation _data;
    private NodeTree _left;
    private NodeTree _right;

    public NodeTree()
    {
        _data = new Organisation();
        _left = null;
        _right = null;
    }

    /// <summary>
    /// Рандомное заполнение элемента
    /// </summary>
    /// <param name="random">Рандом или не рандом?</param>
    public NodeTree(bool random)
    {
        if (!random) return;
        _data = new Organisation();
        _data.RandomInit();
        _left = null;
        _right = null;
    }

    public NodeTree(Organisation data)
    {
        _data = data;
        _left = null;
        _right = null;
    }

    public override string ToString()
    {
        return _data.ToString();
    }
}