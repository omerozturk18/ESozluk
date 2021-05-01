using BusinessLibrary.Abstract;
using DataAccessLibrary.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLibrary.Concrete
{
    public class CategoryManager:ICategoryService
    {
        ICategoryDal _categoryDal;

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
            if (category.CategoryName==""||category.CategoryName.Length<=3||category.CategoryDescription==""||category.CategoryName.Length>=51)
            {
                //hata mesajı
            }
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
    }
}
