/*
1.	Сформировать двунаправленный список, в информационное поле записать объекты
из иерархии классов лабораторной работы №10.
2.	Распечатать полученный список.
3.	Выполнить обработку списка в соответствии с заданием. Удалить из списка первый элемент с
заданным информационным полем (например, с заданным именем).
4.	Распечатать полученный список.
5.	Удалить список из памяти.
 */

using System.Reflection.Metadata;
using ClassLibraryLab10;

namespace Lab12_1;

static class Lab121
{
    public static void Main()
    {
        const int variantNumber = 549 % 25 - 1; //номер варианта 23
        Console.WriteLine($"Номер варианта = {variantNumber}\n");

        DoublyLinkedList<Organisation> a = new DoublyLinkedList<Organisation>();
        for (var i = 0; i < 5; i++)
        {
            var tmp = RandObjectOrganisation();
            tmp.RandomInit();
            a.Push_Front(tmp);
        }

        foreach (Organisation item in a)
        {
            Console.WriteLine(item);
        }

        a = null;   //для выполнения задания по удалению коллекции из памяти
        
        
        Console.WriteLine();
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
}