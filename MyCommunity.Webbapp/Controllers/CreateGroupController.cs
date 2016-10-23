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
    public class CreateGroupController : Controller
    {

        private readonly IUserService userService;
        private readonly IUserLoginService userLoginService;
        private readonly IGroupService groupService;

        public CreateGroupController(IUserService userService, IUserLoginService userLoginService, IGroupService groupService)
        {
            this.userService = userService;
            this.userLoginService = userLoginService;
            this.groupService = groupService;
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Creates a group with the specified name
        /// </summary>
        /// <param name="GroupName"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateGroup(string GroupName)
        {
            ApplicationUser Creator = userService.GetUser(User.Identity.GetUserId());
            Group group = new Group();
            group.GroupName = GroupName;
            try {
                groupService.CreateGroup(group);
                groupService.UpdateGroupDatabase();
                Creator.Groups.Add(group);
                userService.updateDatabase();
                TempData["successMessage"] = "Gruppen skapades av" + Creator.Email;
            }
            catch {
                TempData["successMessage"] = "Gruppen skapades inte, kolla igenom dina fält";
            }
            return RedirectToAction("Index");
        }
    }
}