using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCommunity.DataLayer.Infrastructure;
using MyCommunity.DataLayer.Repositories;
using MyCommunity.Models;

namespace MyCommunity.Service
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository messageRepository;
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public MessageService(IMessageRepository messageRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.messageRepository = messageRepository;
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateMessage(Message message)
        {
            messageRepository.Insert(message);
        }

        public void DeleteMessage(Message message)
        {
            messageRepository.Remove(message);
        }

        public Message GetMessage(string id)
        {
            return messageRepository.GetById(id);
        }

        public IEnumerable<Message> GetMessages()
        {
            return messageRepository.GetAll();
        }

        public IEnumerable<Message> GetUserMessages(string id)
        {
            return messageRepository.GetMany(m => m.ReceiverId == id);
        }

        public IEnumerable<Message> GetUserMessagesIncludingSenderInfo(string id)
        {
            //return messageRepository.GetUserMessagesIncludingSenderInfo(id);
            return null;
        }

        public void SaveMessage()
        {
            unitOfWork.CommitToDatabase();
        }

        public void DeleteMessage(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetUserMessagesToFrom(string receiver, string sender)
        {
            return messageRepository.GetMany(m => (m.ReceiverId == receiver) && (m.SenderId == sender));
        }
    }

    public interface IMessageService
    {
        IEnumerable<Message> GetMessages();
        IEnumerable<Message> GetUserMessages(string id);
        Message GetMessage(string id);
        IEnumerable<Message> GetUserMessagesIncludingSenderInfo(string id);
        void CreateMessage(Message message);
        void DeleteMessage(int id);
        void SaveMessage();
        IEnumerable<Message> GetUserMessagesToFrom(string v, string id);
    }
}