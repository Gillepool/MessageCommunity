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

        public GroupController(IMessageService messageService, IUserService userService, IUserLoginService userLoginService, IGroupService groupService)
        {
            this.messageService = messageService;
            this.userService = userService;
            this.userLoginService = userLoginService;
            this.groupService = groupService;
        }

        /// <summary>
        /// Fetches all the groups the current user has joined
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            var user = userService.GetUser(User.Identity.GetUserId());
            IEnumerable<GroupViewModel> groupViewModels = Mapper.Map<IEnumerable<Group>, IEnumerable<GroupViewModel>>(user.Groups);
            return View(groupViewModels);
        }

        /// <summary>
        /// View all messages from a specific group
        /// </summary>
        /// <param name="groupId">The id identifying the group</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult ViewGroupMessages(string id)
        {
            if(id == null) {
                 throw new ArgumentNullException("No id provided");
            }
            var group = groupService.GetGroupById(Int32.Parse(id));
            var messages = group.GroupMessages.OrderByDescending(m => m.PostDate);
            IEnumerable<GroupMessageViewModel> groupMessageViewModel = Mapper.Map<IEnumerable<GroupMessage>, IEnumerable<GroupMessageViewModel>>(messages);
            return Json(groupMessageViewModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creates a group message in database. 
        /// </summary>
        /// <param name="GroupId">Id of the group to receive the message</param>
        /// <param name="MessageVM">The content of the message</param>
        /// <returns>A string conatining a result message</returns>
        [HttpPost]
        public string SendGroupMessage(int? GroupId, GroupSendMessageViewModel MessageVM)
        {
            if (MessageVM == null || MessageVM.MessageTitle == null || GroupId == null || MessageVM.MessageBody == null)
            {
                return "Invalid input";
            }

            try
            {
                var user = userService.GetUser(User.Identity.GetUserId());
                Group group = groupService.GetGroupById(GroupId.Value);
                if (group == null)
                {
                    throw new ArgumentNullException("Group does not exist");
                }
                GroupMessage groupMessage = new GroupMessage();
                groupMessage.MessageTitle = MessageVM.MessageTitle;
                groupMessage.MessageBody = MessageVM.MessageBody;
                groupMessage.PostDate = DateTime.Now;
                groupMessage.GroupId = GroupId.Value;
                groupMessage.SenderId = user.Id;
                group.GroupMessages.Add(groupMessage);
                groupService.UpdateGroupDatabase();
                return "Message Succesfully sent";
            }
            catch
            {
                return "hahahahaha fail";
            }
        }

    }
}