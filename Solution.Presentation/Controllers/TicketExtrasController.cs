using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Solution.Presentation.Models;

namespace Solution.Presentation.Controllers
{
    public class TicketExtrasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TicketExtras
        public ActionResult Index()
        {
            return View(db.TicketExtras.ToList());
        }

        // GET: TicketExtras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketExtra ticketExtra = db.TicketExtras.Find(id);
            if (ticketExtra == null)
            {
                return HttpNotFound();
            }
            return View(ticketExtra);
        }

        // GET: TicketExtras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TicketExtras/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,etat,flextime,tache,price,id_emp")] TicketExtra ticketExtra)
        {
            if (ModelState.IsValid)
            {
                db.TicketExtras.Add(ticketExtra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticketExtra);
        }

        // GET: TicketExtras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketExtra ticketExtra = db.TicketExtras.Find(id);
            if (ticketExtra == null)
            {
                return HttpNotFound();
            }
            return View(ticketExtra);
        }

        // POST: TicketExtras/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,etat,flextime,tache,price,id_emp")] TicketExtra ticketExtra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketExtra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticketExtra);
        }

        // GET: TicketExtras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketExtra ticketExtra = db.TicketExtras.Find(id);
            if (ticketExtra == null)
            {
                return HttpNotFound();
            }
            return View(ticketExtra);
        }

        // POST: TicketExtras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketExtra ticketExtra = db.TicketExtras.Find(id);
            db.TicketExtras.Remove(ticketExtra);
            db.SaveChanges();
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
