using AutoMapper.QueryableExtensions;
using HelpDeskWeb.Service;
using HelpDeskWeb.ViewModels.Commentaires;
using HelpDeskWeb.ViewModels.Home;
using HelpDeskWeb.ViewModels.Ticket;
using Metier;
using Metier.Domaine;
using Metier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HelpDeskWeb.Controllers
{


    public class HomeController : Controller
    {
        private ModeleHelpDesk db = new ModeleHelpDesk();

        public HomeController()
        {

        }

        public ActionResult Index()
        {

            IQueryable<TicketViewModel> data = from ticket in db.Tickets

                                               group ticket by ticket.DateEcheance into dateGroup


                                               select new TicketViewModel()
                                               {
                                                   DateEcheance = dateGroup.Key,

                                                   TicketCount = dateGroup.Count()

                                               };

            return View(data.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


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