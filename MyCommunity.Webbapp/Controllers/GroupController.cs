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
            var user = userService.GetUser(User.Identity.GetUserId());
            ReviewUserMessagesViewModel model = new ReviewUserMessagesViewModel();
            var UserMessages = messageService.GetUserMessages(user.Id).GroupBy(g => g.Sender).Select(m => new UserMessageInfo
            {
                email = m.Key.Email,
                userId = m.Key.Id,
                NumberOfMessages = m.Where(k => k.IsRead == false).Count()
            });
            model.Messages = UserMessages;
            model.TotalMessages = user.NumberOfMessages;
            model.ReadMessages = user.NumberOfReadMessages;
            model.DeletedMessages = user.NumberOfdeletedMessages;
            return RedirectToAction("Index");
        }

        public void JoinGroup(string id) {
            var user = userService.GetUser(User.Identity.GetUserId());

            Group group = groupService.GetGroupById(id);
            try {
                user.Groups.Add(group);
                userService.updateUserDatabase();
                TempData["GroupJoinMessage"] = "You have successfully joined the group: " + group.GroupName;
            } catch {
                TempData["GroupJoinMessage"] = "Failed to join group";
            } 
        }

        public void LeaveGroup(string id)
        {
            var user = userService.GetUser(User.Identity.GetUserId());

            Group group = groupService.GetGroupById(id);
            try
            {
                user.Groups.Remove(group);
                userService.updateUserDatabase();
                TempData["GroupJoinMessage"] = "You have successfully left the group: " + group.GroupName;
            }
            catch
            {
                TempData["GroupJoinMessage"] = "Failed to leave group sucker";
            }
        }
    }
}