﻿using DataAccessLibrary.Abstract;
using DataAccessLibrary.Concrete.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLibrary.Concrete.EntityFramework
{
    public class EfAboutDal : GenericRepository<About, Context>, IAboutDal
    {
    }
}
