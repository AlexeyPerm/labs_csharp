﻿/*
1.	Сформировать двунаправленный список, в информационное поле записать объекты
из иерархии классов лабораторной работы №10.
2.	Распечатать полученный список.
3.	Выполнить обработку списка в соответствии с заданием. Удалить из списка первый элемент с
заданным информационным полем (например, с заданным именем).
4.	Распечатать полученный список.
5.	Удалить список из памяти.
 */

using ClassLibraryLab10;

namespace Lab12_1;

internal class Lab121
{
    public static void Main()
    {
        const int variantNumber = 549 % 25 - 1; //номер варианта 23
        Console.WriteLine($"Номер варианта = {variantNumber}\n");
        MainMenu();
        Console.Clear();
        Console.WriteLine("Программа успешно завершена");
        Console.ReadLine();
    }

    //Основное меню
    private static void MainMenu()
    {
        var exit = false;
        var list = new DoublyLinkedList();
        while (!exit)
        {
            Console.WriteLine();
            Console.WriteLine("1. Создать список из 10 элементов");
            Console.WriteLine("2. Создать список из указанного кол-ва элементов");
            Console.WriteLine("3. Добавить элемент в начало");
            Console.WriteLine("4. Добавить элемент в конец");
            Console.WriteLine("5. Удалить элемент с начала");
            Console.WriteLine("6. Удалить элемент с конца");
            Console.WriteLine("8. Вывести список на экран");
            Console.WriteLine("9. Очистить список");
            Console.WriteLine("0. Выход");
            Console.Write("> ");

            var input = InputDigit();
            switch (input)
            {
                default:
                    Console.WriteLine("Введены некорректные данные");
                    break;
                case 1:
                    list = CreateListWithTenElements();
                    Console.Clear();
                    Console.WriteLine("Список создан");
                    break;
                case 2:
                    var size = ListSize();
                    list = CreateList(size);
                    Console.WriteLine("Список создан");
                    break;
                case 3:
                    var itemAddFront = RandObjectOrganisation();
                    itemAddFront.RandomInit();
                    list.PushFront(itemAddFront);
                    break;                
                case 4:
                    var itemAddBack = RandObjectOrganisation();
                    itemAddBack.RandomInit();   
                    list.PushBack(itemAddBack);
                    break;       
                case 5:
                    list.PopFront();
                    break;
                case 6:
                    list.PopBack();
                    break;
                case 8:
                    Console.Clear();
                    list.PrintLinkedList();
                    break;
                case 9:
                    list.Clear();
                    Console.WriteLine("Список очищен");
                    break;
                case 0:
                    exit = true;
                    break; //Назад в предыдущее меню
            } //end of switch
        } //end of while
    } //end of MainMenu()


    public static DoublyLinkedList CreateList(int size)
    {
        var tempList = new DoublyLinkedList();
        for (var i = 0; i < size; i++)
        {
            var item = RandObjectOrganisation();
            item.RandomInit();
            tempList.PushFront(item);
        }
        return tempList;
    }

    private static int ListSize()
    {
        var size = InputDigit();
        while (size <= 0)
        {
            Console.WriteLine("Размер списка не должен быть меньше или равен нулю");
            size = InputDigit();
        }

        return size;
    }

    private static DoublyLinkedList CreateListWithTenElements()
    {
        var tempList = new DoublyLinkedList();
        const int size = 10;
        for (var i = 0; i < size; i++)
        {
            var item = RandObjectOrganisation();
            item.RandomInit();
            tempList.PushFront(item);
        }

        return tempList;
    }

    /// <summary>
    /// Проверка корректности ввода и конвертация строки в целое число int
    /// </summary>
    /// <returns>Возвращает целое число, конвертированное из строки</returns>
    private static int InputDigit()
    {
        int result;
        while (!int.TryParse(Console.ReadLine(), out result))
        {
            Console.Write("Ошибка! Должен быть тип int\nПовторите ввод\n> ");
        }

        return result;
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