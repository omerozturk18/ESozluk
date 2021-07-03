using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcPorject.Models;

namespace DataAccessLibrary.Abstract
{
    public interface ICategoryDal:IRepository<Category>
    {
    }
}
