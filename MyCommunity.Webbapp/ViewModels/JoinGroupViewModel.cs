using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCommunity.Webbapp.ViewModels
{
    public class JoinGroupViewModel
    {
        [Display(Name = "Group Name")]

        public IEnumerable<SelectListItem> GroupList { get; set; }
        public int GroupId { get; set; }
    }

}