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
    [Authorize]
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
            var receiver = userService.GetUser(userData.Id);
            Message message = Mapper.Map<MessageViewModel, Message>(newMessage);
            message.SenderId = User.Identity.GetUserId();
            message.ReceiverId = userData.Id;
            message.IsRead = false;
            message.MessageBody = newMessage.MessageBody;
            message.MessageTitle = newMessage.MessageTitle;
            message.Date = DateTime.Now;
            messageService.CreateMessage(message);
            messageService.SaveMessage();
            receiver.NumberOfMessages++;
            userService.updateUserDatabase();
            TempData["successMessage"] = "Meddelande nummer " 
                + message.MessageId 
                + " avsänt till " 
                + receiver.Email + ", " 
                + message.Date;
            return RedirectToAction("Index");
        }

        public ActionResult SendGroupMessage()
        {

            return null;
        }

        public ActionResult Index()
        {
            MessageSendViewModel MessageSendViewModel = new MessageSendViewModel();
            var sender = userService.GetUser(User.Identity.GetUserId());
            var user = userService.GetAllUsersBut(sender.Id).Select(a => new SelectListItem
            {
                Text = a.Email,
                Value = a.Id
            });

            MessageSendViewModel.UserList = new SelectList(user, "Value", "Text");
            return View(MessageSendViewModel);
        }

    }
}
