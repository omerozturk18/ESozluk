using BusinessLibrary.Abstract;
using DataAccessLibrary.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLibrary.Concrete
{
    public class ContentManager:IContentService
    {
        private readonly IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public List<Content> GetAll()
        {
            return _contentDal.GetAll();
        }
        public void AddContent(Content content)
        {
            if (content.ContentValue==""|| content.ContentValue.Length<=15)
            {
                //hata mesajı
            }
            _contentDal.Add(content);
        }
        public void DeleteContent(Content content)
        {
            _contentDal.Delete(content);
        }

        public void UpdateContent(Content content)
        {
            _contentDal.Update(content);
        }
        public List<Content> ListContent(Content content)
        {
            return _contentDal.List(e => e.ContentId == content.ContentId);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(c => c.ContentId == id);
        }
    }
}
