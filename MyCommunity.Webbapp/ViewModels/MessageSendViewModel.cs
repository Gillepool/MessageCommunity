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
       
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "MessageTitle")]
        public string MessageTitle { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "MessageBody")]
        public string MessageBody { get; set; }

        [Display(Name = "Users")]
        public IEnumerable<SelectListItem> Users { get; set; }
        public IEnumerable<String> SelectedUsers { get; set; }

    }
}