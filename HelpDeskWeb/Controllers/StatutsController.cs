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
    public class StatutsController : Controller
    {
        private ModeleHelpDesk db = new ModeleHelpDesk();

        // GET: Statuts
        public async Task<ActionResult> Index()
        {
            return View(await db.Statuts.ToListAsync());
        }

        // GET: Statuts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statut statut = await db.Statuts.FindAsync(id);
            if (statut == null)
            {
                return HttpNotFound();
            }
            return View(statut);
        }

        // GET: Statuts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Statuts/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StatutID,Libelle")] Statut statut)
        {
            if (ModelState.IsValid)
            {
                db.Statuts.Add(statut);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(statut);
        }

        // GET: Statuts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statut statut = await db.Statuts.FindAsync(id);
            if (statut == null)
            {
                return HttpNotFound();
            }
            return View(statut);
        }

        // POST: Statuts/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StatutID,Libelle")] Statut statut)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statut).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(statut);
        }

        // GET: Statuts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statut statut = await db.Statuts.FindAsync(id);
            if (statut == null)
            {
                return HttpNotFound();
            }
            return View(statut);
        }

        // POST: Statuts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Statut statut = await db.Statuts.FindAsync(id);
            db.Statuts.Remove(statut);
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
