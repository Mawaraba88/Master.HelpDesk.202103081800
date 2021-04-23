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
using HelpDeskWeb.Service;
using Metier.Interfaces;
using Kendo.Mvc.UI;
using AutoMapper.QueryableExtensions;
using Kendo.Mvc.Extensions;
using HelpDeskWeb.ViewModels;
using AutoMapper;
using System.IO;
using HelpDeskWeb.ViewModels.Ticket;
using HelpDeskWeb.Filters;

namespace HelpDeskWeb.Controllers
{

    /*using System;
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
    using HelpDeskWeb.Service;
    using Metier.Interfaces;
    using Kendo.Mvc.UI;
    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.Extensions;
    using HelpDeskWeb.ViewModels;
    using AutoMapper;
    using System.IO;
    using HelpDeskWeb.ViewModels.Ticket;
    using HelpDeskWeb.ViewModels.Commentaires;*/

    public class TicketsController : Controller
    {
        private ModeleHelpDesk db = new ModeleHelpDesk();

        // GET: Tickets
        /*public async Task<ActionResult> Index()
        {
            var tickets = db.Tickets.Include(t => t.Applications).Include(t => t.Assistant).Include(t => t.PieceJointe);
            return View(await tickets.ToListAsync());
        }*/

        public async Task<ActionResult> Index(String sortOrder, int? SelectedApplication, int? SelectedPriorite)
        {

            ViewBag.CurrentSort = sortOrder;

            ViewBag.CurrentFilter = SelectedApplication;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var ticketsData = (from t in db.Tickets
                               select t).ToList();
            var ticket = from t in ticketsData
                         select t;

            if (SelectedApplication != 0)
            {
                ticket = ticket.Where(t => t.Applications.Equals(SelectedApplication));

            }

            if (SelectedPriorite != 0)
            {
                ticket = ticket.Where(t => t.Priorite.Equals(SelectedPriorite));

            }
            var applications = db.Applications.OrderBy(q => q.Libelle).ToList();
            ViewBag.SelectedApplication = new SelectList(applications, "ApplicationID", "Libelle", SelectedApplication);
            int applicationID = SelectedApplication.GetValueOrDefault();

            IQueryable<Ticket> tickets = db.Tickets
                .Where(c => !SelectedApplication.HasValue || c.ApplicationID == applicationID)
                .OrderBy(d => d.TicketID)
                .Include(d => d.Applications);
            var sql = tickets.ToString();

            /*var UniqueApplication = from t in tickets
                                    group t by t.Applications into newGroup
                                    where newGroup.Key != null
                                    orderby newGroup.Key
                                    select new { Applications = newGroup.Key };

            ViewBag.UniqueApplication = UniqueApplication.Select(m => new SelectList{ Value = m.Applications,
                Text = m.Applications }).ToList();*/





            /*var applications = db.Applications.OrderBy(q => q.Libelle).ToList();
            ViewBag.SelectedApplication = new SelectList(applications, "ApplicationID", "Libelle", SelectedApplication);
            int applicationID = SelectedApplication.GetValueOrDefault();


            IQueryable<Ticket> tickets = db.Tickets
                .Where(c => !SelectedApplication.HasValue || c.ApplicationID == applicationID)
                .OrderBy(d => d.TicketID)
                .Include(d => d.Applications);
            var sql = tickets.ToString();*/


            switch (sortOrder)
            {
                case "Date":
                    tickets = tickets.OrderBy(t => t.DateCreation);
                    tickets = tickets.OrderBy(t => t.DateEcheance);
                    break;
                case "Date_desc":
                    tickets = tickets.OrderByDescending(t => t.DateCreation);
                    tickets = tickets.OrderByDescending(t => t.DateEcheance);
                    break;
                default:
                    tickets = tickets.OrderBy(t => t.DateCreation);
                    break;
            }

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
        [CustomerAuthorisation]
        public ActionResult Create()
        {
            ViewBag.ApplicationID = new SelectList(db.Applications, "ApplicationID", "Libelle");
            ViewBag.AssistantID = new SelectList(db.Personnes, "ID", "Nom");
            ViewBag.PieceJointeID = new SelectList(db.PieceJointes, "PieceJointeID", "Libelle");
            return View();
        }

        // POST: Tickets/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomerAuthorisation]
        /* public async Task<ActionResult> Create([Bind(Include = "TicketID,Type,Resume,DateEcheance,DateCreation,Description,ApplicationID,AssistantID,Priorite,Resolution,Statut,Environnement,Criticite,PieceJointeID")] Ticket ticket)
         {
             if (ModelState.IsValid)
             {
                 db.Tickets.Add(ticket);
                 await db.SaveChangesAsync();
                 return RedirectToAction("Index");
             }

             ViewBag.ApplicationID = new SelectList(db.Applications, "ApplicationID", "Libelle", ticket.ApplicationID);
             ViewBag.AssistantID = new SelectList(db.Personnes, "ID", "Nom", ticket.AssistantID);
             ViewBag.PieceJointeID = new SelectList(db.PieceJointes, "PieceJointeID", "Libelle", ticket.PieceJointeID);
             return View(ticket);
         }
        */

        public async Task<ActionResult> Create([Bind(Include = "Type,Resume,DateEcheance,DateCreation,Description,ApplicationID,AssistantID,Priorite,Resolution,Statut,Environnement,Criticite,PieceJointeID")] Ticket ticket)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Tickets.Add(ticket);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }


