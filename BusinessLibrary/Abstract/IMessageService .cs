using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Abstract
{
    public interface IMessageService
    {
         List<Message> GetAll();
        void AddMessage(Message message);
        void AddMessageDraft(Message message);
        void DeleteMessage(Message message);
        void UpdateMessage(Message message); 
        List<Message> GetAllInbox(string receiverMail); 
        List<Message> GetAllSendbox(string senderMail);
        List<Message> GetAllDraft(string senderMail);
        Message GetById(int id);

    }
}
