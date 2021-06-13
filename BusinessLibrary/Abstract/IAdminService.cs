using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLibrary.Abstract
{
    interface IAdminService
    {
        void Register(AdminDto adminDto);
        bool Login(string adminUserName,string adminPassword);
    }
}
