namespace Lab13;

public class CollectionHandlerEventArgs
{
    public string CollectionName { get; }   //Имя коллекции
    public string ChangeType { get; }   //Тип изменения в коллекции
    public Organisation ChainedObject { get; }  //Изменяемый объект

    
    public CollectionHandlerEventArgs(string collectionName, string changeType, Organisation chainedObject)
    {
        CollectionName = collectionName;
        ChangeType = changeType;
        ChainedObject = chainedObject;
    }

    public override string ToString()
    {
        return $"Имя коллекции: {CollectionName}, тип изменения: {ChangeType}";
    }
}