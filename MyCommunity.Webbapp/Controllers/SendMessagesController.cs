using AutoMapper;
using Microsoft.AspNet.Identity;
using MyCommunity.Models;
using MyCommunity.Service;
using MyCommunity.Webbapp.Models;
using MyCommunity.Webbapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCommunity.Webbapp.Controllers
{

    public class SendMessagesController : Controller
    {
        private readonly IMessageService messageService;
        private readonly IUserService userService;

        public SendMessagesController(IMessageService messageService, IUserService userService)
        {
            this.messageService = messageService;
            this.userService = userService;
        }

        // Post: SendMessages
        [HttpPost]
        public ActionResult SendPersonalMessage(MessageViewModel newMessage, MessageSendViewModel userData)
        {
            var sender = userService.GetUser(User.Identity.GetUserId());
            Message message = Mapper.Map<MessageViewModel, Message>(newMessage);
            message.SenderId = sender.Id;
            message.ReceiverId = userData.Id;
            message.IsRead = false;
            message.MessageBody = newMessage.MessageBody;
            message.MessageTitle = newMessage.MessageTitle;
            message.Date = DateTime.Now;
            System.Diagnostics.Debug.WriteLine("sender id " + message.SenderId);
            System.Diagnostics.Debug.WriteLine("receiver id" + message.ReceiverId);
            System.Diagnostics.Debug.WriteLine("message body" + message.MessageBody);
            System.Diagnostics.Debug.WriteLine("message title" + message.MessageTitle);
            messageService.CreateMessage(message);
            System.Diagnostics.Debug.WriteLine("after create message");
            messageService.SaveMessage();
            System.Diagnostics.Debug.WriteLine("after save Message");
            sender.NumberOfMessages++;
            System.Diagnostics.Debug.WriteLine("before Update User");
            userService.updateUser();
            System.Diagnostics.Debug.WriteLine("after update user");
            Response.Write("you did it!");
            //ViewBag.MessageSuccess = "Message successfully sent";
            //return ViewBag();
            TempData["successMessage"] = "Meddelande nummer " + sender.NumberOfMessages + " avsänt till " + sender.Email + ", " + message.Date;
            return RedirectToAction("Index");
        }

        public ActionResult SendGroupMessage()
        {
            User.Identity.GetUserId();
            return null;
        }

        public ActionResult Index()
        {
            MessageSendViewModel MessageSendViewModel = new MessageSendViewModel();
            var user = userService.GetUsers().Select(a => new SelectListItem
            {
                Text = a.Email,
                Value = a.Id
            });

            MessageSendViewModel.UserList = new SelectList(user, "Value", "Text");
            return View(MessageSendViewModel);
        }

    }
}
