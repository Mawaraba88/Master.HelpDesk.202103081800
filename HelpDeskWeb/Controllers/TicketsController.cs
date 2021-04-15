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
    public class TicketsController : Controller
    {
        private ModeleHelpDesk db = new ModeleHelpDesk();

        // GET: Tickets
        public async Task<ActionResult> Index()
        {
            var tickets = db.Tickets.Include(t => t.Applications).Include(t => t.Assistant).Include(t => t.Categorie).Include(t => t.Criticite).Include(t => t.Environnement).Include(t => t.Priorite).Include(t => t.Resolution).Include(t => t.Statut).Include(t => t.Type).Include(t => t.Utilisateur);
            return View(await tickets.ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = await db.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationID = new SelectList(db.Applications, "ApplicationID", "Libelle");
            ViewBag.AssistantID = new SelectList(db.Personnes, "ID", "Nom");
            ViewBag.CategorieID = new SelectList(db.Categories, "CategorieID", "Libelle");
            ViewBag.CriticiteID = new SelectList(db.Criticites, "CriticiteID", "Libelle");
            ViewBag.EnvironnementID = new SelectList(db.Environnements, "EnvironnementID", "Libelle");
            ViewBag.PrioriteID = new SelectList(db.Priorites, "PrioriteID", "Libelle");
            ViewBag.ResolutionID = new SelectList(db.Resolutions, "ResolutionID", "Libelle");
            ViewBag.StatutID = new SelectList(db.Statuts, "StatutID", "Libelle");
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Libelle");
            ViewBag.UtilisateurID = new SelectList(db.Personnes, "ID", "Nom");
            return View();
        }

        // POST: Tickets/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TicketID,TypeID,Resume,DateEcheance,DateCreation,DateResolution,Description,UtilisateurID,ApplicationID,AssistantID,PieceJointeID,HistoriqueID,CategorieID,PrioriteID,ResolutionID,StatutID,EnvironnementID,CriticiteID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationID = new SelectList(db.Applications, "ApplicationID", "Libelle", ticket.ApplicationID);
            ViewBag.AssistantID = new SelectList(db.Personnes, "ID", "Nom", ticket.AssistantID);
            ViewBag.CategorieID = new SelectList(db.Categories, "CategorieID", "Libelle", ticket.CategorieID);
            ViewBag.CriticiteID = new SelectList(db.Criticites, "CriticiteID", "Libelle", ticket.CriticiteID);
            ViewBag.EnvironnementID = new SelectList(db.Environnements, "EnvironnementID", "Libelle", ticket.EnvironnementID);
            ViewBag.PrioriteID = new SelectList(db.Priorites, "PrioriteID", "Libelle", ticket.PrioriteID);
            ViewBag.ResolutionID = new SelectList(db.Resolutions, "ResolutionID", "Libelle", ticket.ResolutionID);
            ViewBag.StatutID = new SelectList(db.Statuts, "StatutID", "Libelle", ticket.StatutID);
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Libelle", ticket.TypeID);
            ViewBag.UtilisateurID = new SelectList(db.Personnes, "ID", "Nom", ticket.UtilisateurID);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = await db.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationID = new SelectList(db.Applications, "ApplicationID", "Libelle", ticket.ApplicationID);
            ViewBag.AssistantID = new SelectList(db.Personnes, "ID", "Nom", ticket.AssistantID);
            ViewBag.CategorieID = new SelectList(db.Categories, "CategorieID", "Libelle", ticket.CategorieID);
            ViewBag.CriticiteID = new SelectList(db.Criticites, "CriticiteID", "Libelle", ticket.CriticiteID);
            ViewBag.EnvironnementID = new SelectList(db.Environnements, "EnvironnementID", "Libelle", ticket.EnvironnementID);
            ViewBag.PrioriteID = new SelectList(db.Priorites, "PrioriteID", "Libelle", ticket.PrioriteID);
            ViewBag.ResolutionID = new SelectList(db.Resolutions, "ResolutionID", "Libelle", ticket.ResolutionID);
            ViewBag.StatutID = new SelectList(db.Statuts, "StatutID", "Libelle", ticket.StatutID);
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Libelle", ticket.TypeID);
            ViewBag.UtilisateurID = new SelectList(db.Personnes, "ID", "Nom", ticket.UtilisateurID);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TicketID,TypeID,Resume,DateEcheance,DateCreation,DateResolution,Description,UtilisateurID,ApplicationID,AssistantID,PieceJointeID,HistoriqueID,CategorieID,PrioriteID,ResolutionID,StatutID,EnvironnementID,CriticiteID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationID = new SelectList(db.Applications, "ApplicationID", "Libelle", ticket.ApplicationID);
            ViewBag.AssistantID = new SelectList(db.Personnes, "ID", "Nom", ticket.AssistantID);
            ViewBag.CategorieID = new SelectList(db.Categories, "CategorieID", "Libelle", ticket.CategorieID);
            ViewBag.CriticiteID = new SelectList(db.Criticites, "CriticiteID", "Libelle", ticket.CriticiteID);
            ViewBag.EnvironnementID = new SelectList(db.Environnements, "EnvironnementID", "Libelle", ticket.EnvironnementID);
            ViewBag.PrioriteID = new SelectList(db.Priorites, "PrioriteID", "Libelle", ticket.PrioriteID);
            ViewBag.ResolutionID = new SelectList(db.Resolutions, "ResolutionID", "Libelle", ticket.ResolutionID);
            ViewBag.StatutID = new SelectList(db.Statuts, "StatutID", "Libelle", ticket.StatutID);
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Libelle", ticket.TypeID);
            ViewBag.UtilisateurID = new SelectList(db.Personnes, "ID", "Nom", ticket.UtilisateurID);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = await db.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ticket ticket = await db.Tickets.FindAsync(id);
            db.Tickets.Remove(ticket);
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
