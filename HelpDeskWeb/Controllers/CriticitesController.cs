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
    public class CriticitesController : Controller
    {
        private ModeleHelpDesk db = new ModeleHelpDesk();

        // GET: Criticites
        public async Task<ActionResult> Index()
        {
            return View(await db.Criticites.ToListAsync());
        }

        // GET: Criticites/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criticite criticite = await db.Criticites.FindAsync(id);
            if (criticite == null)
            {
                return HttpNotFound();
            }
            return View(criticite);
        }

        // GET: Criticites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Criticites/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CriticiteID,Libelle")] Criticite criticite)
        {
            if (ModelState.IsValid)
            {
                db.Criticites.Add(criticite);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(criticite);
        }

        // GET: Criticites/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criticite criticite = await db.Criticites.FindAsync(id);
            if (criticite == null)
            {
                return HttpNotFound();
            }
            return View(criticite);
        }

        // POST: Criticites/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CriticiteID,Libelle")] Criticite criticite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(criticite).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(criticite);
        }

        // GET: Criticites/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criticite criticite = await db.Criticites.FindAsync(id);
            if (criticite == null)
            {
                return HttpNotFound();
            }
            return View(criticite);
        }

        // POST: Criticites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Criticite criticite = await db.Criticites.FindAsync(id);
            db.Criticites.Remove(criticite);
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
