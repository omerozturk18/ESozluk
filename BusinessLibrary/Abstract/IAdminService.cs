using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using EntityLayer.Dtos;

namespace BusinessLibrary.Abstract
{
   public interface IAdminService
    {
        Admin GetByAdmin(string adminUserName);
        List<Admin> GetAll();
        void AddAdmin(AdminDto adminDto);
        void DeleteAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
        List<Admin> ListAdmin(Admin admin);
    }
}
