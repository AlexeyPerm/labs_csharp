using System;
using System.Collections;

namespace ClassLibraryLab10;

public class SortByBudget : IComparer
{
    public int Compare(object x, object y)
    {
        Organisation orgX = (Organisation)x;
        Organisation orgY = (Organisation)y;
        if (orgX is null || orgY is null)
            throw new ArgumentException("Некорректное значение параметра");
        if (orgX.Budget < orgY.Budget)
            return -1;
        return orgX.Budget == orgY.Budget ? 0 : 1;
    }
}