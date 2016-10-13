using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCommunity.Webbapp.ViewModels
{
    public class MessageSendViewModel
    {
        [Display(Name = "Email")]
        public string UserEmail { get; set; }
        public string Id { get; set; }
        public IEnumerable<SelectListItem> UserList { get; set; }
    }
}
