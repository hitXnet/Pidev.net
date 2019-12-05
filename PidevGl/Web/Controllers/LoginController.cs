using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
           

            return View();
        }



        public ActionResult IndexE()
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
        [HttpPost]
        public void login(employe e)
        { RedirectToAction("login1", new { e = e }); }

        [HttpGet]
        public ActionResult login1(employe e ) {
            HttpClient Client = new HttpClient();
            //Client.BaseAddress = new Uri("http://localhost:9080/Pi_dev-web/rest");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:9080/Pi_dev-web/rest/login/" + e.login + "/" + e.password).Result;
            if (response.IsSuccessStatusCode)
            {  ViewBag.result = response.Content.ReadAsAsync<employe>().Result;
                return View();
                if (ViewBag.result == null) { ViewBag.resut = "utilisateur non existant"; RedirectToAction("Index2"); }
               else
                {
                    return RedirectToAction("Index2");
                }
            }
            else { ViewBag.result = "error"; return View(); }

            }
    }
}