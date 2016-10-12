using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCommunity.Webbapp.Models;

namespace MyCommunity.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MessageTitle { get; set; }
        public string MessageBody { get; set; }
        public Boolean IsRead { get; set; }
        public DateTime Date { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        //Navigation properties
        public virtual ApplicationUser Sender { get; set; }
        public virtual ApplicationUser Receiver { get; set; }
    }
}
