using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLibrary.Abstract;
using DataAccessLibrary.Abstract;
using EntityLayer.Concrete;
using Core.Utilities.Security.Hashing;

namespace BusinessLibrary.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }


        public void Register(AdminDto adminDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(adminDto.AdminPassword, out passwordHash, out passwordSalt);
            var admin = new Admin
            {
                AdminUserName =adminDto.AdminUserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                AdminRole = "c"
            };
            _adminDal.Add(admin);
        }

        public bool Login(string adminUserName, string adminPassword)
        {
            var userToCheck = _adminDal.Get(x=>x.AdminUserName==adminUserName);
            if (userToCheck == null) return false;
            if (!HashingHelper.VerifyPasswordHash(adminPassword, userToCheck.PasswordHash, userToCheck.PasswordSalt))return false;
            return true;
        }
    }
}