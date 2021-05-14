using BusinessLibrary.Abstract;
using DataAccessLibrary.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;
using DataAccessLibrary.Concrete.EntityFramework;

namespace BusinessLibrary.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

   
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }
        public void AddCategory(Category category)
        {

            _categoryDal.Add(category);
        }
        public void DeleteCategory(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
        }
        public List<Category> ListCategory(Category category)
        {
            return _categoryDal.List(e => e.CategoryId == category.CategoryId);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(c => c.CategoryId == id);
        }
    }
}
