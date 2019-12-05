using Data;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class FactureController : Controller
    {
        FactureService srf ;
        // GET: Facture
        public ActionResult Index()
        {
            srf = new FactureService();
          IEnumerable<Facture> facutres = srf.GetAll();
          return View(facutres);
        }

        // GET: Facture/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Facture/Create
        public ActionResult Create(Facture facture, HttpPostedFileBase fileBase)
        {
          
            return View();
        }

        // POST: Facture/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, HttpPostedFileBase ImageFacture)
        {
            try
            {
                Facture facture = new Facture();
                facture.imagefacture = ImageFacture.FileName;
                facture.descriptionfacture = collection["descriptionfacture"];
                srf = new FactureService();
                srf.Add(facture);
                srf.Commit();
                if (ImageFacture.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/uploads/"), ImageFacture.FileName);
                    ImageFacture.SaveAs(path);
                }
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
            return View();
        }

        // GET: Facture/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Facture/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Facture/Delete/5
        public ActionResult Delete(int id)
        {
            srf = new FactureService();
            Facture f = srf.GetById(id);
            srf.Delete(f);
            srf.Commit();
            return RedirectToAction("Index");
        }

        // POST: Facture/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
