namespace Lab12_2_new;

using ClassLibraryLab10;
#nullable disable
public class TreeNode(Organisation data)
{
    public Organisation Data { get; set; } = data;
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }
}