using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Abstract
{
    public interface IHeadingService
    {
         List<Heading> GetAll();
        void AddHeading(Heading heading);
        void DeleteHeading(Heading heading);
        void UpdateHeading(Heading heading);
         List<Heading> ListHeading(Heading heading);
         Heading GetById(int id);
         List<Heading> GetByWriter(int id);
         List<Heading> GetByWriterOfStatus(int id);
         List<Heading> GetByCategory(int id);
    }
}
