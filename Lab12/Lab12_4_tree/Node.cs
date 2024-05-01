namespace Lab12_4_tree;

public class Node<T> where T : IComparable
{
    public Node<T> Right { get; set; }
    public Node<T> Left { get; set; }
    public T Data { get; set; }


    public override bool Equals(object obj)
    {
        if (obj is Node<T> other)
        {
            if (ReferenceEquals(Data, other.Data)) return true;
            return Data.Equals(other.Data);
        }

        return false;
    }

    public override int GetHashCode() => Data == null ? 0 : Data.GetHashCode();

    
    #region Overloading comparison operators

    public static bool operator ==(Node<T> left, Node<T> right) =>
        ReferenceEquals(left, right) || (left?.Equals(right) ?? false);

    public static bool operator !=(Node<T> left, Node<T> right) => !(left == right);
    public static bool operator <(Node<T> left, Node<T> right) => left.Data.CompareTo(right.Data) < 0;
    public static bool operator >(Node<T> left, Node<T> right) => left.Data.CompareTo(right.Data) > 0;

    #endregion
}