using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Solution.Data;
using Solution.Presentation.Models;

namespace Solution.Presentation.Controllers
{
    public class timesheetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: timesheets
        public ActionResult Index()
        {
            return View(db.timesheets.ToList());
        }

        // GET: timesheets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            timesheet timesheet = db.timesheets.Find(id);
            if (timesheet == null)
            {
                return HttpNotFound();
            }
            return View(timesheet);
        }

        // GET: timesheets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: timesheets/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,NbrH,date")] timesheet timesheet)
        {
            if (ModelState.IsValid)
            {
                db.timesheets.Add(timesheet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timesheet);
        }

        // GET: timesheets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            timesheet timesheet = db.timesheets.Find(id);
            if (timesheet == null)
            {
                return HttpNotFound();
            }
            return View(timesheet);
        }

        // POST: timesheets/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,NbrH,date")] timesheet timesheet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timesheet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timesheet);
        }

        // GET: timesheets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            timesheet timesheet = db.timesheets.Find(id);
            if (timesheet == null)
            {
                return HttpNotFound();
            }
            return View(timesheet);
        }

        // POST: timesheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            timesheet timesheet = db.timesheets.Find(id);
            db.timesheets.Remove(timesheet);
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
