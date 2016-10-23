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

        /// <summary>
        /// Contains information of all messages as well as total number of messages to the user, 
        /// number of read messages by the user and deleted messages by the user
        /// </summary>
        /// <returns>ReviewUserMessagesViewModel</returns>
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

        /// <summary>
        /// Fetch all the messages sent to the current user, including read and unread messages
        /// </summary>
        /// <returns>IEnumerable<MessageViewModel></returns>
        [HttpGet]
        public ActionResult ViewUserMessages(string id)
        {
            IEnumerable<MessageViewModel> messageViews;
            IEnumerable<Message> messages = messageService.GetUserMessagesToFrom(User.Identity.GetUserId(), id);
            messageViews = Mapper.Map<IEnumerable<Message>, IEnumerable<MessageViewModel>>(messages);
            return View(messageViews);
        }

        /// <summary>
        /// Updates the database setting the message as read. Sends no feedback since this is behind the scene logic.
        /// </summary>
        /// <param name="Id">Id of the message</param>
        [HttpPost]
        public void messageRead(int? Id)
        {
            var user = userService.GetUser(User.Identity.GetUserId());
            if (Id == null)
            {
                return;
            }
            Message message = messageService.GetMessage(Id.Value);
            if(message == null)
            {
                return;
            }
            if (message.ReceiverId == user.Id)
            {
                if (!message.IsRead)
                {
                    user.NumberOfReadMessages++;
                    message.IsRead = true;
                    userService.updateDatabase();
                }
            }

        }

        /// <summary>
        /// Redirects the user to ViewUserMessages page of the user owning the id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GoToViewUserMessages(string Id)
        {
            if (Id == null)
                return RedirectToAction("Index");
            return RedirectToAction("ViewUserMessages", new { Id = Id });
        }

        /// <summary>
        /// Removes the message from the database. Updates the number of deleted messages of the user
        /// </summary>
        /// <param name="MessageId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int? MessageId)
        {
            var user = userService.GetUser(User.Identity.GetUserId());
            if (MessageId == null)
            {
                return RedirectToAction("index");
            }
            Message message = messageService.GetMessage(MessageId.Value);
            if(message == null)
            {
                TempData["fail"] = "Failed to remove message. It does not exist";
            }
            if (message.ReceiverId == user.Id)
            {
                try
                {
                    messageService.DeleteMessage(message);
                    user.NumberOfdeletedMessages++;
                    user.NumberOfMessages--;
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