using ClassLibraryLab10;

namespace Lab12_2;

public class BinaryTree
{
    private Node Root { get; set; }

    public BinaryTree(Organisation data)
    {
        Root = new Node(data);
    }

    public bool IsEmpty()
    {
        return Root == null;
    }

    public void Add(Node newData)
    {
        Node newNode = new Node();
        
        Root ??= newNode;   // ??= оператор присваивания объединения. Если Root == null, то Root = newNode;
        Node current = Root;
        Node parent;
        while (true)
        {
            parent = current;
            if (newData._data.Budget < current._data.Budget)
            {
                
            }
        }



    }
    
}