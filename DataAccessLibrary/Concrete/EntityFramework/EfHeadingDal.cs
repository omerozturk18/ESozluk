using System.Linq;
using System.Security.Cryptography.X509Certificates;
using DataAccessLibrary.Abstract;
using DataAccessLibrary.Concrete.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLibrary.Concrete.EntityFramework
{
    public class EfHeadingDal:GenericRepository<Heading,Context>,IHeadingDal
    {
        public int NumberOfHeaderInCategory(int id)
        {
            using (Context context = new Context())
            {
                return context.Headings.Count(x => x.CategoryId == id);
            }
        }

        public int CategoryWithTheMostHeader()
        {
            using (Context context = new Context())
            {
                var categoryId = 0;
                var categoryGroupBy = context.Headings.GroupBy(g => g.CategoryId).OrderBy(x => x.Count());
                var singleOrDefault = categoryGroupBy.SingleOrDefault(x => x.Key == 1);
                if (singleOrDefault != null)
                {
                    foreach (var item in singleOrDefault)
                    {
                        categoryId = item.CategoryId;
                    }
                    return categoryId;
                }
                return 0;
            }
        }
        
    }
}
