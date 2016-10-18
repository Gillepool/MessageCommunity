using MyCommunity.Webbapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommunity.Models
{
    public class UserLogin
    {
        public int LoginId { get; set; }
        public DateTime TimeOfLogin { get; set; }
        public virtual ApplicationUser LoggedInUser { get; set; }
    }
}
