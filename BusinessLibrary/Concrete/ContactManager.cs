using DataAccessLibrary.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Concrete
{
    public class ContactManager
    {
        GenericRepository<Contact> _genericRepository;

        public ContactManager(GenericRepository<Contact> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public List<Contact> GetAll()
        {
            return _genericRepository.GetAll();
        }
        public void AddContact(Contact contact)
        {
            if (contact.UserMail=="" || contact.UserName=="")
            {
                //hata mesajı
            }
            _genericRepository.Add(contact);
        }
        public void DeleteContact(Contact contact)
        {
            _genericRepository.Delete(contact);
        }

        public void UpdateContact(Contact contact)
        {
            _genericRepository.Update(contact);
        }
        public List<Contact> ListContact(Contact contact)
        {
            return _genericRepository.List(e => e.ContactId == contact.ContactId);
        }
    }
}
