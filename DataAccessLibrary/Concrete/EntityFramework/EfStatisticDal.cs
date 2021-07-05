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
    public class EfStatisticDal : GenericRepository<DashboardStatistic, Context>, IStatisticDal
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
                var result = context.Contents.GroupBy(x => x.Heading)
                    .Select(s =>  new ContentChart()
                    {
                        HeadingName = s.Key.HeadingName,
                        ContentCount = s.Count(),
                        WriterCount = s.GroupBy(x=>x.Writer).Count()
                    });
                return result.ToList();

            }
        }

        public DashboardStatistic DashboardStatistic()
        {
            using (Context context = new Context())
            {
                var headingCount = context.Headings.Count();
                var entryCount = context.Contents.Count();
                var writerCount = context.Writers.Count();
                var messagesCount= context.Messages.Count();
                DashboardStatistic statistic =new DashboardStatistic 
                {
                    HeadingCount = headingCount,
                    EntryCount = entryCount,
                    WriterCount= writerCount,
                    MessagesCount= messagesCount
                };
                return statistic;
            }
        }
    }
}
