using Lab12_4_list;

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

    public MyNewCollection(MyCollection<T> collection) : base(collection)
    {
        CollectionName = "NoNameCollection";
    }


    public event CollectionHandler? CollectionCountChanged;
    public event CollectionHandler? CollectionReferenceChanged;


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

    /// <summary>
    /// Добавление элемента в коллекцию
    /// </summary>
    /// <param name="data">Данные для добавления</param>
    /// <exception cref="ArgumentNullException">Проверка на Null</exception>
    public new void Add(T data)
    {
        base.Add(data);
        OnCollectionCountChanged(this, new CollectionHandlerEventArgs
            (CollectionName, "Добавление", data ?? throw new ArgumentNullException(nameof(data))));
    }

    /// <summary>
    /// Добавление в коллекцию значения по умолчанию
    /// </summary>
    public void AddDefault()
    {
        base.Add(default!);
        OnCollectionCountChanged(this, new CollectionHandlerEventArgs
            (CollectionName, "Добавление значения по умолчанию", default!));
    }

    /// <summary>
    /// Удаление элемента из коллекции
    /// </summary>
    /// <param name="data">Удаляемые данные</param>
    /// <exception cref="ArgumentNullException">Проверка на Null</exception>
    public new void Remove(T data)
    {
        base.Remove(data);
        OnCollectionCountChanged(this, new CollectionHandlerEventArgs
            (CollectionName, "Удаление", data ?? throw new ArgumentNullException(nameof(data))));
    }

    /// <summary>
    /// Функция-событие, вызываемое при добавлении или удалении элемента из коллекции
    /// </summary>
    /// <param name="sender">Объект-источник события</param>
    /// <param name="args">Информация о данных</param>
    private void OnCollectionCountChanged(object sender, CollectionHandlerEventArgs args)
    {
        CollectionCountChanged?.Invoke(sender, args);
    }

    /// <summary>
    /// Функция-событие, вызываемое при изменении коллекции. Событие бросает метод set индексатора.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void OnCollectionReferenceChanged(object sender, CollectionHandlerEventArgs args)
    {
        CollectionReferenceChanged?.Invoke(sender, args);
    }
}