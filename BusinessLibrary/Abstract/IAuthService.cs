using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLibrary.Abstract
{
   public interface IAuthService
    {
        void Register(AdminDto adminDto);
        Admin Login(string adminUserName,string adminPassword);
        Admin GetByAdmin(string adminUserName);
    }
}
