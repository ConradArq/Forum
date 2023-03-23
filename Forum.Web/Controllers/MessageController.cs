using Forum.Repositories.Repositories.Messages;
using Forum.Utilities;
using Forum.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Web.Controllers
{
    [Authorize]
    public class MessageController : BaseController
    {

        private IMessageRepository messageRepository;

        public MessageController(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        [ElementOwnerAttribute(EntityType = typeof(MessageRepository))]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Utils.GetErrorViewResult(this.ViewData, null);
            }

            return View();
        }
    }
}