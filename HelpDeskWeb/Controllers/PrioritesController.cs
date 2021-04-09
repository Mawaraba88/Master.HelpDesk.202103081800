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
    public class PrioritesController : Controller
    {
        private ModeleHelpDesk db = new ModeleHelpDesk();

        // GET: Priorites
        public async Task<ActionResult> Index()
        {
            return View(await db.Priorites.ToListAsync());
        }

        // GET: Priorites/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Priorite priorite = await db.Priorites.FindAsync(id);
            if (priorite == null)
            {
                return HttpNotFound();
            }
            return View(priorite);
        }

        // GET: Priorites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Priorites/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PrioriteID,Libelle")] Priorite priorite)
        {
            if (ModelState.IsValid)
            {
                db.Priorites.Add(priorite);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(priorite);
        }

        // GET: Priorites/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Priorite priorite = await db.Priorites.FindAsync(id);
            if (priorite == null)
            {
                return HttpNotFound();
            }
            return View(priorite);
        }

        // POST: Priorites/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PrioriteID,Libelle")] Priorite priorite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priorite).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(priorite);
        }

        // GET: Priorites/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Priorite priorite = await db.Priorites.FindAsync(id);
            if (priorite == null)
            {
                return HttpNotFound();
            }
            return View(priorite);
        }

        // POST: Priorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Priorite priorite = await db.Priorites.FindAsync(id);
            db.Priorites.Remove(priorite);
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
