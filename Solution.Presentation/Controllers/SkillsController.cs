using Solution.Data;
using Solution.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:9080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://127.0.0.1:9080/Pidev4GL-web/rest/Skill/skills").Result;
            if (response.IsSuccessStatusCode)
            {   
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Skills>>().Result;
            }
            else
            {
                ViewBag.Result = "error";
            }


            return View();
        }

        // GET: Skills/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Skills/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Skills/Create
        [HttpPost]
        public ActionResult Create(skill skills)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:9080");
            client.PostAsJsonAsync<skill>("Pidev4GL-web/rest/Skill/ajout", skills).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");

        }

        // GET: Skills/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Skills/Edit/5
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

        // GET: Skills/Delete/5
        //[HttpPost]
        public ActionResult Delete(string Nom)
        {
           try
            {
                HttpClient Client = new HttpClient();
                HttpResponseMessage response = Client.DeleteAsync("http://127.0.0.1:9080/Pidev4GL-web/rest/Skill/" + Nom).Result;


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Skills/Delete/5
       /* [HttpPost]
        public ActionResult Delete(string Nom)
        {

            try
            {
                HttpClient Client = new HttpClient();
                HttpResponseMessage response = Client.DeleteAsync("http://localhost:9080/pidev4gl-web/rest/Skill/" + Nom).Result;


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }*/

        }
    }

