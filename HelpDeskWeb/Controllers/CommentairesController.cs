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
    public class CommentairesController : Controller
    {
        private ModeleHelpDesk db = new ModeleHelpDesk();

        // GET: Commentaires
        public async Task<ActionResult> Index()
        {
            var commentaires = db.Commentaires.Include(c => c.Assistant).Include(c => c.Ticket);
            return View(await commentaires.ToListAsync());
        }

        // GET: Commentaires/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commentaire commentaire = await db.Commentaires.FindAsync(id);
            if (commentaire == null)
            {
                return HttpNotFound();
            }
            return View(commentaire);
        }

        // GET: Commentaires/Create
        public ActionResult Create()
        {
            ViewBag.AssistantID = new SelectList(db.Personnes, "ID", "Nom");
            ViewBag.TicketId = new SelectList(db.Tickets, "TicketID", "Resume");
            return View();
        }

        // POST: Commentaires/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CommentaireID,Contenu,AssistantID,TicketId")] Commentaire commentaire)
        {
            if (ModelState.IsValid)
            {
                db.Commentaires.Add(commentaire);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AssistantID = new SelectList(db.Personnes, "ID", "Nom", commentaire.AssistantID);
            ViewBag.TicketId = new SelectList(db.Tickets, "TicketID", "Resume", commentaire.TicketId);
            //return View(commentaire);

            return PartialView("_PartialCommentaire");
        }

        // GET: Commentaires/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commentaire commentaire = await db.Commentaires.FindAsync(id);
            if (commentaire == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssistantID = new SelectList(db.Personnes, "ID", "Nom", commentaire.AssistantID);
            ViewBag.TicketId = new SelectList(db.Tickets, "TicketID", "Resume", commentaire.TicketId);
            return View(commentaire);
        }

        // POST: Commentaires/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CommentaireID,Contenu,AssistantID,TicketId")] Commentaire commentaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentaire).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AssistantID = new SelectList(db.Personnes, "ID", "Nom", commentaire.AssistantID);
            ViewBag.TicketId = new SelectList(db.Tickets, "TicketID", "Resume", commentaire.TicketId);
            return View(commentaire);
        }

        // GET: Commentaires/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commentaire commentaire = await db.Commentaires.FindAsync(id);
            if (commentaire == null)
            {
                return HttpNotFound();
            }
            return View(commentaire);
        }

        // POST: Commentaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Commentaire commentaire = await db.Commentaires.FindAsync(id);
            db.Commentaires.Remove(commentaire);
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
