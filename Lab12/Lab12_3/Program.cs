using ClassLibraryLab10;

namespace Lab12_3;

class Program
{
    static void Main()
    {
        var f = new Factory("test", 100, 200);
        var i = new InsuranceCompany("1qq", 234, 600);
        Htable h = new Htable();
        h.Insert(f);
        h.Insert(i);
        
        h.Print();
        
        
        
    }
}