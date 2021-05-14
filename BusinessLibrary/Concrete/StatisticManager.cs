using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLibrary.Abstract;
using DataAccessLibrary.Abstract;

namespace BusinessLibrary.Concrete
{
    public class StatisticManager: IStatisticService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IHeadingDal _headingDal;
        private readonly IWriterDal _writerDal;

        public StatisticManager(IWriterDal writerDal, IHeadingDal headingDal, ICategoryDal categoryDal)
        {
            _writerDal = writerDal;
            _headingDal = headingDal;
            _categoryDal = categoryDal;
        }

        public int NumberOfCategory()
        {
            return _categoryDal.NumberOfCategory();
        }

        public int NumberOfHeaderInCategory(int id)
        {
            return _headingDal.NumberOfHeaderInCategory(id);
        }

        public int WriterFilterCount()
        {
            return _writerDal.WriterFilterCount();
        }

        public int CategoryWithTheMostHeader()
        {
            return _headingDal.CategoryWithTheMostHeader();
        }

        public int TrueOrFalseDifferenceOfCategory()
        {
            return _categoryDal.TrueOrFalseDifferenceOfCategory();
        }
    }
}
