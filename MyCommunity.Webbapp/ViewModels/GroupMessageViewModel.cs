using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCommunity.Webbapp.ViewModels
{
    public class GroupMessageViewModel
    {
        public int GroupMessageId { get; set; }
        public string MessageTitle { get; set; }
        public string MessageBody { get; set; }
        public DateTime PostDate { get; set; }
        public string GroupSenderId { get; set; }
        public string GroupId { get; set; }
    }
}