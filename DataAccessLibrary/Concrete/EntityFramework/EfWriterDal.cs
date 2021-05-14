using System.Linq;
using DataAccessLibrary.Abstract;
using DataAccessLibrary.Concrete.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLibrary.Concrete.EntityFramework
{
    public class EfWriterDal:GenericRepository<Writer,Context>,IWriterDal
    {
        public int WriterFilterCount()
        {
            using (Context context=new Context())
            {
               return context.Writers.Count(x => x.WriterName.Contains("a"));
            }
        }
    }
}
