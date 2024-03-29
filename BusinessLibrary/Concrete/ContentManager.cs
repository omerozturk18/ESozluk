﻿using BusinessLibrary.Abstract;
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
        public List<Content> ListByHeadingId(int id)
        {
            return _contentDal.List(e => e.HeadingId == id);
        }
        public List<Content> ListByContentOfWriterId(int id)
        {
            return _contentDal.List(e => e.WriterId == id);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(c => c.ContentId == id);
        }

        public List<Content> Filter(string filter)
        {
            return   _contentDal.List(x => x.ContentValue.Contains(filter));
        }
    }
}
