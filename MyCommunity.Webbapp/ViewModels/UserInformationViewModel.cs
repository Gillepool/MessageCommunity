using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCommunity.Webbapp.ViewModels
{
    public class UserInformationViewModel
    {
        [Display(Name = "email")]
        public string Email { get; set; }
        [Display(Name = "Numer of unread messages")]
        public int NumberOfUnreadMessages { get; set; }
        public DateTime LastLogin { get; set; }
        [Display (Name = "Number of logins last month")]
        public int NumberOfLoginsLastMonth { get; set; }
        [Display(Name = "Numer of deleted messages")]
        public int NumberOfDeletedMessages { get; set; }
    }
}