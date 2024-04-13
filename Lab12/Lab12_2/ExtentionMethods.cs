using ClassLibraryLab10;

namespace ExtMethods;

//Информацию о методах расширения класса и/или структуры взята отсюда:
//https://youtu.be/lH4YIgIMCBM?si=QZHdU3N9XTfW48NP

//Метод расширения для корректного вывода на экран дерева. Без него только название 
//имело отступ от левого края, остальные поля печатались без отступа. То есть было так:
/*
 
          Библиотека
Название: lGkLLlVtLJsVUpo
Бюджет: 6970 рублей
Количество книг: 40046

Страховая компания
Название: OgnDBaPIwMebyJO
Бюджет: 8197 рублей
Количество страховых случаев: 9152

          Фабрика
Название: BtTANjcMBXrKXRJ
Бюджет: 8008 рублей
Количество инженеров: 789

*/

static class ExtentionMethods
{
    /// <summary>
    /// Метод расширения класса для отделения пробелами каждого из его полей.
    /// </summary>
    /// <param name="org">Передаваемый объект класса Organisation</param>
    /// <param name="space">Отступ от левого края в количестве пробелов</param>
    public static void PrintInTree(this Organisation org, int space)
    {
        if (org.GetType() == typeof(Organisation))
        {
            AddSpaces(space);
            Console.WriteLine("Оргазизация");
            PrintBaseOrganisation(org, space);
            Console.WriteLine();
        }
        else if (org.GetType() == typeof(Factory))
        {
            AddSpaces(space);
            Console.WriteLine("Фабрика");
            Factory temp = (Factory)org;
            PrintBaseOrganisation(org, space);
            AddSpaces(space);
            Console.WriteLine($"Количество инженеров: {temp.EngeneersCount}\n");
        }
        else if (org.GetType() == typeof(Shipyard))
        {
            AddSpaces(space);
            Console.WriteLine("Судостроительная компания");
            Shipyard temp = (Shipyard)org;
            PrintBaseOrganisation(org, space);
            AddSpaces(space);
            Console.WriteLine($"Количество инженеров: {temp.EngeneersCount}");
            AddSpaces(space);
            Console.WriteLine($"Количество построеных судн: {temp.BuiltShips}\n");
        }
        else if (org.GetType() == typeof(Library))
        {
            AddSpaces(space);
            Console.WriteLine("Библиотека");
            Library temp = (Library)org;
            PrintBaseOrganisation(org, space);
            AddSpaces(space);
            Console.WriteLine($"Количество книг: {temp.BooksTotalNum}\n");
        }
        else if (org.GetType() == typeof(InsuranceCompany))
        {
            AddSpaces(space);
            Console.WriteLine("Страховая компания");
            InsuranceCompany temp = (InsuranceCompany)org;
            PrintBaseOrganisation(org, space);
            AddSpaces(space);
            Console.WriteLine($"Количество страховых случаев: {temp.InsuranceCases}\n");
        }
    }

    /// <summary>
    /// Печатать базового класса Organisation. Выделен в отдельный метод для исключения дублированя кода
    /// </summary>
    /// <param name="org">Передаваемый объект класса Organisation</param>
    /// <param name="space">Отступ от левого края в количестве пробелов</param>
    private static void PrintBaseOrganisation(Organisation org, int space)
    {
        AddSpaces(space);
        Console.WriteLine($"Название: {org.OrgName}");
        AddSpaces(space);
        Console.WriteLine($"Бюджет: {org.Budget} рублей");
    }

    /// <summary>
    /// Отступ от левого края
    /// </summary>
    /// <param name="space">Количество пробелов в отступе</param>
    private static void AddSpaces(int space)
    {
        for (int i = 10; i < space; i++)
        {
            Console.Write(" ");
        }
    }
}