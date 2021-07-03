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
    public class AuthManager : IAuthService
    {
        private readonly IAdminDal _adminDal;
        private readonly IWriterDal _writerDal;

        public AuthManager(IAdminDal adminDal, IWriterDal writerDal)
        {
            _adminDal = adminDal;
            _writerDal = writerDal;
        }


        public void Register(AdminDto adminDto)
        {
            HashingHelper.CreatePasswordHash(adminDto.AdminPassword, out var passwordHash, out var passwordSalt);
            var admin = new Admin
            {
                AdminUserName =adminDto.AdminUserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                AdminRole = "C",
                AdminStatus = true
            };
            _adminDal.Add(admin);
        }

        public Admin Login(LoginDto loginDto)
        {
            var userToCheck = _adminDal.Get(x=>x.AdminUserName==loginDto.UserName);
            if (userToCheck == null) return null; 
            if (!HashingHelper.VerifyPasswordHash(loginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt)) return null;

            return userToCheck;
        }
        public Writer WriterLogin(LoginDto loginDto)
        {
            var userToCheck = _writerDal.Get(x => x.WriterMail == loginDto.UserName);
            if (userToCheck == null)return null;
            if (!HashingHelper.VerifyPasswordHash(loginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt)) return null;
       
            return userToCheck;

        }

        public void WriterRegister(WriterDto writerDto)
        {
            HashingHelper.CreatePasswordHash(writerDto.WriterPassword, out var passwordHash, out var passwordSalt);
            var writer = new Writer
            {
                WriterName = writerDto.WriterName,
                WriterSurName = writerDto.WriterSurName,
                WriterImage = writerDto.WriterImage,
                WriterAbout = writerDto.WriterAbout,
                WriterMail = writerDto.WriterMail,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                WriterTitle = writerDto.WriterTitle,
                WriterStatus = true

            };
            _writerDal.Add(writer);
        }
    }
}