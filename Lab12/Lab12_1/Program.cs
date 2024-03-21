/*
1.	Сформировать двунаправленный список, в информационное поле записать объекты
из иерархии классов лабораторной работы №10.
2.	Распечатать полученный список.
3.	Выполнить обработку списка в соответствии с заданием. Удалить из списка первый элемент с
заданным информационным полем (например, с заданным именем).
4.	Распечатать полученный список.
5.	Удалить список из памяти.
 */

using System.Threading.Channels;
using ClassLibraryLab10;

namespace Lab12_1;

static class Lab121
{
    public static void Main()
    {
        const int variantNumber = 549 % 25 - 1; //номер варианта 23
        Console.WriteLine($"Номер варианта = {variantNumber}\n");

        MyList<Organisation> a = new MyList<Organisation>(5);
        a.Print();
        
        
        
    }
}