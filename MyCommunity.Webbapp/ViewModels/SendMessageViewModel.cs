﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCommunity.Webbapp.ViewModels
{
    public class SendMessageViewModel
    {
        [Display(Name = "Email")]
        public string UserEmail { get; set; }
        public string Id { get; set; }
        public IEnumerable<SelectListItem> UserList { get; set; }
        public IEnumerable<String> UsersSelected { get; set; }
    }
}
