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
        private readonly IUserLoginService userLoginService;

        public HomeController(IMessageService messageService, IUserService userService, IUserLoginService userLoginService)
        {
            this.messageService = messageService;
            this.userService = userService;
            this.userLoginService = userLoginService;
        }

        /// <summary>
        /// Returns user information data 
        /// </summary>
        /// <returns> A userinfoviewmodel object containing messages and login information </returns>
        public ActionResult Index()
        {
            UserInformationViewModel UserInfo = new UserInformationViewModel();
            var user = userService.GetUser(User.Identity.GetUserId());
            UserInfo.Email = user.Email;
            UserInfo.LastLogin = user.LastLogin;
            UserInfo.NumberOfUnreadMessages = user.NumberOfMessages - (user.NumberOfReadMessages - user.NumberOfdeletedMessages);
            var Logins = userLoginService.GetUserLogins(user.Id);
            UserInfo.NumberOfLoginsLastMonth = Logins.Count(l => l.TimeOfLogin > DateTime.Now.AddDays(-30));
            user.LastLogin = DateTime.Now;
            userService.UpdateUser(user);
            userService.updateDatabase();
            return View(UserInfo);
        }
    }
}