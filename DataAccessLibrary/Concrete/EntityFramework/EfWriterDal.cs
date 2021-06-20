using System;
using System.Linq;
using System.Linq.Expressions;
using DataAccessLibrary.Abstract;
using DataAccessLibrary.Concrete.Repositories;
using EntityLayer.Concrete;
using EntityLayer.Dtos;

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
