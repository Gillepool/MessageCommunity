using MyCommunity.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCommunity.Webbapp.Controllers
{
    public class GroupController : Controller
    {
        private readonly IMessageService messageService;
        private readonly IUserService userService;
        private readonly IUserLoginService userLoginService;
        private readonly IGroupService groupService;

        public GroupController(IMessageService messageService, IUserService userService, IUserLoginService userLoginService, IGroupService groupService)
        {
            this.messageService = messageService;
            this.userService = userService;
            this.userLoginService = userLoginService;
            this.groupService = groupService;
        }

        // GET: Group
        public ActionResult Index()
        {
        
            return View();
        }
    }
}