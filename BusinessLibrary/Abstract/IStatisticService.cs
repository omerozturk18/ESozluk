using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Abstract
{
    public interface IStatisticService
    {
        int NumberOfCategory();
        int NumberOfHeaderInCategory(int id);
        int WriterFilterCount(); 
        int CategoryWithTheMostHeader();
        int TrueOrFalseDifferenceOfCategory();


    }
}
