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

namespace MyCommunity.Webbapp.Controllers
{
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
            //MessageSendViewModel MessageSendViewModel = new MessageSendViewModel();
            //var user = userService.GetAllUsersThatSentMessagesToThisUser(userService.GetUser(User.Identity.GetUserId())).Select(a => new SelectListItem
            //{
            //    Text = a.Email,
            //    Value = a.Id
            //});

            //MessageSendViewModel.UserList = new SelectList(user, "Value", "Text");
            //return View(MessageSendViewModel);
            //IEnumerable<Message> messages = messageService.GetUserMessagesIncludingSenderInfo(User.Identity.GetUserId());
            //foreach (var message in messages)
            //{
            //    System.Diagnostics.Debug.WriteLine("message id" + message.MessageId);
            //    System.Diagnostics.Debug.WriteLine("message sender id" + message.SenderId);
            //    System.Diagnostics.Debug.WriteLine("message title" + message.MessageTitle);
            //    System.Diagnostics.Debug.WriteLine("message sender id" + message.Sender.Id);
            //    System.Diagnostics.Debug.WriteLine("message Email " + message.Sender.Email);
            //}
            //IEnumerable<ReviewMessageViewModel> messageViews = Mapper.Map<IEnumerable<Message>, IEnumerable<ReviewMessageViewModel>>(messages);

            //return View(messageViews);

            //IList<ReviewMessageViewModel> messageViews = new List<ReviewMessageViewModel>();
            //IEnumerable<Message> userMessages = messageService.GetUserMessagesIncludingSenderInfo(User.Identity.GetUserId());
            //foreach(Message message in userMessages)
            //{
            //    ReviewMessageViewModel messageView = new ReviewMessageViewModel();
            //    UserInformationViewModel sender = new UserInformationViewModel();
            //    messageView.Date = message.Date;
            //    messageView.IsRead = message.IsRead;
            //    messageView.MessageBody = message.MessageBody;
            //    messageView.MessageTitle = message.MessageTitle;
            //    messageView.ReceiverId = message.ReceiverId;
            //    messageView.SenderId = message.SenderId;
            //    sender.Email = message.Sender.Email;
            //    sender.NumberOfLoginsLastMonth = message.Sender.numberOfLoginsLastMonth;
            //    sender.NumberOfUnreadMessages = message.Sender.NumberOfMessages - message.Sender.NumberOfReadMessages;
            //    messageView.Sender = sender;

            //    messageViews.Add(messageView);
            //}

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


        public ActionResult ViewUserMessages(string id)
        {
            System.Diagnostics.Debug.WriteLine("id:" + id);
            IEnumerable<MessageViewModel> messageViews;
            IEnumerable<Message> messages = messageService.GetUserMessagesToFrom(User.Identity.GetUserId(), id);
            messageViews = Mapper.Map<IEnumerable<Message>, IEnumerable<MessageViewModel>>(messages);
            return View(messageViews);
        }

        [HttpPost]
        public ActionResult GoToViewUserMessages(string Id)
        {
            System.Diagnostics.Debug.WriteLine("id:" + Id);
            return RedirectToAction("ViewUserMessages", new { Id = Id });
        }

        // GET: ReviewMessages/Details/5
        public ActionResult Details(int Id)
        {
            return View();
        }

        // GET: ReviewMessages/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: ReviewMessages/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // GET: ReviewMessages/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReviewMessages/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}