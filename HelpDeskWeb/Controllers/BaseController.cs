﻿using Metier.Domaine;
using Metier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HelpDeskWeb.Controllers
{
    public class BaseController : Controller
    {
        protected IHelpDeskData Data { get; private set; }

        protected Personne PersonneProfile { get; private set; }

        public BaseController(IHelpDeskData data)
        {
            this.Data = data;
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.PersonneProfile = this.Data.Personnes.All().Where(u => u.Nom == requestContext.HttpContext.User.Identity.Name).FirstOrDefault();

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}