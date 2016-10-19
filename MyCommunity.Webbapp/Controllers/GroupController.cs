using AutoMapper;
using Microsoft.AspNet.Identity;
using MyCommunity.Models;
using MyCommunity.Service;
using MyCommunity.Webbapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
       // private readonly IGroupMessageService groupMessageService;

        public GroupController(IMessageService messageService, IUserService userService, IUserLoginService userLoginService, IGroupService groupService)
        {
            this.messageService = messageService;
            this.userService = userService;
            this.userLoginService = userLoginService;
            this.groupService = groupService;
            //this.groupMessageService = groupMessageService;
        }

        // GET: Group
        [HttpGet]
        public ActionResult Index()
        {
            var user = userService.GetUser(User.Identity.GetUserId());
            IEnumerable<GroupViewModel> groupViewModels = Mapper.Map<IEnumerable<Group>, IEnumerable<GroupViewModel>>(user.Groups);
            return View(groupViewModels);
        }

        [HttpPost]
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

        [HttpGet]
        public JsonResult ViewGroupMessages(string id)
        {
            System.Diagnostics.Debug.WriteLine("ID: " + id);
            var group = groupService.GetGroupByIntId(Int32.Parse(id));
            var messages = group.GroupMessages.OrderByDescending(m => m.PostDate);
            System.Diagnostics.Debug.WriteLine("HERE!" + messages);
            IEnumerable<GroupMessageViewModel> groupMessageViewModel = Mapper.Map<IEnumerable<GroupMessage>, IEnumerable<GroupMessageViewModel>>(messages);
            foreach (GroupMessageViewModel gm in groupMessageViewModel) {
                System.Diagnostics.Debug.WriteLine("Foreach body: " + gm.MessageBody);
                System.Diagnostics.Debug.WriteLine("FOreach Title" + gm.MessageTitle);
            }
            return Json(groupMessageViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string SendGroupMessage(int? GroupId, GroupSendMessageViewModel MessageVM)
        {
            if (MessageVM == null || MessageVM.MessageTitle == null || GroupId == null || MessageVM.MessageBody == null) {
                 return "Invalid input";
            }
            System.Diagnostics.Debug.WriteLine("BEFORE TRYE1112112");
            var user = userService.GetUser(User.Identity.GetUserId());
            Group group = groupService.GetGroupByIntId(GroupId.Value);
            GroupMessage groupMessage = new GroupMessage();
            groupMessage.MessageTitle = MessageVM.MessageTitle;
            groupMessage.MessageBody = MessageVM.MessageBody;
            groupMessage.PostDate = DateTime.Now;
            groupMessage.GroupId = GroupId.Value;
            System.Diagnostics.Debug.WriteLine("USERID :" + User.Identity.GetUserId());
            groupMessage.SenderId = user.Id;
            System.Diagnostics.Debug.WriteLine("BEFORE TRYE");
            try
            {
                System.Diagnostics.Debug.WriteLine("HERE?!??!");
                group.GroupMessages.Add(groupMessage);
                System.Diagnostics.Debug.WriteLine("Message Added");
                groupService.UpdateGroupDatabase();
                System.Diagnostics.Debug.WriteLine("Database updated?!");
                return "Message Succesfully sent";

            }
            catch
            {
                return "hahahahaha fail";
            }
        }

    }
}