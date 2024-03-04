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

namespace Lab113;

static class Lab113
{
    private static void Main()
    {
        const int capacity = 10;
        var testCollection = new TestCollections(capacity);
       // const int middleItem = capacity / 2;

       // Factory searchElement = testCollection.listFactory.ElementAt(500);

        //Console.WriteLine(testCollection.listFactory.Contains(searchElement));
    }
}