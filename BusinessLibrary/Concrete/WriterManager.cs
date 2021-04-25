using DataAccessLibrary.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Concrete
{
    public class WriterManager
    {
        GenericRepository<Writer> _genericRepository;

        public WriterManager(GenericRepository<Writer> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public List<Writer> GetAll()
        {
            return _genericRepository.GetAll();
        }
        public void AddWriter(Writer writer)
        {
            if (writer.WriterName=="" || writer.WriterName.Length<=3 || writer.WriterMail=="" || writer.WriterName.Length>=51)
            {
                //hata mesajı
            }
            _genericRepository.Add(writer);
        }
        public void DeleteWriter(Writer writer)
        {
            _genericRepository.Delete(writer);
        }

        public void UpdateWriter(Writer writer)
        {
            _genericRepository.Update(writer);
        }
        public List<Writer> ListWriter(Writer writer)
        {
            return _genericRepository.List(e => e.WriterId == writer.WriterId);
        }
    }
}
