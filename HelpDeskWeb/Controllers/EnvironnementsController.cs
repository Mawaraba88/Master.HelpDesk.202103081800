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

namespace HelpDeskWeb.Controllers
{
    public class EnvironnementsController : Controller
    {
        private ModeleHelpDesk db = new ModeleHelpDesk();

        // GET: Environnements
        public async Task<ActionResult> Index()
        {
            return View(await db.Environnements.ToListAsync());
        }

        // GET: Environnements/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Environnement environnement = await db.Environnements.FindAsync(id);
            if (environnement == null)
            {
                return HttpNotFound();
            }
            return View(environnement);
        }

        // GET: Environnements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Environnements/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EnvironnementID,Libelle")] Environnement environnement)
        {
            if (ModelState.IsValid)
            {
                db.Environnements.Add(environnement);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(environnement);
        }

        // GET: Environnements/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Environnement environnement = await db.Environnements.FindAsync(id);
            if (environnement == null)
            {
                return HttpNotFound();
            }
            return View(environnement);
        }

        // POST: Environnements/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EnvironnementID,Libelle")] Environnement environnement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(environnement).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(environnement);
        }

        // GET: Environnements/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Environnement environnement = await db.Environnements.FindAsync(id);
            if (environnement == null)
            {
                return HttpNotFound();
            }
            return View(environnement);
        }

        // POST: Environnements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Environnement environnement = await db.Environnements.FindAsync(id);
            db.Environnements.Remove(environnement);
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
