using System.Data.Entity;
using System.Linq;
using DataAccessLibrary.Abstract;
using DataAccessLibrary.Concrete.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLibrary.Concrete.EntityFramework
{
    public class EfCategoryDal: GenericRepository<Category, Context>, ICategoryDal
    {
        public int NumberOfCategory()
        {
            using (Context context = new Context())
            {
               return context.Categories.Count();
            }
        }


        public int TrueOrFalseDifferenceOfCategory()
        {
            using (Context context = new Context())
            {
                var trueCategory= context.Categories.Count(x=>x.CategoryStatus==true);
                var falseCategory = context.Categories.Count(x => x.CategoryStatus == false);
                var difference = trueCategory - falseCategory;
              return  difference < 0 ? difference = difference * (-1) : difference = difference;
                 
            }
        }
    }
}
