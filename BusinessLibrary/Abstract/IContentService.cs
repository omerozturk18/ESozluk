using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Abstract
{
    public interface IContentService
    {
         List<Content> GetAll();
        void AddContent(Content content);
        void DeleteContent(Content content);
        void UpdateContent(Content content);
         List<Content> ListByHeadingId(int id);
         List<Content> ListByWriterId(int id);
         Content GetById(int id);

    }
}
