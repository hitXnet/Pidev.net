using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class EmployeController : Controller
    {
        // GET: Employe
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            // Client.BaseAddress = new Uri("http://localhost:9080/Pi_dev-web/rest");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:9080/Pi_dev-web/rest/Employe/get").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<employe>>().Result;

            }
            else { ViewBag.result = "error"; }
            return View();
        }
        public ActionResult remove(int id)
        {
            HttpClient Client = new HttpClient();
            HttpResponseMessage response = Client.DeleteAsync("http://localhost:9080/Pi_dev-web/rest/Employe/delete/" + id).Result;
            return RedirectToAction("Index");
        }
         [HttpPost]
         public ActionResult Create(employe note)
         {
            
                 HttpClient client = new HttpClient();
                 client.BaseAddress = new Uri("http://localhost:9080/");
                 HttpResponseMessage response = client.PostAsJsonAsync("Pi_dev-web/rest/Employe/ajout", note).Result;
                 return View(note);
           
          
         }


        public ActionResult Create()
        {
            
                return View();
            
        }

    }
}