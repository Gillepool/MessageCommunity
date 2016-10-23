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

        public Message GetMessage(int id)
        {
            return messageRepository.GetMessageByInt(id);
        }

        public IEnumerable<Message> GetAllMessages()
        {
            return messageRepository.GetAll();
        }

        public IEnumerable<Message> GetUserMessages(string id)
        {
            return messageRepository.GetMany(m => m.ReceiverId == id);
        }

        public void updateDatabase()
        {
            unitOfWork.CommitToDatabase();
        }

        public IEnumerable<Message> GetUserMessagesToFrom(string receiver, string sender)
        {
            return messageRepository.GetMany(m => (m.ReceiverId == receiver) && (m.SenderId == sender));
        }
    }

    public interface IMessageService
    {
        IEnumerable<Message> GetAllMessages();
        IEnumerable<Message> GetUserMessages(string id);
        Message GetMessage(int id);
        void CreateMessage(Message message);
        void DeleteMessage(Message message);
        void updateDatabase();
        IEnumerable<Message> GetUserMessagesToFrom(string receiver, string sender);
    }
}