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
        [Display(Name = "NumerOfUnreadMessages")]
        public int NumberOfUnreadMessages { get; set; }
        //public DateTime LastLogin { get; set; }
        [Display (Name = "NumberOfLoginsLastMonth")]
        public int NumberOfLoginsLastMonth { get; set; }
    }
}