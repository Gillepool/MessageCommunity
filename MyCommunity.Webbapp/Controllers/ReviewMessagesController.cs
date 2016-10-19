using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using MyCommunity.Models;
using MyCommunity.Service;
using MyCommunity.Webbapp.ViewModels;
using System.Web.Services;

namespace MyCommunity.Webbapp.Controllers
{
    [Authorize]
    public class ReviewMessagesController : Controller
    {

        private readonly IMessageService messageService;
        private readonly IUserService userService;

        public ReviewMessagesController(IMessageService messageService, IUserService userService)
        {
            this.messageService = messageService;
            this.userService = userService;
        }

        // GET: ReviewMessages
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

            return View(model);
        }

        [HttpGet]
        public ActionResult ViewUserMessages(string id)
        {
            System.Diagnostics.Debug.WriteLine("id:" + id);
            IEnumerable<MessageViewModel> messageViews;
            IEnumerable<Message> messages = messageService.GetUserMessagesToFrom(User.Identity.GetUserId(), id);
            messageViews = Mapper.Map<IEnumerable<Message>, IEnumerable<MessageViewModel>>(messages);
            return View(messageViews);
        }

        [HttpPost]
        public void messageRead(int? Id)
        {
            System.Diagnostics.Debug.WriteLine("message read:" + Id);
            var user = userService.GetUser(User.Identity.GetUserId());
            if (Id == null)
            {
                return;
            }
            Message message = messageService.GetMessage(Id.Value);
            System.Diagnostics.Debug.WriteLine("past get message");
            if (message.ReceiverId == user.Id)
            {
                System.Diagnostics.Debug.WriteLine("past id check");
                if (!message.IsRead)
                {
                    System.Diagnostics.Debug.WriteLine("message wasnt read. set message read");
                    user.NumberOfReadMessages++;
                    message.IsRead = true;
                    messageService.SaveMessage();
                    userService.updateDatabase();
                }
            }
        }

        //TODO null check
        [HttpPost]
        public ActionResult GoToViewUserMessages(string Id)
        {
            System.Diagnostics.Debug.WriteLine("id:" + Id);
            return RedirectToAction("ViewUserMessages", new { Id = Id });
        }

        [HttpPost]
        public ActionResult Delete(int? MessageId)
        {
            var user = userService.GetUser(User.Identity.GetUserId());
            if (MessageId == null)
            {
                return RedirectToAction("index");
            }
            System.Diagnostics.Debug.WriteLine("message id" + MessageId);
            Message message = messageService.GetMessage(MessageId.Value);
            if (message.ReceiverId == user.Id)
            {
                try
                {
                    messageService.DeleteMessage(message);
                    user.NumberOfdeletedMessages++;
                    user.NumberOfMessages--;
                    messageService.SaveMessage();
                    userService.updateDatabase();
                }
                catch
                {
                    TempData["fail"] = "Failed to remove message";
                }
            }
            else
            {
                TempData["fail"] = "user does not own the message";
            }
            return RedirectToAction("ViewUserMessages", new { Id = message.SenderId });
        }
    }
}