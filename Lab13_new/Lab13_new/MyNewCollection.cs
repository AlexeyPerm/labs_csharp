using Lab12_4_list;
using ClassLibraryLab10;

namespace Lab13_new;

public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);

public class MyNewCollection<T> : MyCollection<T>
{
    public string CollectionName { get; private set; }

    public MyNewCollection()
    {
        CollectionName = "NoNameCollection";
    }

    public MyNewCollection(string collectionName, int capacity) : base(capacity)
    {
        CollectionName = collectionName;
    }

    public MyNewCollection(string collectionName)
    {
        CollectionName = collectionName;
    }

    public MyNewCollection(MyCollection<T> collection) : base(collection)
    {
        CollectionName = "NoNameCollection";
    }


    public event CollectionHandler CollectionCountChanged;
    public event CollectionHandler CollectionReferenceChanged;

    public override T this[int index]
    {
        get => base[index];
        set
        {
            base[index] = value;
            OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs
                (CollectionName, "Изменение", value ?? throw new ArgumentNullException(nameof(value))));
        }
    }

    public new void Add(T data)
    {
        base.Add(data);
        OnCollectionCountChanged(this, new CollectionHandlerEventArgs
            (CollectionName, "Добавление", data ?? throw new ArgumentNullException(nameof(data))));
    }

    public void AddDefault()
    {
        base.Add(default!);
        OnCollectionCountChanged(this, new CollectionHandlerEventArgs
            (CollectionName, "Добавление значения по умолчанию", default!));
    }

    public new void Remove(T data)
    {
        base.Remove(data);
        OnCollectionCountChanged(this, new CollectionHandlerEventArgs
            (CollectionName, "Удаление", data ?? throw new ArgumentNullException(nameof(data))));
    }


    private void OnCollectionCountChanged(object sender, CollectionHandlerEventArgs args)
    {
        CollectionCountChanged?.Invoke(sender, args);
    }

    private void OnCollectionReferenceChanged(object sender, CollectionHandlerEventArgs args)
    {
        CollectionReferenceChanged?.Invoke(sender, args);
    }
}