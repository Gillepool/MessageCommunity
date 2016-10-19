using AutoMapper;
using Microsoft.AspNet.Identity;
using MyCommunity.Models;
using MyCommunity.Service;
using MyCommunity.Webbapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCommunity.Webbapp.Controllers
{
    [Authorize]
    public class JoinGroupController : Controller
    {
        private readonly IUserService userService;
        private readonly IUserLoginService userLoginService;
        private readonly IGroupService groupService;

        public JoinGroupController(IUserService userService, IUserLoginService userLoginService, IGroupService groupService)
        {
            this.userService = userService;
            this.userLoginService = userLoginService;
            this.groupService = groupService;
        }

        // GET: Group
        public ActionResult Index()
        {
            var user = userService.GetUser(User.Identity.GetUserId());

            JoinGroupViewModel joinGroupViewModel = new JoinGroupViewModel();
            IEnumerable<Group> group = groupService.GetAllGroups();
            var result = group.Except(user.Groups).Select(a => new SelectListItem
            {
                Text = a.GroupName,
                Value = a.GroupId.ToString()
            });

            joinGroupViewModel.GroupList = new SelectList(result, "Value", "Text");
            return View(joinGroupViewModel);

        }


        public ActionResult JoinGroup(JoinGroupViewModel joinGroupViewModel)
        {
            var user = userService.GetUser(User.Identity.GetUserId());

            Group group = groupService.GetGroupByIntId(joinGroupViewModel.GroupId);
            try
            {
                user.Groups.Add(group);
                userService.updateUserDatabase();
                TempData["GroupJoinMessage"] = "You have successfully joined the group: " + group.GroupName;
            }
            catch
            {
                TempData["GroupJoinMessage"] = "Failed to join group";
            }

            return RedirectToAction("Index");
        }
    }
}