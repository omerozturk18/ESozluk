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
            HashingHelper.CreatePasswordHash(writerDto.WriterPassword, out var passwordHash, out var passwordSalt);
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

        public void UpdateWriterDto(WriterDto writerDto)
        {

            HashingHelper.CreatePasswordHash(writerDto.WriterPassword, out var passwordHash, out var passwordSalt);
            var writer = new Writer
            {
                WriterId = writerDto.WriterId,
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
        public void UpdateWriter(Writer writer)
        {
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
            return _writerDal.GetByIdOfWriterDto(id);
        }

        public Writer GetByWriter(string writerUserName)
        {
            return _writerDal.Get(x => x.WriterMail == writerUserName);
        }
        public WriterDto GetByWriterDto(string writerUserName)
        {
            return _writerDal.GetWriterDto(writerUserName);
        }
    }
}
