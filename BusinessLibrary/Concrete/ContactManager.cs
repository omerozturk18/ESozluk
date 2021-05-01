using BusinessLibrary.Abstract;
using DataAccessLibrary.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLibrary.Concrete
{
    public class ContactManager:IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public List<Contact> GetAll()
        {
            return _contactDal.GetAll();
        }
        public void AddContact(Contact contact)
        {
            if (contact.UserMail=="" || contact.UserName=="")
            {
                //hata mesajı
            }
            _contactDal.Add(contact);
        }
        public void DeleteContact(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public void UpdateContact(Contact contact)
        {
            _contactDal.Update(contact);
        }
        public List<Contact> ListContact(Contact contact)
        {
            return _contactDal.List(e => e.ContactId == contact.ContactId);
        }
    }
}
