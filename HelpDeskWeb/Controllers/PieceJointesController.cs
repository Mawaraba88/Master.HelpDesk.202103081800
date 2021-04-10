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
    public class PieceJointesController : Controller
    {
        private ModeleHelpDesk db = new ModeleHelpDesk();

        // GET: PieceJointes
        public async Task<ActionResult> Index()
        {
            return View(await db.PieceJointes.ToListAsync());
        }

        // GET: PieceJointes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PieceJointe pieceJointe = await db.PieceJointes.FindAsync(id);
            if (pieceJointe == null)
            {
                return HttpNotFound();
            }
            return View(pieceJointe);
        }

        // GET: PieceJointes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PieceJointes/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PieceJointeID,Content,Libelle")] PieceJointe pieceJointe)
        {
            if (ModelState.IsValid)
            {
                db.PieceJointes.Add(pieceJointe);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pieceJointe);
        }

        // GET: PieceJointes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PieceJointe pieceJointe = await db.PieceJointes.FindAsync(id);
            if (pieceJointe == null)
            {
                return HttpNotFound();
            }
            return View(pieceJointe);
        }

        // POST: PieceJointes/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PieceJointeID,Content,Libelle")] PieceJointe pieceJointe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pieceJointe).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pieceJointe);
        }

        // GET: PieceJointes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PieceJointe pieceJointe = await db.PieceJointes.FindAsync(id);
            if (pieceJointe == null)
            {
                return HttpNotFound();
            }
            return View(pieceJointe);
        }

        // POST: PieceJointes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PieceJointe pieceJointe = await db.PieceJointes.FindAsync(id);
            db.PieceJointes.Remove(pieceJointe);
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
