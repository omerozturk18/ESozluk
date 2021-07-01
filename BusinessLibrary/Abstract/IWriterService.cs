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
        void UpdateWriterDto(WriterDto writerDto);
        void UpdateWriter(Writer writer);
         List<Writer> ListWriter(Writer writer);
        Writer GetById(int id);
        WriterDto GetByIdOfWriterDto(int id);
        WriterDto GetByWriterDto(string writerUserName);

    }
}
