using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HelpDeskWeb.Filters
{
    public class CustomerAuthorisationAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            RedirectToRouteResult routeData = null;
            if(HttpContext.Current.User == null || string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
            {
                routeData = new RedirectToRouteResult(new RouteValueDictionary(
                   new
                   {
                       Controller = "Logins",
                       action = "Login"
                   }));
            }
            else
            {
                routeData = new RedirectToRouteResult(new RouteValueDictionary(
                  new
                  {
                      Controller = "Authorisation",
                      action = "AccessDenied"
                  }));

            }

            filterContext.Result = routeData;
        }
    }
}