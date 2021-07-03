using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.ChartEntity;
using MvcPorject.Models;

namespace DataAccessLibrary.Abstract
{
    public interface IStatisticDal:IRepository<Statistic>
    {
        int NumberOfCategory();
        int TrueOrFalseDifferenceOfCategory();
        Category CategoryWithTheMostHeader();
        int NumberOfHeaderInCategory(int id);
        List<CategoryChart> CategoryCharts();
        int WriterFilterCount();
        List<ContentChart> ContentChart();

    }
}
