/*
3. Определить класс TestCollections, который содержит поля следующих типов
Коллекция_1 <TValue>;
Коллекция_1 <string>;
Коллекция_2 <TKey, TValue>;
Коллекция_2 <string, TValue>.
где тип ключа TKey и тип значения TValue связаны отношением базовый-производный,
Коллекция_1 и Коллекция_2 – коллекции из пространства имен System.Collections.Generic.
Элементы типа string получаются из элементов типа TKey с помощью метода ToString()/
*/

using System.Diagnostics;

namespace Lab11_3;

static class Lab113
{
    private static void Main()
    {
        const int capacity = 100000;
        var testCollection = new TestCollections(capacity);

        SearchFirstElement(testCollection);
        SearchMiddleElement(testCollection);
        SearchLastElement(testCollection);
        SearchNonExistElement(testCollection);
    }

    
    private static void SearchFirstElement(TestCollections testCollection)
    {
        var firstElement = testCollection.listFactory.First();
        Console.WriteLine("Поиск первого элемента в списках:");
        TimeList(testCollection.listFactory, firstElement);
        TimeList(testCollection.listString, firstElement.BaseOrganisation.ToString());
        Console.WriteLine("Поиск первого элемента в словарях:");
        TimeSortedDictionary(testCollection.sdStringFact, firstElement.BaseOrganisation.ToString());
        TimeSortedDictionary(testCollection.sdOrgFact, firstElement);
        Console.WriteLine();
    }

    private static void SearchMiddleElement(TestCollections testCollection)
    {
        var middleElement = testCollection.listFactory.ElementAt(testCollection.listFactory.Count / 2);
        Console.WriteLine("Поиск центрального элемента в списках:");
        TimeList(testCollection.listFactory, middleElement);
        TimeList(testCollection.listString, middleElement.BaseOrganisation.ToString());
        Console.WriteLine("Поиск центрального элемента в словарях:");
        TimeSortedDictionary(testCollection.sdStringFact, middleElement.BaseOrganisation.ToString());
        TimeSortedDictionary(testCollection.sdOrgFact, middleElement);
        Console.WriteLine();
    }

    private static void SearchLastElement(TestCollections testCollection)
    {
        var lastElement = testCollection.listFactory.Last();
        Console.WriteLine("Поиск последнего элемента в списках:");
        TimeList(testCollection.listFactory, lastElement);
        TimeList(testCollection.listString, lastElement.BaseOrganisation.ToString());
        Console.WriteLine("Поиск последнего элемента в словарях:");
        TimeSortedDictionary(testCollection.sdStringFact, lastElement.BaseOrganisation.ToString());
        TimeSortedDictionary(testCollection.sdOrgFact, lastElement);
        Console.WriteLine();
    }

    private static void SearchNonExistElement(TestCollections testCollection)
    {
        Console.WriteLine("Поиск несуществующего элемента в списках:");
        Factory temp = new("test", 10, 10);
        TimeList(testCollection.listFactory, temp);
        TimeList(testCollection.listString, temp.BaseOrganisation.ToString());
        Console.WriteLine("Поиск несуществующего элемента в словарях:");
        TimeSortedDictionary(testCollection.sdStringFact, temp.BaseOrganisation.ToString());
        TimeSortedDictionary(testCollection.sdOrgFact, temp);
        Console.WriteLine();
    }


    private static void TimeList<T>(List<T> list, T item)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var found = list.BinarySearch(item);
        stopWatch.Stop();
        if (found == 0)
        {
            Console.WriteLine("Элемент найден.");
        }
        else
        {
            Console.WriteLine("Элемент не найден");
        }

        Console.WriteLine("Время поиска: " + stopWatch.ElapsedTicks);
    }

    private static void TimeSortedDictionary<TKey, TValue>(SortedDictionary<TKey, TValue> dict, TKey value)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var found = dict.ContainsKey(value);
        stopWatch.Stop();
        if (found)
        {
            Console.WriteLine("Элемент найден.");
        }
        else
        {
            Console.WriteLine("Элемент не найден");
        }

        Console.WriteLine("Время поиска: " + stopWatch.ElapsedTicks);
    }
}