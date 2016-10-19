using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCommunity.DataLayer.Infrastructure;
using MyCommunity.Models;

namespace MyCommunity.DataLayer.Repositories
{
    public class MessageRepository : BasicOperations<Message>, IMessageRepository
    {
        public MessageRepository(IDatabaseManager DbManager) : base(DbManager)
        {
        }

        public Message GetByIntId(int id)
        {
            throw new NotImplementedException();
        }

        public Message GetMessageByInt(int id)
        {
            return this.databaseContext.Messages.Where(m => m.MessageId == id).FirstOrDefault();
        }

        public IEnumerable<Message> GetUserMessagesIncludingSenderInfo(string id)
        {
            IList<Message> messages = new List<Message>();
            using (var db = DbManager.Init())
            {
                var result = from u in db.Users
                             join m in db.Messages on u.Id equals m.SenderId
                             where m.ReceiverId.Equals(id)
                             orderby u.Email
                             select new { Messages = m, Users = u };

                foreach (var resultMessage in result)
                {
                    Message message = resultMessage.Messages;
                    message.Sender = resultMessage.Users;
                    messages.Add(message);
                }
            }

            return messages;
        }
    }

    public interface IMessageRepository : GenericInterfaceRepository<Message>
    {
        IEnumerable<Message> GetUserMessagesIncludingSenderInfo(string id);
        Message GetMessageByInt(int id);
    }
}