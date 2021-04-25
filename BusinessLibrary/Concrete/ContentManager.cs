using DataAccessLibrary.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Concrete
{
    public class ContentManager
    {
        GenericRepository<Content> _genericRepository;

        public ContentManager(GenericRepository<Content> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public List<Content> GetAll()
        {
            return _genericRepository.GetAll();
        }
        public void AddContent(Content content)
        {
            if (content.ContentValue==""|| content.ContentValue.Length<=15)
            {
                //hata mesajı
            }
            _genericRepository.Add(content);
        }
        public void DeleteContent(Content content)
        {
            _genericRepository.Delete(content);
        }

        public void UpdateContent(Content content)
        {
            _genericRepository.Update(content);
        }
        public List<Content> ListContent(Content content)
        {
            return _genericRepository.List(e => e.ContentId == content.ContentId);
        }
    }
}
