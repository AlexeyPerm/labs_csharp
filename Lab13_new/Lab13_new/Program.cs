namespace Lab13_new;

class Program
{
    static void Main()
    {
        var a = new MyNewCollection<int>("Моя коллекция", 5);
        Journal journal = new Journal();
        a.CollectionCountChanged += journal.CollectionCountChanged;
        a.CollectionReferenceChanged += journal.CollectionReferenceChanged;
        a.Add(111);

        foreach (var item in journal.journalEntries)
        {
            Console.WriteLine(item);
        }
    }

}