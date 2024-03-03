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
        TestCollections testCollection = new TestCollections(2); //размер коллекций (capacity) в объекте


        //testCollection.ShowTestCollection();
        testCollection.RemoveAt(1);
        testCollection.ShowTestCollection();



    }
}