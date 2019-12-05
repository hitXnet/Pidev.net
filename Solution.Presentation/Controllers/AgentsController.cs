using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;

namespace Solution.Presentation.Controllers
{
    public class AgentsController : Controller
    {
        AgentService es = new AgentService();
        // GET: Agents
        public ActionResult Index()
        {
            var agents = es.GetMany();
            return View(agents);
        }

        // GET: Agents/Details/5
        public ActionResult Details(int id)
        {
            Agent a = es.GetById(id);
            var agent = new AgentModel
            {
                AgentId = a.AgentId,
                FirstName = a.FirstName,
                LastName = a.LastName,
                PhoneNumber = a.PhoneNumber,
                Type = a.Type,
                Heure_travail = a.Heure_travail
            };
            return View(agent);
        }

        // GET: Agents/Create
        public ActionResult Create()
        {
            AgentModel a = new AgentModel();
            return View(a);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgentModel am)
        {
            if (ModelState.IsValid)
            {
                Agent a = new Agent
                {
                    FirstName = am.FirstName,
                    LastName = am.LastName,
                    PhoneNumber = am.PhoneNumber,
                    Type = am.Type,
                    Heure_travail = am.Heure_travail
                };
                es.Add(a);
                es.Commit();
                return RedirectToAction("Index");
            }
            return View(am);
        }

        // GET: Agents/Edit/5
        public ActionResult Edit(int id)
        {
            Agent a = es.GetById(id);
            var am = new AgentModel
            {
                FirstName = a.FirstName,
                LastName = a.LastName,
                PhoneNumber = a.PhoneNumber,
                Type = a.Type,
                Heure_travail = a.Heure_travail
            };
            return View(am);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AgentModel am)
        {
            if (ModelState.IsValid)
            {
                Agent a = es.GetById(id);
                a.FirstName = am.FirstName;
                a.LastName = am.LastName;
                a.PhoneNumber = am.PhoneNumber;
                a.Type = am.Type;
                a.Heure_travail = am.Heure_travail;

                es.Update(a);
                es.Commit();
                return RedirectToAction("Index");
            }
            else
                return View(am);
        }

        // GET: Agents/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var a = es.GetById(id);
            AgentModel am = new AgentModel()
            {
                FirstName = a.FirstName,
                LastName = a.LastName,
                PhoneNumber = a.PhoneNumber,
                Type = a.Type,
                Heure_travail = a.Heure_travail

            };
            if (a == null)
                return HttpNotFound();
            return View(am);

            //var a = es.GetById(id);

            //es.Delete(a);
            //es.Commit();

            //return RedirectToAction("Index");
        }

        // POST: Agents/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AgentModel amm)
        {
            //try
            //{
            //    Agent a = es.GetById(id);

            //    es.Delete(a);
            //    es.Commit();

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}

                    var a = es.GetById(id);
                    AgentModel am = new AgentModel()
                    {
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        PhoneNumber = a.PhoneNumber,
                        Type = a.Type,
                        Heure_travail = a.Heure_travail

                    };

                    es.Delete(a);
                    es.Commit();

                    return RedirectToAction("Index");
                
           
        }

        // GET: Home
        public ActionResult IndexStat()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            dataPoints.Add(new DataPoint("Passable", es.GetNbAgentsByType(AgentType.Passable)));
            dataPoints.Add(new DataPoint("refuse", es.GetNbAgentsByType(AgentType.Refuse)));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }

    }
}
