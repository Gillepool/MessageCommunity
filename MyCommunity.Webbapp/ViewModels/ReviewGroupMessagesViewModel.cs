using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCommunity.Webbapp.ViewModels
{
    public class ReviewGroupMessagesViewModel
    {
        public int MessageId { get; set; }
        public string MessageTitle { get; set; }
        public string MessageBody { get; set; }
        public Boolean IsRead { get; set; }
        public DateTime Date { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public UserInformationViewModel Sender { get; set; }
        public UserInformationViewModel Receiver { get; set; }
    }
}