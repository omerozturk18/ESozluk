using System.Linq;
using DataAccessLibrary.Abstract;
using DataAccessLibrary.Concrete.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLibrary.Concrete.EntityFramework
{
    public class EfAdminDal : GenericRepository<Admin, Context>, IAdminDal
    {
    }
}
