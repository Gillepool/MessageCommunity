using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCommunity.Webbapp.ViewModels
{
    public class ReviewUserMessagesViewModel
    {
        public IEnumerable<UserMessageInfo> Messages { get; set; }


        public int TotalMessages { get; set; }
        public int ReadMessages { get; set; }
        public int DeletedMessages { get; set; }
    }

    public class UserMessageInfo
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Sender")]
        public string email { get; set; }

        [Required]
        public string userId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Unread Messages")]
        public int NumberOfMessages { get; set; }
    }
}