using System.Collections;
using ClassLibraryLab10;

namespace test;

internal static class Test
{
    public static void Main()
    {
        Factory f = new Factory();
        f.RandomInit();
        Library l = new Library("HP", 5000, 4444);
        Library tmp = new Library("HP", 5000, 4444);


        Hashtable ht = new Hashtable();
        ht.Add(1, f);
        ht.Add(2, l);
        string a = "HP";
        var items = ht.Values.OfType<Organisation>().Where(s => s.OrgName == a);

        
        
        
        foreach (Organisation i in items)
        {
            i.Show();
        }
        
    }
}