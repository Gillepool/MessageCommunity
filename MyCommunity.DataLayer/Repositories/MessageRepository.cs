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

        public Message GetMessageByInt(int id)
        {
            return this.databaseContext.Messages.Where(m => m.MessageId == id).FirstOrDefault();
        }
    }

    public interface IMessageRepository : GenericInterfaceRepository<Message>
    {
        Message GetMessageByInt(int id);
    }
}