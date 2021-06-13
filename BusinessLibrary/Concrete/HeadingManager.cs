using BusinessLibrary.Abstract;
using DataAccessLibrary.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLibrary.Concrete
{
    public class HeadingManager:IHeadingService
    {
        private readonly IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public List<Heading> GetAll()
        {
            return _headingDal.GetAll();
        }
        public void AddHeading(Heading heading)
        {
            if (heading.HeadingName=="" || heading.HeadingName.Length<=3 || heading.HeadingName.Length>=51)
            {
                //hata mesajı
            }
            _headingDal.Add(heading);
        }
        public void DeleteHeading(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public void UpdateHeading(Heading heading)
        {
            _headingDal.Update(heading);
        }
        public List<Heading> ListHeading(Heading heading)
        {
            return _headingDal.List(e => e.HeadingId == heading.HeadingId);
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(c => c.HeadingId == id);
        }

        public List<Heading> GetByWriter(int id)
        {
            return _headingDal.List(w => w.WriterId == id);
        }

        public List<Heading> GetByCategory(int id)
        {
            return _headingDal.List(c => c.CategoryId == id);
        }
    }
}
