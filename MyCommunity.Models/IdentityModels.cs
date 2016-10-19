﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyCommunity.Models;
using System;

namespace MyCommunity.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public int NumberOfMessages { get; set; }
        public int NumberOfReadMessages { get; set; }
        public int NumberOfdeletedMessages { get; set; }

        public DateTime LastLogin { get; set; }
        public int numberOfLoginsLastMonth { get; set; }

        public virtual ICollection<Message> PublishedMessages { get; set; }
        public virtual ICollection<Message> ReceiverMessages { get; set; }
        public virtual ICollection<UserLogin> UserLogins { get; set; } 
        public virtual ICollection<Group> Groups { get; set; }
        
    }
}