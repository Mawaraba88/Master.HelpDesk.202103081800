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
    public class HistoriquesController : Controller
    {
        private ModeleHelpDesk db = new ModeleHelpDesk();

        // GET: Historiques
        public async Task<ActionResult> Index()
        {
            var historiques = db.Historiques.Include(h => h.Assistant).Include(h => h.Priorite).Include(h => h.Resolution).Include(h => h.Statut).Include(h => h.Utilisateur);
            return View(await historiques.ToListAsync());
        }

        // GET: Historiques/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historique historique = await db.Historiques.FindAsync(id);
            if (historique == null)
            {
                return HttpNotFound();
            }
            return View(historique);
        }

        // GET: Historiques/Create
        public ActionResult Create()
        {
            ViewBag.AssistantID = new SelectList(db.Personnes, "ID", "Nom");
            ViewBag.PrioriteID = new SelectList(db.Priorites, "PrioriteID", "Libelle");
            ViewBag.ResolutionID = new SelectList(db.Resolutions, "ResolutionID", "Libelle");
            ViewBag.StatutID = new SelectList(db.Statuts, "StatutID", "Libelle");
            ViewBag.UtilisateurID = new SelectList(db.Personnes, "ID", "Nom");
            return View();
        }

        // POST: Historiques/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "HistoriqueID,DateCreation,Libelle,AssistantID,PieceJointeID,PrioriteID,ResolutionID,StatutID,UtilisateurID")] Historique historique)
        {
            if (ModelState.IsValid)
            {
                db.Historiques.Add(historique);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AssistantID = new SelectList(db.Personnes, "ID", "Nom", historique.AssistantID);
            ViewBag.PrioriteID = new SelectList(db.Priorites, "PrioriteID", "Libelle", historique.PrioriteID);
            ViewBag.ResolutionID = new SelectList(db.Resolutions, "ResolutionID", "Libelle", historique.ResolutionID);
            ViewBag.StatutID = new SelectList(db.Statuts, "StatutID", "Libelle", historique.StatutID);
            ViewBag.UtilisateurID = new SelectList(db.Personnes, "ID", "Nom", historique.UtilisateurID);
            return View(historique);
        }

        // GET: Historiques/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historique historique = await db.Historiques.FindAsync(id);
            if (historique == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssistantID = new SelectList(db.Personnes, "ID", "Nom", historique.AssistantID);
            ViewBag.PrioriteID = new SelectList(db.Priorites, "PrioriteID", "Libelle", historique.PrioriteID);
            ViewBag.ResolutionID = new SelectList(db.Resolutions, "ResolutionID", "Libelle", historique.ResolutionID);
            ViewBag.StatutID = new SelectList(db.Statuts, "StatutID", "Libelle", historique.StatutID);
            ViewBag.UtilisateurID = new SelectList(db.Personnes, "ID", "Nom", historique.UtilisateurID);
            return View(historique);
        }

        // POST: Historiques/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "HistoriqueID,DateCreation,Libelle,AssistantID,PieceJointeID,PrioriteID,ResolutionID,StatutID,UtilisateurID")] Historique historique)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historique).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AssistantID = new SelectList(db.Personnes, "ID", "Nom", historique.AssistantID);
            ViewBag.PrioriteID = new SelectList(db.Priorites, "PrioriteID", "Libelle", historique.PrioriteID);
            ViewBag.ResolutionID = new SelectList(db.Resolutions, "ResolutionID", "Libelle", historique.ResolutionID);
            ViewBag.StatutID = new SelectList(db.Statuts, "StatutID", "Libelle", historique.StatutID);
            ViewBag.UtilisateurID = new SelectList(db.Personnes, "ID", "Nom", historique.UtilisateurID);
            return View(historique);
        }

        // GET: Historiques/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historique historique = await db.Historiques.FindAsync(id);
            if (historique == null)
            {
                return HttpNotFound();
            }
            return View(historique);
        }

        // POST: Historiques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Historique historique = await db.Historiques.FindAsync(id);
            db.Historiques.Remove(historique);
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
