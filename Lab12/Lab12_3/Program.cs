using System.Collections;
using ClassLibraryLab10;

namespace Lab12_3;

class Program
{
    static void Main()
    {
        
        var f = new Factory("test", 100, 200);
        var z = new Factory("test", 1600, 200);
        var i = new InsuranceCompany("1qq", 234, 600);
        Htable h = new Htable();
        h.Insert(f);
        h.Insert(i);
        h.Insert(z);

        for (int j = 0; j < 12; j++)
        {
            var element = RandObjectOrganisation();
            element.RandomInit();
            h.Insert(element);
                
        }
        h.Print();
    

    }
    
    
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