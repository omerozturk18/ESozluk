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
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetAll()
        {
            return _messageDal.GetAll();
        }
        public void AddMessage(Message message)
        {
            _messageDal.Add(message);
        }
        public void AddMessageDraft(Message message)
        {
            _messageDal.Add(message);
        }
        public void DeleteMessage(Message message)
        {
            _messageDal.Delete(message);
        }

        public void UpdateMessage(Message message)
        {
            _messageDal.Update(message);
        }
        public List<Message> GetAllInbox(string receiverMail)
        {
           return _messageDal.List(e=>e.ReceiverMail== receiverMail && e.IsTheMessageIsDraft==false);
        }
        public List<Message> GetAllSendbox(string senderMail)
        {
            return _messageDal.List(e => e.SenderMail == senderMail && e.IsTheMessageIsDraft == false);
        }
        public List<Message> GetAllDraft(string senderMail)
        {
            return _messageDal.List(e => e.SenderMail == senderMail && e.IsTheMessageIsDraft == true);
        }
        public Message GetById(int id)
        {
            return _messageDal.Get(c => c.MessageId == id);
        }
    }
}
