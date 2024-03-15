using Lab113;

namespace Lab11_3;

public class TestCollections
{
    public List<Factory> listFactory = new(); // Коллекция_1 <TValue>
    public List<string> listString = new(); // Коллекция_1 <string>
    public SortedDictionary<Organisation, Factory> sdOrgFact = new(); //Коллекция_2 <TKey, TValue>
    public SortedDictionary<string, Factory> sdStringFact = new(); //Коллекция_2 <string, TValue>
    
    public TestCollections(int capacity)
    {
        for (var i = 0; i < capacity; i++)
        {
            var temp = new Factory();
            
            temp.RandomInit();
            listFactory.Add(temp);
            listString.Add(temp.BaseOrganisation.ToString());
            sdOrgFact.Add(temp.BaseOrganisation, temp);
            sdStringFact.Add(temp.BaseOrganisation.ToString(), temp);
        }
    }

    public void Add(Factory item)
    {
        listFactory.Add(item);
        listString.Add(item.BaseOrganisation.ToString());
        sdOrgFact.Add(item.BaseOrganisation, item);
        sdStringFact.Add(item.BaseOrganisation.ToString(), item);
    }
    
    public void Remove(Factory item)
    {
        listFactory.Remove(item);
        listString.Remove(item.ToString());
        sdOrgFact.Remove(item.BaseOrganisation);
        sdStringFact.Remove(item.BaseOrganisation.ToString());
    }

    public void RemoveAt(int index)
    {
        listFactory.RemoveAt(index);
        listString.RemoveAt(index);
        sdOrgFact.Remove(sdOrgFact.ElementAt(index).Key);
        sdStringFact.Remove(sdStringFact.ElementAt(index).Key);
    }
    
    public void ShowTestCollection()        //На удаление. Бесполезный метод.
    {
        Console.WriteLine("Вывод элементов коллекции \"Коллекция_1 <TValue>\"");
        foreach (Factory item in listFactory)
        {
            item.Show();
            Console.WriteLine();
        }

        Console.WriteLine("Вывод элементов коллекции \"Коллекция_1 <string>\"");
        foreach (var item in listString)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Вывод элементов коллекции \"Коллекция_2 <TKey, TValue>\"");
        foreach (KeyValuePair<Organisation, Factory> item in sdOrgFact)
        {
            Console.WriteLine("KEY:");
            item.Key.Show();
            Console.WriteLine("VALUE:");
            item.Value.Show();
        }

        Console.WriteLine("Вывод элементов коллекции \"Коллекция_2 <string, TValue>\"");
        foreach (KeyValuePair<string, Factory> item in sdStringFact)
        {
            Console.WriteLine("KEY:");
            Console.Write(item.Key);
            Console.WriteLine("VALUE:");
            item.Value.Show();
        }
    }
}