            ViewBag.ApplicationID = new SelectList(db.Applications, "ApplicationID", "Libelle", ticket.ApplicationID);
            ViewBag.AssistantID = new SelectList(db.Personnes, "ID", "Nom", ticket.AssistantID);
            ViewBag.PieceJointeID = new SelectList(db.PieceJointes, "PieceJointeID", "Libelle", ticket.PieceJointeID);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        [CustomerAuthorisation]
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
            ViewBag.PieceJointeID = new SelectList(db.PieceJointes, "PieceJointeID", "Libelle", ticket.PieceJointeID);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomerAuthorisation]
        /*public async Task<ActionResult> Edit([Bind(Include = "TicketID,Type,Resume,DateEcheance,DateCreation,Description,ApplicationID,AssistantID,Priorite,Resolution,Statut,Environnement,Criticite,PieceJointeID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationID = new SelectList(db.Applications, "ApplicationID", "Libelle", ticket.ApplicationID);
            ViewBag.AssistantID = new SelectList(db.Personnes, "ID", "Nom", ticket.AssistantID);
            ViewBag.PieceJointeID = new SelectList(db.PieceJointes, "PieceJointeID", "Libelle", ticket.PieceJointeID);
            return View(ticket);
        }
        */

        public async Task<ActionResult> Edit([Bind(Include = "TicketID,Type,Resume,DateEcheance,DateCreation,Description,ApplicationID,AssistantID,Priorite,Resolution,Statut,Environnement,Criticite,PieceJointeID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
               
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                
            }
            ViewBag.ApplicationID = new SelectList(db.Applications, "ApplicationID", "Libelle", ticket.ApplicationID);
            ViewBag.AssistantID = new SelectList(db.Personnes, "ID", "Nom", ticket.AssistantID);
            ViewBag.PieceJointeID = new SelectList(db.PieceJointes, "PieceJointeID", "Libelle", ticket.PieceJointeID);
            return View(ticket);
        }
        // GET: Tickets/Delete/5
        [CustomerAuthorisation]
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
        [CustomerAuthorisation]
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

        /*
            public class TicketsController : BaseController
            {
                private IDropDownListPopulator populator;
                public TicketsController()
                {

                }
                public TicketsController(IHelpDeskData data, IDropDownListPopulator populator)
                    : base(data)
                {
                    this.populator = populator;
                }

                [Authorize]
                public ActionResult All(int? category)
                {
                    return View(category);
                }

                [Authorize]
                [HttpPost]
                public ActionResult ReadTickets([DataSourceRequest] DataSourceRequest request, int? application)
                {
                    var ticketsQuery = this.Data.Tickets.All();

                    if ( application != null)
                    {
                        ticketsQuery = ticketsQuery.Where(t => t.ApplicationID == application.Value);
                    }

                    var tickets = ticketsQuery
                        .Project()
                        .To<ListTicketViewModel>();

                    return Json(tickets.ToDataSourceResult(request));
                }

                [Authorize]
                public ActionResult Add()
                {
                    var addTicketViewModel = new AddTicketViewModel
                    {
                        Applications = this.populator.GetApplication()
                    };

                    return View(addTicketViewModel);
                }

                [Authorize]
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Add(AddTicketViewModel ticket)
                {
                    if (ticket != null && ModelState.IsValid)
                    {
                        var dbTicket = Mapper.Map<Ticket>(ticket);
                        dbTicket.Assistant = this.AssistantProfil;
                        if (ticket.UploadesPieceJointe != null)
                        {
                            using (var memory = new MemoryStream())
                            {
                                ticket.UploadesPieceJointe.InputStream.CopyTo(memory);
                                var content = memory.GetBuffer();

                                dbTicket.PieceJointe= new PieceJointe
                                {
                                    Content = content,
                                    Libelle = ticket.UploadesPieceJointe.FileName.Split(new[] { '.' }).Last()
                                };
                            }
                        }

                        this.Data.Tickets.Add(dbTicket);
                        this.Data.SaveChanges();

                        return RedirectToAction("All", "Tickets");
                    }

                    ticket.Applications = this.populator.GetApplication();

                    return View(ticket);
                }

                public ActionResult Details(int id)
                {
                    var ticket = this.Data
                        .Tickets
                        .All()
                        .Where(t => t.TicketID == id)
                        .Project()
                        .To<TicketDetailsViewModel>()
                        .FirstOrDefault();

                    if (ticket == null)
                    {
                        throw new HttpException(404, "Ticket not found");
                    }

                    ticket.Commentaires = (ICollection<ViewModels.Commentaires.CommentViewModel>)this.Data
                        .Commentaires
                        .All()
                        .Where(c => c.TicketId == ticket.TicketID)
                        .OrderByDescending(c => c.CommentaireID)
                        .Project()
                        .To<CommentViewModel>()
                        .ToList();

                    return View(ticket);
                }

                public ActionResult Image(int id)
                {
                    var image = this.Data.PieceJointes.GetById(id);
                    if (image == null)
                    {
                        throw new HttpException(404, "Image not found");
                    }

                    return File(image.Content, "image/" + image.Libelle);
                }

                public ActionResult GetApplication()
                {
                    return Json(this.populator.GetApplication(), JsonRequestBehavior.AllowGet);
                }
            }
        */
    }
}
