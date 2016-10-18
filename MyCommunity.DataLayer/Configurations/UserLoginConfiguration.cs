using MyCommunity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunity.DataLayer.Configurations
{
    public class UserLoginConfiguration : EntityTypeConfiguration<UserLogin>
    {
        public UserLoginConfiguration()
        {
            ToTable("UserLogins");
            HasKey(u => u.UserLoginId);
            Property(u => u.TimeOfLogin).IsRequired();
        }
    }
}
