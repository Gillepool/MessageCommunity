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

       
        [HttpPost]
        public ActionResult SendMessage(MessageViewModel newMessage, SendMessageViewModel userData)
        {
            IEnumerable<string> Receivers = new List<string>();
            Receivers = userData.UsersSelected;
            if (newMessage == null || userData == null || newMessage.MessageBody == null || newMessage.MessageTitle == null || userData == null ||  Receivers == null)
            {
                TempData["successMessage"] = "ogiltigt input";
                return RedirectToAction("Index");
            }

            
            
            
            TempData["sucessMessage"] = "";
            foreach (string rc in Receivers)
            {
                
                System.Diagnostics.Debug.WriteLine(rc);
                var receiver = userService.GetUser(rc);
                Message message = Mapper.Map<MessageViewModel, Message>(newMessage);
                message.SenderId = User.Identity.GetUserId();
                message.ReceiverId = receiver.Id;
                message.IsRead = false;
                message.MessageBody = newMessage.MessageBody;
                message.MessageTitle = newMessage.MessageTitle;
                message.Dates = DateTime.Now;
                
                messageService.CreateMessage(message);
                receiver.NumberOfMessages++;
                try
                {
                    userService.updateUserDatabase();
                    TempData["successMessage"] += "Meddelande nummer " + message.MessageId + " avsänt till " + receiver.Email + ", " + message.Dates + Environment.NewLine;
                }
                catch
                {
                    TempData["successMessage"] += "Lol, du kunde inte skicka meddelande till " + receiver.Email;
                }
               
            }
           

            return RedirectToAction("Index");
        }

        public ActionResult SendGroupMessage()
        {

            return null;
        }

        public ActionResult Index()
        {
            SendMessageViewModel MessageSendViewModel = new SendMessageViewModel();
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
