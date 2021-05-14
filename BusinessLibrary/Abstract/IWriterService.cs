using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Abstract
{
    public interface IWriterService
    {
         List<Writer> GetAll();
        void AddWriter(Writer writer);
        void DeleteWriter(Writer writer);
        void UpdateWriter(Writer writer);
         List<Writer> ListWriter(Writer writer);
        Writer GetById(int id);

    }
}
