using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Dtos;

namespace BusinessLibrary.Abstract
{
    public interface IWriterService
    {
         List<Writer> GetAll();
        void AddWriter(WriterDto writerDto);
        void DeleteWriter(Writer writer);
        void UpdateWriter(WriterDto writerDto);
         List<Writer> ListWriter(Writer writer);
        Writer GetById(int id);
        WriterDto GetByIdOfWriterDto(int id);

    }
}
