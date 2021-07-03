using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLibrary.Abstract;
using DataAccessLibrary.Abstract;
using EntityLayer.Concrete;
using MvcPorject.Models;

namespace BusinessLibrary.Concrete
{
    public class StatisticManager: IStatisticService
    {
        private readonly IStatisticDal _statisticDal;

        public StatisticManager(IStatisticDal statisticDal)
        {
            _statisticDal = statisticDal;
        }

        public int NumberOfCategory()
        {
            return _statisticDal.NumberOfCategory();
        }

        public int NumberOfHeaderInCategory(int id)
        {
            return _statisticDal.NumberOfHeaderInCategory(id);
        }

        public int WriterFilterCount()
        {
            return _statisticDal.WriterFilterCount();
        }

        public Category CategoryWithTheMostHeader()
        {
            return _statisticDal.CategoryWithTheMostHeader();
        }

        public int TrueOrFalseDifferenceOfCategory()
        {
            return _statisticDal.TrueOrFalseDifferenceOfCategory();
        }
        public List<CategoryChart> CategoryChart()
        {
            return _statisticDal.CategoryCharts();
        }
        public List<ContentChart> ContentChart()
        {
            return _statisticDal.ContentChart();
        }
    }
}
