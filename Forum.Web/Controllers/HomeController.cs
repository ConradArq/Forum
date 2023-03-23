using Forum.Core.Models.Messages;
using Forum.Repositories.Repositories.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

                Thread thread = new Thread()
                {
                    Name = "test",
                    CategoryID = 1,
                    ViewsCount = 0
                };

                ThreadRepository threadRepository = new ThreadRepository();
                threadRepository.Save(thread);

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}