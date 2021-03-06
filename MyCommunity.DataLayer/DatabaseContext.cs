﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using MyCommunity.DataLayer.Configurations;
using MyCommunity.Models;
using MyCommunity.Webbapp.Models;

namespace MyCommunity.DataLayer
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext()
            : base("DatabaseContext", throwIfV1Schema: false)
        {
            //Database.SetInitializer<DatabaseContext>(new DropCreateDatabaseAlways<DatabaseContext>());
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
           

        public static DatabaseContext Create()
        {
                return new DatabaseContext();
        }
        
        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new LoginConfiguration());
            modelBuilder.Configurations.Add(new MessageConfiguration());
        }
    }
}
