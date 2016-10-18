using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCommunity.Models;

namespace MyCommunity.DataLayer
{
    public class MessageSeedData : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            GetMessages().ForEach(m => context.Messages.Add(m));
            context.Commit();
        }

        private static List<Message> GetMessages()
        {
            return new List<Message>
            {
                new Message
                {
                    MessageTitle = "Title1",
                    MessageBody = "Body1",
                    IsRead=false,
                    Dates = DateTime.Parse("2014-01-01"),
                    SenderId="1",
                    ReceiverId="2",
                },
                new Message
                {
                    MessageTitle = "Title2",
                    MessageBody = "Body2",
                    IsRead=true,
                    Dates = DateTime.Parse("2014-04-01"),
                    SenderId="1",
                    ReceiverId="2",

                },
                new Message
                {
                    MessageTitle = "Title3",
                    MessageBody = "Body3",
                    IsRead=true,
                    Dates = DateTime.Parse("2014-04-02"),
                    SenderId="2",
                    ReceiverId="1",

                }
            };
        }
    }
}