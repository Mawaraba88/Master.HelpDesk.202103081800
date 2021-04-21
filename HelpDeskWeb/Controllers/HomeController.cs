using HelpDeskWeb.Service;
using Metier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDeskWeb.Controllers
{
    public class HomeController : BaseController
    {
        private IHomeServices homeServices;

    public HomeController()
        {

        }
        public HomeController(IHelpDeskData data, IHomeServices homeServices)
            :base(data)
        {
            this.homeServices = homeServices;
        }
        public ActionResult Index()
        {
            return View();
        }
        /*
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
        */
        public ActionResult Error()
        {
            return View();
        }
        [ChildActionOnly]
        [OutputCache(Duration = 60 * 60)]
        public ActionResult CommentairesTickets()
        {
            return PartialView("_CommentairesTicketPartialView");
        }
    }
}