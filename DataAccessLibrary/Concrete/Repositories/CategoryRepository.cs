using DataAccessLibrary.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context _context;
        DbSet<Category> _categories;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public void Add(Category entity)
        {
            _categories.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Category entity)
        {
            _categories.Remove(entity);
            _context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return _categories.ToList();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            _context.SaveChanges();
        }
    }
}
