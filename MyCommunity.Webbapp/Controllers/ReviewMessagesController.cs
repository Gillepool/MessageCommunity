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