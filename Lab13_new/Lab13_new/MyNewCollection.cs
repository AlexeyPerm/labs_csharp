using Lab12_4_list;

namespace Lab13_new;

public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);

public class MyNewCollection<T> : MyCollection<T> {
    public string CollectionName { get; private set; }  // Свойство, хранящее имя коллекции по умолчанию

    /// <summary>
    /// Имя коллекции по умолчанию
    /// </summary>
    public MyNewCollection() {
        CollectionName = "NoNameCollection";
    }

    /// <summary>
    /// Конструктор с параметром collectionName
    /// </summary>
    /// <param name="collectionName">Задаваемое имя коллекции</param>
    public MyNewCollection(string collectionName) {
        CollectionName = collectionName;
    }

    /// <summary>
    /// Конструктор с параметром collectionName, capacity
    /// </summary>
    /// <param name="collectionName">Задаваемое имя коллекции</param>
    /// <param name="capacity">Размерность коллекции</param>
    public MyNewCollection(string collectionName, int capacity) : base(capacity) {
        CollectionName = collectionName;
    }

    /// <summary>
    /// Обобщённый конструктор, принимающий коллекцию MyCollection<T> в качестве параметра
    /// </summary>
    /// <param name="collection">Имя передаваемой коллекции</param>
    public MyNewCollection(MyCollection<T> collection) : base(collection) {
        CollectionName = "NoNameCollection";
    }

    ///Вызывается при изменении количества элементов в коллекции (добавление или удаление).
    public event CollectionHandler? CollectionCountChanged;
    //Вызывается при изменении элемента коллекции через индексатор.
    public event CollectionHandler? CollectionReferenceChanged;

    /// <summary>
    /// Позволяет получить или установить элемент коллекции по индексу. При установке элемента вызывается событие
    /// </summary>
    /// <param name="index">Индекс</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">Если value равен null, будет выброшено исключение 
    /// ArgumentNullException. Иначе, передаётся само значение.</exception>
    public override T this[int index] {
        get => base[index];
        set {
            base[index] = value;
            OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs
                (CollectionName, "Изменение", value ?? throw new ArgumentNullException(nameof(value))));
        }
    }

    /// <summary>
    /// Добавление элемента в коллекцию
    /// </summary>
    /// <param name="data">Данные для добавления</param>
    /// <exception cref="ArgumentNullException">Если data равен null, будет выброшено исключение 
    /// ArgumentNullException. Иначе, передаётся само значение.</exception>
    public new void Add(T data) {
        base.Add(data);
        OnCollectionCountChanged(this, new CollectionHandlerEventArgs
            (CollectionName, "Добавление", data ?? throw new ArgumentNullException(nameof(data))));
    }

    /// <summary>
    /// Добавление в коллекцию значения по умолчанию
    /// </summary>
    public void AddDefault() {
        base.Add(default!);
        OnCollectionCountChanged(this, new CollectionHandlerEventArgs
            (CollectionName, "Добавление значения по умолчанию", default!));
    }

    /// <summary>
    /// Удаление элемента из коллекции
    /// </summary>
    /// <param name="data">Удаляемые данные</param>
    /// <exception cref="ArgumentNullException">Если data равен null, будет выброшено исключение 
    /// ArgumentNullException. Иначе, передаётся само значение.</exception>
    public new void Remove(T data) {
        base.Remove(data);
        OnCollectionCountChanged(this, new CollectionHandlerEventArgs
            (CollectionName, "Удаление", data ?? throw new ArgumentNullException(nameof(data))));
    }

    /// <summary>
    ///  Вызывает событие CollectionCountChanged с информацией о произошедшем изменении
    /// </summary>
    /// <param name="sender">Объект-источник события</param>
    /// <param name="args">Информация о данных</param>
    private void OnCollectionCountChanged(object sender, CollectionHandlerEventArgs args) {
        CollectionCountChanged?.Invoke(sender, args);
    }



    /// <summary>
    /// Вызывает событие CollectionReferenceChanged при изменении элемента коллекции.
    /// </summary>
    /// <param name="sender">Объект-источник события</param>
    /// <param name="args">Информация о данных</param>
    private void OnCollectionReferenceChanged(object sender, CollectionHandlerEventArgs args) {
        CollectionReferenceChanged?.Invoke(sender, args);
    }
}