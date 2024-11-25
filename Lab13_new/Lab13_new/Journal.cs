using Lab12_4_list;

namespace Lab13_new;

public class Journal
{
    public List<JournalEntry> journalEntries = [];

    public void CollectionCountChanged(object source, CollectionHandlerEventArgs args)
    {
        journalEntries.Add(new JournalEntry(args.CollectionName, args.ChangeType, args.Item.ToString()!));
    }

    public void CollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
    {
        journalEntries.Add(new JournalEntry(args.CollectionName, args.ChangeType, args.Item.ToString()!));
    }
}