using DataAccessLibrary.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Concrete
{
    public class AboutManager
    {
        GenericRepository<About> _genericRepository;

        public AboutManager(GenericRepository<About> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public List<About> GetAll()
        {
            return _genericRepository.GetAll();
        }
        public void AddAbout(About about)
        {
            if (about.AboutDetails1=="" || about.AboutDetails1.Length<=3 || about.AboutDetails2=="" || about.AboutDetails2.Length<=3)
            {
                //hata mesajı
            }
            _genericRepository.Add(about);
        }
        public void DeleteAbout(About about)
        {
            _genericRepository.Delete(about);
        }

        public void UpdateAbout(About about)
        {
            _genericRepository.Update(about);
        }
        public List<About> ListAbout(About about)
        {
           return _genericRepository.List(e=>e.AboutId==about.AboutId);
        }
    }
}
