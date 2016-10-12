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
            IEnumerable<MessageViewModel> messageViewModel;
            IEnumerable<Message> messages;

            messages = messageService.GetMessages();

            messageViewModel = Mapper.Map<IEnumerable<Message>, IEnumerable<MessageViewModel>>(messages);
            return View(messageViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Create(MessageSendViewModel newMessage)
        {
            /*
            IEnumerable<string> AllReceivers = new List<string>();
           
            if (newMessage != null)
            {
                if (newMessage.SelectedUsers != null && newMessage.SelectedUsers.Any())
                    AllReceivers = AllReceivers.Union(newMessage.SelectedUsers);

                if (AllReceivers.Any()) {
                    if (ModelState.IsValid) {
                        Message dbMessage = new Message();
                        var sender = userService.GetUser(User.Identity.GetUserId());
                        dbMessage.SenderId = sender.Id;
                        dbMessage.MessageTitle = newMessage.Title;
                        dbMessage.MessageBody = newMessage.Content;
                        dbMessage.IsRead = false;
                        dbMessage.Date = DateTime.Now;

                        var Receiver = (ApplicationUser)null;
                        foreach (string userId in AllReceivers) {
                            Receiver = userService.GetUser(userId);
                            dbMessage.ReceiverId = Receiver.Id;
                            messageService.CreateMessage(dbMessage);
                            messageService.SaveMessage();
                        }

                        return RedirectToAction("Index");
                    }
                }
                */
            var sender = userService.GetUser(User.Identity.GetUserId());
            Message message = Mapper.Map<MessageSendViewModel, Message>(newMessage);
            message.SenderId = sender.Id;
            message.MessageTitle = newMessage.MessageTitle;
            message.MessageBody = newMessage.MessageBody;
            message.IsRead = false;
            message.Date = DateTime.Now;

            messageService.CreateMessage(message);

            messageService.SaveMessage();


            return RedirectToAction("Index");

        }
     }
}