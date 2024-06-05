namespace Lab13;

public class MyNewCollection : MyCollection<Organisation>
{
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);

    //обработчик события CollectionCountChanged
    public virtual void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args)
    {
        // if (CollectionCountChanged != null)
        //     CollectionCountChanged(source, args);
        CollectionCountChanged?.Invoke(source, args);
    }


    //обработчик события CollectionReferenceChanged
    public virtual void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
    {
        // if (CollectionReferenceChanged != null)
        //     CollectionReferenceChanged(source, args);
        CollectionReferenceChanged?.Invoke(source, args);
    }

    //Событие: при добавлении нового элемента или при удалении элемента из коллекции
    public event CollectionHandler CollectionCountChanged;

    //Событие: объекту коллекции присваивается новое значение       
    public event CollectionHandler CollectionReferenceChanged;


    public override Organisation this[int index]
    {
        get => base[index];
        set
        {
            base[index] = value;
            OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs(Name, "изменение", value));
        }
    }

    public string Name { get; set; }

    public MyNewCollection()

    {
        Name = "MyNewCollection";
    }

    public override void Add(Organisation data)
    {
        base.Add(data);
        OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Добавление", data));
    }


    public override bool Remove(Organisation data)
    {
        if (!base.Remove(data)) return false;
        OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "Удаление", data));
        return true;
    }
}