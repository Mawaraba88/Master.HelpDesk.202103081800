using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Metier;
using System.Web.Security;
using HelpDeskWeb.Filters;

namespace HelpDeskWeb.Controllers
{
    public class ApplicationsController : Controller
    {
        private ModeleHelpDesk db = new ModeleHelpDesk();

        // GET: Applications
        public async Task<ActionResult> Index()
        {
            return View(await db.Applications.ToListAsync());
        }

        // GET: Applications/Details/5
        [CustomerAuthorisation(Roles = "Administrateur")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = await db.Applications.FindAsync(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // GET: Applications/Create
        [CustomerAuthorisation(Roles = "Administrateur")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Applications/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomerAuthorisation(Roles = "Administrateur")]
        public async Task<ActionResult> Create([Bind(Include = "ApplicationID,Libelle,Version")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Applications.Add(application);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(application);
        }

        // GET: Applications/Edit/5
        [CustomerAuthorisation(Roles = "Administrateur")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = await db.Applications.FindAsync(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applications/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomerAuthorisation(Roles = "Administrateur")]
        public async Task<ActionResult> Edit([Bind(Include = "ApplicationID,Libelle,Version")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(application).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(application);
        }

        // GET: Applications/Delete/5
        [CustomerAuthorisation(Roles = "Administrateur")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = await db.Applications.FindAsync(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [CustomerAuthorisation(Roles = "Administrateur")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Application application = await db.Applications.FindAsync(id);
            db.Applications.Remove(application);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
