using DataAccessLibrary.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Concrete
{
    public class HeadingManager
    {
        GenericRepository<Heading> _genericRepository;

        public HeadingManager(GenericRepository<Heading> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public List<Heading> GetAll()
        {
            return _genericRepository.GetAll();
        }
        public void AddHeading(Heading heading)
        {
            if (heading.HeadingName=="" || heading.HeadingName.Length<=3 || heading.HeadingName.Length>=51)
            {
                //hata mesajı
            }
            _genericRepository.Add(heading);
        }
        public void DeleteHeading(Heading heading)
        {
            _genericRepository.Delete(heading);
        }

        public void UpdateHeading(Heading heading)
        {
            _genericRepository.Update(heading);
        }
        public List<Heading> ListHeading(Heading heading)
        {
            return _genericRepository.List(e => e.HeadingId == heading.HeadingId);
        }
    }
}
