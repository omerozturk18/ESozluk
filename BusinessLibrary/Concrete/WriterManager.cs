using BusinessLibrary.Abstract;
using DataAccessLibrary.Abstract;
using DataAccessLibrary.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Security.Hashing;
using EntityLayer.Dtos;

namespace BusinessLibrary.Concrete
{
    public class WriterManager:IWriterService
    {
        private readonly IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public List<Writer> GetAll()
        {
            return _writerDal.GetAll();
        }
        public void AddWriter(WriterDto writerDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(writerDto.WriterPassword, out passwordHash, out passwordSalt);
            var writer = new Writer
            {
                WriterName = writerDto.WriterName,
                WriterSurName = writerDto.WriterSurName,
                WriterImage = writerDto.WriterImage,
                WriterAbout = writerDto.WriterAbout,
                WriterMail = writerDto.WriterMail,
                WriterTitle = writerDto.WriterTitle,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                WriterStatus = true
            };
            _writerDal.Add(writer);
        }
        public void DeleteWriter(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void UpdateWriter(WriterDto writerDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(writerDto.WriterPassword, out passwordHash, out passwordSalt);
            var writer = new Writer
            {
                WriterName = writerDto.WriterName,
                WriterSurName = writerDto.WriterSurName,
                WriterImage = writerDto.WriterImage,
                WriterAbout = writerDto.WriterAbout,
                WriterMail = writerDto.WriterMail,
                WriterTitle = writerDto.WriterTitle,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                WriterStatus = true
            };
            _writerDal.Update(writer);
        }
        public List<Writer> ListWriter(Writer writer)
        {
            return _writerDal.List(e => e.WriterId == writer.WriterId);
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(c => c.WriterId == id);
        }
        public WriterDto GetByIdOfWriterDto(int id)
        {
            var writer = _writerDal.Get(c => c.WriterId == id);
            var writerDto = new WriterDto
            {
                WriterName = writer.WriterName,
                WriterSurName = writer.WriterSurName,
                WriterImage = writer.WriterImage,
                WriterAbout = writer.WriterAbout,
                WriterMail = writer.WriterMail,
                WriterTitle = writer.WriterTitle,
                WriterStatus = writer.WriterStatus
            };
            return writerDto;
        }
    }
}
