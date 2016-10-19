using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCommunity.Webbapp.ViewModels
{
    public class GroupViewModel
    {
        [Display(Name = "Group Name")]
        public string GroupName;
        public int GroupId;
    }
}