using DataAccessLibrary.Abstract;
using DataAccessLibrary.Concrete.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLibrary.Concrete.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message, Context>, IMessageDal
    {
    }
}
