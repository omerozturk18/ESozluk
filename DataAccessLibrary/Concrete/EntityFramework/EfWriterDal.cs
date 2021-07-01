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

        public WriterDto GetWriterDto(string userName)
        {
            using (Context context = new Context())
            {
               Writer writer= context.Writers.SingleOrDefault(x => x.WriterMail == userName);
               var writerDto = new WriterDto
               {
                   WriterId = writer.WriterId,
                   WriterName = writer.WriterName,
                   WriterSurName = writer.WriterSurName,
                   WriterImage = writer.WriterImage,
                   WriterAbout = writer.WriterAbout,
                   WriterMail = writer.WriterMail,
                   WriterPassword = "123456Deneme",
                   WriterVerifyPassword = "123456Deneme",
                   WriterTitle = writer.WriterTitle,
                   WriterStatus = writer.WriterStatus
               };
               return writerDto;
            }
        }

        public WriterDto GetByIdOfWriterDto(int id)
        {
            using (Context context = new Context())
            {
                Writer writer = context.Writers.SingleOrDefault(x => x.WriterId == id);
                var writerDto = new WriterDto
                {
                    WriterId =  writer.WriterId,
                    WriterName = writer.WriterName,
                    WriterSurName = writer.WriterSurName,
                    WriterImage = writer.WriterImage,
                    WriterAbout = writer.WriterAbout,
                    WriterMail = writer.WriterMail,
                    WriterPassword = "123456Deneme",
                    WriterVerifyPassword = "123456Deneme",
                    WriterTitle = writer.WriterTitle,
                    WriterStatus = writer.WriterStatus
                };
                return writerDto;
            }
        }
    }
}
