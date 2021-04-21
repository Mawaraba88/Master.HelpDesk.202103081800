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
using Metier.Domaine;
using HelpDeskWeb.Filters;

namespace HelpDeskWeb.Controllers
{
    public class RolesController : Controller
    {
        private ModeleHelpDesk db = new ModeleHelpDesk();

        // GET: Roles
        [CustomerAuthorisation]
        public async Task<ActionResult> Index()
        {
            return View(await db.Roles.ToListAsync());
        }

        // GET: Roles/Details/5
        [CustomerAuthorisation]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = await db.Roles.FindAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: Roles/Create
        [CustomerAuthorisation]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomerAuthorisation]
        public async Task<ActionResult> Create([Bind(Include = "RoleID,Libelle")] Role role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(role);
        }

        // GET: Roles/Edit/5
        [CustomerAuthorisation]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = await db.Roles.FindAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomerAuthorisation]
        public async Task<ActionResult> Edit([Bind(Include = "RoleID,Libelle")] Role role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: Roles/Delete/5
        [CustomerAuthorisation]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = await db.Roles.FindAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [CustomerAuthorisation]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Role role = await db.Roles.FindAsync(id);
            db.Roles.Remove(role);
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
