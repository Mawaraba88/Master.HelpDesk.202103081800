
using HelpDeskWeb.Filters;
using Outils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDeskWeb.Controllers
{
    [CustomerAuthorisation(Roles = GlobalConstants.AdminRole)]
    public abstract class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}