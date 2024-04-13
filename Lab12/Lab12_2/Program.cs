using ClassLibraryLab10;

namespace Lab12_2;

class Program
{
    private static void Main()
    {
        var firstElement = RandObjectOrganisation();
        firstElement.RandomInit();
        var tree = First(firstElement);
        for (int i = 0; i < 20; i++)
        {
            var temp = RandObjectOrganisation();
            temp.RandomInit();
            Add(tree, temp);
        }

        ShowTree(tree);
    }


    /// <summary>
    /// Построение идеально сбалансированного дерева
    /// </summary>
    /// <param name="size">Размер создаваемого дерева</param>
    /// <param name="root">Корень дерева</param>
    /// <returns></returns>
    private static Node IdealTree(int size, Node root)
    {
        ArgumentNullException.ThrowIfNull(root); //Исключение, если корень дерева равен null
        if (size == 0)
        {
            root = null;
            return root;
        }

        var nLeft = size / 2;
        var nRight = size - nLeft - 1;
        var data = RandObjectOrganisation();
        data.RandomInit();

        Node r = new Node(data);
        r.Left = IdealTree(nLeft, r.Left);
        r.Right = IdealTree(nRight, r.Right);
        return r;
    }


    /// <summary>
    /// Создание случайным образом объекта одного из классов: Organisation, Factory, Shipyard, Library, InsuranceCompany 
    /// </summary>
    /// <returns>Возвращает созданный объект класса</returns>
    private static Organisation RandObjectOrganisation()
    {
        var rand = new Random();
        var randSeed = rand.Next(100) % 5;
        var newItem = randSeed switch
        {
            0 => new Organisation(),
            1 => new Factory(),
            2 => new Shipyard(),
            3 => new Library(),
            4 => new InsuranceCompany(),
            _ => new Organisation()
        };
        return newItem;
    }

    /// <summary>
    ///Функция для обхода дерева сниву вверх
    /// </summary>
    /// <param name="root">Дерево, в котором нужно выполнить обход</param>
    private static void RunBottomToTop(Node root)
    {
        if (root != null)
        {
            Run(root.Left);
            Run(root.Right);
            Console.WriteLine(root._data);
        }
    }

    /// <summary>
    /// Функция для обхода дерева обходом слева направо
    /// </summary>
    /// <param name="root">Дерево, в котором нужно выполнить обход</param>
    /// <param name="l">Длина отсутпа в пробелах между узлами</param>
    private static void ShowTree(Node root)
    {
        if (root != null)
        {
            ShowTree(root.Left); //переход к левому поддереву


            Console.WriteLine(root._data); //печать узла
            ShowTree(root.Right); //переход к правому поддереву
        }
    }


    /// <summary>
    /// Добавление узла в дерево
    /// </summary>
    /// <param name="root">Передаваемый корень дерева</param>
    /// <param name="newData">Добавляемые данные</param>
    /// <returns></returns>
    private static Node Add(Node root, Organisation newData)
    {
        //Новой переменной p назначаем адрес дерева, чтобы все манипуляции продожлать выполнять с ней, а не root
        Node currentNode = root;
        Node tempNode = null;

        //флаг для проверки существования элемента newData в дереве
        var exist = false;
        while (currentNode != null && !exist)
        {
            tempNode = currentNode;
            //элемент уже существует
            if (Equals(newData, currentNode._data))
            {
                return currentNode;
            }

            if (newData.Budget < tempNode._data.Budget)
            {
                currentNode = currentNode.Left; //пойти в левое поддерево
            }
            else
            {
                currentNode = currentNode.Right; //пойти в правое поддерево
            }
        }

        //создаём узел
        Node NewPoint = new Node(newData); //выделили память
        // если бюджет организации newData < r, то добавляем его в левое поддерево
        if (newData.Budget < tempNode._data.Budget)
        {
            tempNode.Left = NewPoint;
        }
        // если newData>r.key, то добавляем его в правое поддерево
        else
        {
            tempNode.Right = NewPoint;
        }

        return NewPoint;
    }


    /// <summary>
    /// Функция обхода дерева сверху вниз
    /// </summary>
    /// <param name="root">Дерево, в котором нужно выполнить обход</param>
    private static void Run(Node root)

    {
        if (root != null)
        {
            Console.WriteLine(root._data);
            Run(root.Left); //переход к левому поддереву
            Run(root.Right); //переход к правому поддереву
        }
    }


    /// <summary>
    /// Формирование первого элемента дерева.
    /// </summary>
    /// <param name="data">Данные, хранящиеся в узле</param>
    /// <returns></returns>
    static Node First(Organisation data)
    {
        Node p = new Node(data);
        return p;
    }
}