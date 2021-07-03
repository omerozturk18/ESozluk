using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        List<Category> GetAllActive();
        void AddCategory(Category category);
        void DeleteCategory(Category category);
        void UpdateCategory(Category category);
        List<Category> ListCategory(Category category);
        Category GetById(int id);
    }
}
