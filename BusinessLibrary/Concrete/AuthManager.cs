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
    public class AuthManager : IAuthService
    {
        private readonly IAuthDal _authDal;

        public AuthManager(IAuthDal authDal)
        {
            _authDal = authDal;
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
            _authDal.Add(admin);
        }

        public Admin Login(string adminUserName, string adminPassword)
        {
            var userToCheck = _authDal.Get(x=>x.AdminUserName==adminUserName);
            if (userToCheck == null) return null;
            if (!HashingHelper.VerifyPasswordHash(adminPassword, userToCheck.PasswordHash, userToCheck.PasswordSalt))return null;
            return userToCheck;
        }

        public Admin GetByAdmin(string adminUserName)
        {
            return _authDal.Get(x => x.AdminUserName == adminUserName);
        }
    }
}