namespace Lab13_new;

public class CollectionHandlerEventArgs(string collectionName, string changeType, object item) : EventArgs
{
    public string CollectionName { get; } = collectionName;
    public string ChangeType { get; } = changeType;
    public object Item { get; } = item;


    public override string ToString()
    {
        return $"Коллекция: {CollectionName}\n" +
               $"Изменение: {ChangeType}\n" +
               $"Объект: {Item}";
    }
}