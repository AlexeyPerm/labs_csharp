namespace Lab13_new;

public class JournalEntry(string collectionName, string changeType, string objectInfo)
{
    private string CollectionName { get; } = collectionName;
    private string ChangeType { get; } = changeType;
    private string ObjectInfo { get; } = objectInfo;

    public override string ToString()
    {
        return $"Коллекция: {CollectionName}\n" +
               $"Изменение: {ChangeType}\n" +
               $"Объект: {ObjectInfo}";
    }
}