using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCommunity.Models;

namespace MyCommunity.DataLayer.Configurations
{
    class MessageConfiguration : EntityTypeConfiguration<Message>
    {
        public MessageConfiguration()
        {
            ToTable("Messages");
            HasKey(m => m.MessageId);
            Property(m => m.MessageBody).IsRequired().HasMaxLength(255);
            Property(m => m.MessageTitle).IsRequired().HasMaxLength(50);
            Property(m => m.Dates).IsRequired();
            this.HasRequired(x => x.Receiver).WithMany(x => x.ReceiverMessages).HasForeignKey(x => x.ReceiverId).WillCascadeOnDelete(false);
            this.HasRequired(x => x.Sender).WithMany(x => x.PublishedMessages).HasForeignKey(x => x.SenderId).WillCascadeOnDelete(false);
        }
    }
}
