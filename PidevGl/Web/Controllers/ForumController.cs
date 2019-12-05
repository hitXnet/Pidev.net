using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ForumController : Controller
    {
        // GET: post
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
           // Client.BaseAddress = new Uri("http://localhost:9080/Pi_dev-web/rest");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:9080/Pi_dev-web/rest/Post").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync < IEnumerable<Web.Models.Forum>>().Result;

            }
            else { ViewBag.result = "error"; }
            return View();
        }
        public ActionResult remove(int id)
        {
            HttpClient Client = new HttpClient();
            HttpResponseMessage response = Client.DeleteAsync("http://localhost:9080/Pi_dev-web/rest/Post/delete/" + id).Result;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Create(post note)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9080/");
                HttpResponseMessage response = client.PostAsJsonAsync("Pi_dev-web/rest/Post/ajout", note).Result;
                return RedirectToAction("Accueil");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Create()
        {

            return View();

        }
    }
}