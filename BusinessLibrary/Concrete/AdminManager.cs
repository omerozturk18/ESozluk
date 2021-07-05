using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLibrary.Abstract;
using DataAccessLibrary.Abstract;
using EntityLayer.Concrete;
using Core.Utilities.Security.Hashing;
using EntityLayer.Dtos;

namespace BusinessLibrary.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public Admin GetByAdmin(string adminUserName)
        {
            return _adminDal.Get(x => x.AdminUserName == adminUserName);
        }
        public Admin GetByAdminId(int id)
        {
            return _adminDal.Get(x => x.AdminId == id);
        }

        public List<Admin> GetAll()
        {
            return _adminDal.GetAll();
        }

        public void AddAdmin(AdminDto adminDto)
        {
            HashingHelper.CreatePasswordHash(adminDto.AdminPassword, out var passwordHash, out var passwordSalt);
            var admin = new Admin
            {
                AdminUserName = adminDto.AdminUserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                AdminRole = "C",
                AdminStatus = true
            };
            _adminDal.Add(admin);
        }

        public void DeleteAdmin(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public void UpdateAdmin(Admin admin)
        {
            var a = GetByAdminId(admin.AdminId);
            admin.PasswordHash = a.PasswordHash;
            admin.PasswordSalt = a.PasswordSalt;
            _adminDal.Update(admin);
        }

        public List<Admin> ListAdmin(Admin admin)
        {
            return _adminDal.List(x=>x.AdminRole==admin.AdminRole);
        }
    }
}