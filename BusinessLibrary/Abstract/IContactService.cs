using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Abstract
{
    public interface IContactService
    {
         List<Contact> GetAll();
        void AddContact(Contact contact);
        void DeleteContact(Contact contact);
        void UpdateContact(Contact contact);
         List<Contact> ListContact(Contact contact);
         Contact GetById(int id);

    }
}
