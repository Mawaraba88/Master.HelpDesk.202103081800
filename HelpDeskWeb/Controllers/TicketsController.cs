﻿using System;
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
            var tickets = db.Tickets.Include(t => t.Applications).Include(t => t.PieceJointe);
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
            ViewBag.PieceJointeID = new SelectList(db.PieceJointes, "PieceJointeID", "Libelle");
            return View();
        }

        // POST: Tickets/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TicketID,Type,Resume,DateEcheance,DateCreation,Description,ApplicationID,Priorite,Resolution,Statut,Environnement,Criticite,PieceJointeID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationID = new SelectList(db.Applications, "ApplicationID", "Libelle", ticket.ApplicationID);
            ViewBag.PieceJointeID = new SelectList(db.PieceJointes, "PieceJointeID", "Libelle", ticket.PieceJointeID);
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
            ViewBag.PieceJointeID = new SelectList(db.PieceJointes, "PieceJointeID", "Libelle", ticket.PieceJointeID);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TicketID,Type,Resume,DateEcheance,DateCreation,Description,ApplicationID,Priorite,Resolution,Statut,Environnement,Criticite,PieceJointeID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationID = new SelectList(db.Applications, "ApplicationID", "Libelle", ticket.ApplicationID);
            ViewBag.PieceJointeID = new SelectList(db.PieceJointes, "PieceJointeID", "Libelle", ticket.PieceJointeID);
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
