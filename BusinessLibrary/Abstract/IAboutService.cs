using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Abstract
{
    public interface IAboutService
    {
         List<About> GetAll();
        void AddAbout(About about);
        void DeleteAbout(About about);
        void UpdateAbout(About about);
         List<About> ListAbout(About about);
    }
}
