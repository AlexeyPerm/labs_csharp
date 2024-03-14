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
using Lab113;

namespace Lab11_3;

static class Lab113
{
    private static void Main()
    {
        const int capacity = 1000;
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        var testCollection = new TestCollections(capacity);
        stopWatch.Stop();
        TimeSpan timeTaken = stopWatch.Elapsed;
        string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
        Console.WriteLine(foo);
        Organisation findedItem = new();
        var elementAt = testCollection.listFactory.ElementAt(capacity / 2);
        elementAt.Show();
        
    }
}