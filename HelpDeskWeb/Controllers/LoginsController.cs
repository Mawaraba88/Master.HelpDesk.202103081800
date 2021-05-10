using HelpDeskWeb.ViewModels;
using Metier;
using Metier.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HelpDeskWeb.Controllers
{
    public class LoginsController : Controller
    {
        private ModeleHelpDesk db;

        public LoginsController()
        {
            db = new ModeleHelpDesk();
        }
        // GET: Logins
        public ActionResult Login()

        {
          
            return View();
        }

        // POST: Logins
        [HttpPost]
       
        public ActionResult Login(LoginViewModel modelLogin)
        {
            Personne user = db.Assistants.Single(model => model.Email == modelLogin.Email);
           // Session["UserId"] = user;
            
            if (!db.Personnes.Any(model =>model.Email == modelLogin.Email))
            {
                ModelState.AddModelError("", "Cet email n'est pas valide");
                return View(modelLogin);
            }
            if (!db.Personnes.Any(model => model.MotDePasse == modelLogin.MotDePasse))
            {
                ModelState.AddModelError("", "Email et Mot de passe invalides");
                return View(modelLogin);
            }
            var roles = from objAssistantRole in db.Assistants
                           join objRole in db.Roles on objAssistantRole.RoleID equals objRole.RoleID
                           select objRole.Libelle;

            var roleName = string.Join(",", roles);
            FormsAuthentication.SetAuthCookie(modelLogin.Email, false);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, modelLogin.Email,
                DateTime.Now, DateTime.Now.AddMinutes(5), false, roleName);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            // If we got this far, something failed, redisplay form
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index", "Home");
        }
    }
}