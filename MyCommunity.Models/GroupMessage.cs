using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunity.Models
{
    public class GroupMessage
    {
        public int GroupMessageId { get; set; }
        public string MessageTitle { get; set; }
        public string MessageBody { get; set; }
        public DateTime PostDate { get; set; }
        public string SenderId { get; set; }
        public int GroupId { get; set; }
        //Navigation properties
        public virtual Group Group { get; set; }
        public virtual ApplicationUser Sender { get; set; }
    }
}
