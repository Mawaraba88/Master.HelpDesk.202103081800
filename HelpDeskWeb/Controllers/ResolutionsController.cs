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
    public class ResolutionsController : Controller
    {
        private ModeleHelpDesk db = new ModeleHelpDesk();

        // GET: Resolutions
        public async Task<ActionResult> Index()
        {
            return View(await db.Resolutions.ToListAsync());
        }

        // GET: Resolutions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resolution resolution = await db.Resolutions.FindAsync(id);
            if (resolution == null)
            {
                return HttpNotFound();
            }
            return View(resolution);
        }

        // GET: Resolutions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resolutions/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ResolutionID,Libelle")] Resolution resolution)
        {
            if (ModelState.IsValid)
            {
                db.Resolutions.Add(resolution);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(resolution);
        }

        // GET: Resolutions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resolution resolution = await db.Resolutions.FindAsync(id);
            if (resolution == null)
            {
                return HttpNotFound();
            }
            return View(resolution);
        }

        // POST: Resolutions/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ResolutionID,Libelle")] Resolution resolution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resolution).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(resolution);
        }

        // GET: Resolutions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resolution resolution = await db.Resolutions.FindAsync(id);
            if (resolution == null)
            {
                return HttpNotFound();
            }
            return View(resolution);
        }

        // POST: Resolutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Resolution resolution = await db.Resolutions.FindAsync(id);
            db.Resolutions.Remove(resolution);
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
