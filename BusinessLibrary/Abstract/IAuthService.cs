using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using EntityLayer.Dtos;

namespace BusinessLibrary.Abstract
{
   public interface IAuthService
    {
        Admin Login(LoginDto loginDto);
        Writer WriterLogin(LoginDto loginDto);
        void WriterRegister(WriterDto writerDto);
    }
}
