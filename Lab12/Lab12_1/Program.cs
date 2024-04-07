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
        for (var i = 0; i < 4; i++)
        {
            var tmp = RandObjectOrganisation();
            tmp.RandomInit();
            a.Push_Front(tmp);
        }

        var findedItem = RandObjectOrganisation();
        findedItem.RandomInit();

        a.PrintLinkedList();

        RemoveElementByOrgName(a, findedItem);


        //a = null;   //для выполнения задания по удалению коллекции из памяти


        Console.WriteLine();
    }

    /// <summary>
    /// Удалить из списка первый элемент с полем OrgName
    /// </summary>
    /// <param name="a">Коллекция, в которой удаляется элемент</param>
    /// <param name="findedItem">Удаляемый элемент</param>
    private static void RemoveElementByOrgName(DoublyLinkedList<Organisation> a, Organisation findedItem)
    {
        int count = 1;
        foreach (var item in a)
        {
            if (item.OrgName == findedItem.OrgName)
            {
                Console.WriteLine($"Элемент {findedItem.OrgName} найден! Удаляем");
                a.RemoveElement(count);
                a.PrintLinkedList();
                break;
            }

            count++;
        }
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