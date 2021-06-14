using System.Linq;
using DataAccessLibrary.Abstract;
using DataAccessLibrary.Concrete.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLibrary.Concrete.EntityFramework
{
    public class EfAuthDal : GenericRepository<Admin, Context>, IAuthDal
    {
    }
}
