
using Data;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class CongeController : Controller
    {
        ICongeService congeservice;
        //private Context db = new Context();
        // GET: Conge
        public CongeController()
        {
            congeservice = new CongeService();
        }
        public ActionResult Index()
        {
            var getall = congeservice.GetMany();
            return View(getall);
        }

     

        // GET: Conge/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Conge/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conge/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "CongeId , DateDebut,DateFin,Type,employeId")]Conge conge)
        {
            try
            {

                congeservice.Add(conge);
                congeservice.Commit();
                return View(conge);
            }
            catch { return RedirectToAction("Index"); }
        }

        // GET: Conge/Edit/5
        public ActionResult Edit(int id)
        {
            Conge conge = congeservice.GetById(id);

            return View(conge);
        }

        // POST: Conge/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DateTime DateDebut, DateTime DateFin, String Type, int employeId, [Bind(Include = "CongeId , DateDebut,DateFin,Type,employeId")]Conge conge)
        {
            try
            {
                Conge cong = congeservice.GetById(id);
            cong.DateDebut = DateDebut;
            cong.DateFin = DateFin;
            cong.employeId = employeId;
            cong.Type = Type;

            congeservice.Update(cong);
            congeservice.Commit();

            return RedirectToAction("Index");
        }
            catch
            {

            return View(conge); }

        }

        // GET: Conge/Delete/5
        public ActionResult Delete(int id)
        {
            Conge con = congeservice.GetById(id);
            return View(con);
        }

        // POST: Conge/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Conge cong = congeservice.GetById(id);
                congeservice.Delete(cong);
                congeservice.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
