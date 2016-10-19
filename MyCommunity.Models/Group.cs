using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunity.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public virtual ICollection<ApplicationUser> Members { get; set; }
        public virtual ICollection<GroupMessage> GroupMessages { get; set; }
    }
}
