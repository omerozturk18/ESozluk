using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Dtos;

namespace DataAccessLibrary.Abstract
{
    public interface IWriterDal:IRepository<Writer>
    {
        WriterDto GetWriterDto(string userName);
        WriterDto GetByIdOfWriterDto(int id);
    }
}
