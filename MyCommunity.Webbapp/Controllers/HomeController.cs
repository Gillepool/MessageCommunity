using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using MyCommunity.Models;
using MyCommunity.Service;
using MyCommunity.Webbapp.Models;
using MyCommunity.Webbapp.ViewModels;

namespace MyCommunity.Webbapp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IMessageService messageService;
        private readonly IUserService userService;

        public HomeController(IMessageService messageService, IUserService userService)
        {
            this.messageService = messageService;
            this.userService = userService;
        }

        public ActionResult Index()
        {
            UserInformationViewModel UserInfo = new UserInformationViewModel();
            var user = userService.GetUser(User.Identity.GetUserId());
            UserInfo.Email = user.Email;
            // UserInfo.LastLogin = user.LastLogin;
            UserInfo.NumberOfUnreadMessages = user.NumberOfMessages - user.NumberOfReadMessages;
            UserInfo.NumberOfLoginsLastMonth = 0;
            return View(UserInfo);
        }


        public ActionResult GetMessages()
        {
            IEnumerable<MessageViewModel> MessageViewModels;
            IEnumerable<Message> Messages;
            var user = userService.GetUser(User.Identity.GetUserId());
            Messages = messageService.GetUserMessages(user.Id);
            MessageViewModels = Mapper.Map<IEnumerable<Message>, IEnumerable<MessageViewModel>>(Messages);
            return View(MessageViewModels);
        }
    }
}