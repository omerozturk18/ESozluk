using System.Collections.Generic;
using DataAccessLibrary.Abstract;
using DataAccessLibrary.Concrete.Repositories;
using EntityLayer.ChartEntity;
using EntityLayer.Concrete;
using MvcPorject.Models;
using System.Linq;
using System.Text.RegularExpressions;


namespace DataAccessLibrary.Concrete.EntityFramework
{
    public class EfStatisticDal : GenericRepository<Statistic, Context>, IStatisticDal
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
                var trueCategory = context.Categories.Count(x => x.CategoryStatus == true);
                var falseCategory = context.Categories.Count(x => x.CategoryStatus == false);
                var difference = trueCategory - falseCategory;
                return difference < 0 ? difference = difference * (-1) : difference = difference;

            }
        }

        public List<CategoryChart> CategoryCharts()
        {
            using (Context context = new Context())
            {
                var result = from h in context.Headings
                    from cI in context.Categories
                    where h.CategoryId == cI.CategoryId
                    group h by h.Category.CategoryName into Grup
                    select new CategoryChart()
                    {
                        CategoryCount = Grup.Count(),
                        CategoryName = Grup.Key
                    };


                return result.ToList();

            }
        }
        public int NumberOfHeaderInCategory(int id)
        {
            using (Context context = new Context())
            {
                return context.Headings.Count(x => x.CategoryId == id);
            }
        }

        public Category CategoryWithTheMostHeader()
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

                    var category = context.Categories.First(x => x.CategoryId == categoryId);
                    return category;
                }
                return null;
            }
        }

        public int WriterFilterCount()
        {
            using (Context context = new Context())
            {
                return context.Writers.Count(x => x.WriterName.Contains("a"));
            }
        }

        public List<ContentChart> ContentChart()
        {
            using (Context context = new Context())
            {

                var result2 = context.Contents.GroupBy(x => new { x.WriterId, x.Heading })
                    .Select(g => new {Writer= g.Key.WriterId, Heading=g.Key.Heading, MyCount = g.Count() }).ToList();
                var result = result2.GroupBy(c => new {c.Heading.HeadingId,c.MyCount})
                    .Select(s => new ContentChart()
                    {
                        HeadingName = s.Where(x=>x.Heading.HeadingId==s.Key.HeadingId).First().Heading.HeadingName,
                        ContentCount = s.Count(),
                        WriterCount = s.Key.MyCount
                    });
                return result.ToList();

            }
        }
    }
}
