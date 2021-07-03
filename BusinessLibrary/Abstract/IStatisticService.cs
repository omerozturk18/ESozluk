using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLibrary.Abstract
{
    public interface IStatisticService
    {
        int NumberOfCategory();
        int NumberOfHeaderInCategory(int id);
        int WriterFilterCount(); 
        Category CategoryWithTheMostHeader();
        int TrueOrFalseDifferenceOfCategory();


    }
}
