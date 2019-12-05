using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;

namespace Solution.Presentation.Controllers
{
    public class TacheController : Controller
    {
        // GET: Tache
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetTaches()
        {
            TacheService dc = new TacheService();
            List<Tache> events = new List<Tache>();
            events = dc.GetMany().ToList();
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        [HttpPost]
        public JsonResult SaveEvent(Tache e)
        {
            Console.WriteLine("teessssssst" + e.TacheId);
            var status = false;
            TacheService dc = new TacheService();
            if (e.TacheId > 0)
            {
                //Update the event
                var v = dc.GetById(e.TacheId);
                if (v != null)
                {
                    v.TacheId = e.TacheId;
                    v.Subject = e.Subject;
                    v.Start = e.Start;
                    v.End = e.End;
                    v.Description = e.Description;
                    v.IsFullDay = e.IsFullDay;
                    v.ThemeColor = e.ThemeColor;
                    dc.Update(v);

                }

            }
            else
            {
                Tache v = new Tache
                {
                    Subject = e.Subject,
                    Description = e.Description,
                    Start = e.Start,
                    End = e.End,
                    IsFullDay = e.IsFullDay,
                    ThemeColor = e.ThemeColor
                };

                dc.Add(v);

            }
            dc.Commit();
            status = true;
            return new JsonResult { Data = new { status = status } };
        }
        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            TacheService dc = new TacheService();
            Console.WriteLine(eventID);
            Tache v = new Tache();
            v = dc.GetById(eventID);
            
            dc.Delete(v);                
            dc.Commit();
            status = true;

            return new JsonResult { Data = new { status = status } };
        }
    }

    
}