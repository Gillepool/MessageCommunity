using MyCommunity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunity.DataLayer.Configurations
{
    public class GroupMessageConfiguration : EntityTypeConfiguration<GroupMessage>
    {
        public GroupMessageConfiguration() {
            ToTable("GroupMessages");
            HasKey(g => g.GroupMessageId);
            Property(g => g.MessageBody).IsRequired().HasMaxLength(255);
            Property(g => g.MessageTitle).IsRequired().HasMaxLength(50);
            Property(g => g.PostDate).IsRequired();
        }
    }
}
