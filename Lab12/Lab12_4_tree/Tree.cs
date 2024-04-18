namespace Lab12_4_tree;

public class Tree<T>
{
    public Tree<T> Root { get; set; }
    
    public static int NodesCount(Node<T> root)
    {
        if (root == null!)
        {
            return 0;
        }

        return NodesCount(root.Left) + NodesCount(root.Right) + 1;
    }
    
    

}