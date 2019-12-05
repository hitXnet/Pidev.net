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
    public class AbsenceController : Controller
    {
        IAbsenceService absenceservice;

       
     
        public AbsenceController()
        {
            absenceservice = new AbsenceService();
        }
        // GET: Absence

        public ActionResult Index()
        {
            var getall = absenceservice.GetMany();
            return View(getall);
        }

        // GET: Absence/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Absence/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Absence/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "AbsenceId , DateDebut,DateFin,employeId")]Absence abs ) 
        {
            CongeService congeservice = new CongeService();
            var getall = congeservice.GetMany();
            var c = getall.Where(y => y.employeId == abs.employeId).Where(w=> DateTime.Compare(abs.DateDebut, w.DateFin)>0).ToList();
            // DateTime a = c.First();
            var l = c.Count();
            if (l>0)
            {
                try
                {
                    if (0 >= DateTime.Compare(abs.DateDebut, abs.DateFin))
                    {
                        absenceservice.Add(abs);
                        absenceservice.Commit();
                        return View(abs);
                    }
                    return View();
                }
                catch { return RedirectToAction("Index"); }
            } return View();
        }

        // GET: Absence/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Absence/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DateTime DateDebut, DateTime DateFin,  int employeId, [Bind(Include = "AbsenceId , DateDebut,DateFin,employeId")]Absence abs)
        {
            try
            {
                Absence absence = absenceservice.GetById(id);
                absence.DateDebut = DateDebut;
                absence.DateFin = DateFin;
                absence.employeId = employeId;
               

                absenceservice.Update(absence);
               absenceservice.Commit();

                return RedirectToAction("Index");
            }
            catch
            {

                return View(abs);
            }

        }

        // GET: Absence/Delete/5
        public ActionResult Delete(int id)
        {
            Absence con = absenceservice.GetById(id);
            return View(con);
        }

        // POST: Absence/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Absence cong = absenceservice.GetById(id);
                absenceservice.Delete(cong);
                absenceservice.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult dashboard()
        {
            
            AbsenceService cs = new AbsenceService();
            var list = cs.GetMany();
            List<faza> l = new List<faza>();
            foreach(var aa in list)  
            
            { faza f = new faza();
                    f.id =(int) aa.employeId;
                    f.nb=(int) (aa.DateFin - aa.DateDebut).TotalDays+1;
                      l.Add(f);
                        }
            List<faza> l1 = new List<faza>();
            faza f1 = new faza();
            faza f2 = new faza();
            f1.id = 1;
            f2.id = 2;
            f1.nb = f2.nb = 0;
            l1.Add(f1); l1.Add(f2);
            foreach (var zz in l)
            { foreach(var az in l1)
                { if (az.id==zz.id) { az.nb = az.nb + zz.nb; } }
            }
            List <int> repartitions = new List<int>();
           
            var Vues = l1.Select(x => x.id).Distinct();
            
            foreach (var item in l1)
            { 
                repartitions.Add( item.nb );
            }
            var rep = repartitions;
            ViewBag.Vues = Vues;
            ViewBag.REP = repartitions.ToList();
            return View();
        }

    }
}





