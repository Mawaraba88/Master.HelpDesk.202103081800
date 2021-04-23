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
    public class UtilisateursController : Controller
    {
        private ModeleHelpDesk db = new ModeleHelpDesk();

        // GET: Utilisateurs
        public async Task<ActionResult> Index()
        {
            var utilisateurs = db.Utilisateurs.Include(u => u.Profil);
            return View(await utilisateurs.ToListAsync());
        }

        // GET: Utilisateurs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = await db.Utilisateurs.FindAsync(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // GET: Utilisateurs/Create
        public ActionResult Create()
        {
            ViewBag.ProfilID = new SelectList(db.Profils, "ProfilID", "Libelle");
            return View();
        }

        // POST: Utilisateurs/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,ProfilID,Nom,Prenom,Email,MotDePasse")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                db.Utilisateurs.Add(utilisateur);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProfilID = new SelectList(db.Profils, "ProfilID", "Libelle", utilisateur.ProfilID);
            return View(utilisateur);
        }

        // GET: Utilisateurs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = await db.Utilisateurs.FindAsync(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfilID = new SelectList(db.Profils, "ProfilID", "Libelle", utilisateur.ProfilID);
            return View(utilisateur);
        }

        // POST: Utilisateurs/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,ProfilID,Nom,Prenom,Email,MotDePasse")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilisateur).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProfilID = new SelectList(db.Profils, "ProfilID", "Libelle", utilisateur.ProfilID);
            return View(utilisateur);
        }

        // GET: Utilisateurs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = await db.Utilisateurs.FindAsync(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Utilisateur utilisateur = await db.Utilisateurs.FindAsync(id);
            db.Utilisateurs.Remove(utilisateur);
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
