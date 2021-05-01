using BusinessLibrary.Abstract;
using DataAccessLibrary.Abstract;
using DataAccessLibrary.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Concrete
{
    public class AboutManager:IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public List<About> GetAll()
        {
            return _aboutDal.GetAll();
        }
        public void AddAbout(About about)
        {
            if (about.AboutDetails1=="" || about.AboutDetails1.Length<=3 || about.AboutDetails2=="" || about.AboutDetails2.Length<=3)
            {
                //hata mesajı
            }
            _aboutDal.Add(about);
        }
        public void DeleteAbout(About about)
        {
            _aboutDal.Delete(about);
        }

        public void UpdateAbout(About about)
        {
            _aboutDal.Update(about);
        }
        public List<About> ListAbout(About about)
        {
           return _aboutDal.List(e=>e.AboutId==about.AboutId);
        }
    }
}
