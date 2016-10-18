using MyCommunity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunity.DataLayer.Configurations
{
    class LoginConfiguration : EntityTypeConfiguration<UserLogin>
    {
        public LoginConfiguration()
        {
            ToTable("UserLogins");
            HasKey(m => m.LoginId);
            Property(m => m.TimeOfLogin).IsRequired();
        }
    }
}
