using Forum.Repositories.Repositories.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Web.Controllers
{
    public class ThreadController : BaseController
    {

        private IThreadRepository threadRepository;

        public ThreadController(IThreadRepository threadRepository)
        {
            this.threadRepository = threadRepository;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}