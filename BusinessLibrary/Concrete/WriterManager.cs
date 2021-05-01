using BusinessLibrary.Abstract;
using DataAccessLibrary.Abstract;
using DataAccessLibrary.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Concrete
{
    public class WriterManager:IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public List<Writer> GetAll()
        {
            return _writerDal.GetAll();
        }
        public void AddWriter(Writer writer)
        {
            if (writer.WriterName=="" || writer.WriterName.Length<=3 || writer.WriterMail=="" || writer.WriterName.Length>=51)
            {
                //hata mesajı
            }
            _writerDal.Add(writer);
        }
        public void DeleteWriter(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void UpdateWriter(Writer writer)
        {
            _writerDal.Update(writer);
        }
        public List<Writer> ListWriter(Writer writer)
        {
            return _writerDal.List(e => e.WriterId == writer.WriterId);
        }
    }
}
