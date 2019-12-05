using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Service;
using Web.Models;

namespace Web.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        public ActionResult Index()
        {
            return View();
        }


        // GET: Emp/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Emp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emp/Create
        [HttpPost]
        public ActionResult Create(notefraisemploye note)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9080/");
                HttpResponseMessage response = client.PostAsJsonAsync("PiMission-web/rest/consulter/addfrais",note).Result;
                return RedirectToAction("Accueil");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emp/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        public ActionResult Stat()
        {
            NoteFraisEmployeService nts = new NoteFraisEmployeService();
            var extras = (from one in nts.GetAll() where one.naturefraisem == "3" select one.montantfraisem).Sum();
            var heberg = (from one in nts.GetAll() where one.naturefraisem == "2" select one.montantfraisem).Sum();

            var rest = (from one in nts.GetAll() where one.naturefraisem == "1" select one.montantfraisem).Sum();
            var trans = (from one in nts.GetAll() where one.naturefraisem == "0" select one.montantfraisem).Sum();



            return View(new statViewModel()
            {
                extra = extras,
                heberg = heberg,
                rest = rest,
                trans = trans

            });
            return View();
        }
        public ActionResult ImportExcel()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Excel excel = new Excel();
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("PiMission-web/rest/consulter/frais").Result;

            if (response.IsSuccessStatusCode)
            {

                excel.export(response.Content.ReadAsAsync<IEnumerable<notefraisemploye>>().Result);

                excel.saveAs(path + "/Liste des frais");
                excel.close();
                return RedirectToAction("Accueil");
            }
            else
            {
                return ViewBag.result = "error";



            }
          return  RedirectToAction("Accueil");
        }
        public ActionResult Sommefrais()
        {
            NoteFraisEmployeService nts = new NoteFraisEmployeService();
            var extras = (from one in nts.GetAll() where one.naturefraisem == "3" select one.montantfraisem).Sum();
            var heberg =(from one in nts.GetAll() where one.naturefraisem == "2" select one.montantfraisem).Sum();

            var rest = (from one in nts.GetAll() where one.naturefraisem == "1" select one.montantfraisem).Sum();
            var trans =(from one in nts.GetAll() where one.naturefraisem == "0" select one.montantfraisem).Sum();



            return View(new statViewModel() {
                extra = extras,
                heberg = heberg,
                rest = rest ,
                trans= trans

            });
        }
        // POST: Emp/Edit/5
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

        // GET: Emp/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Emp/Delete/5
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




        public ActionResult Accueil(notefraisemploye e)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("PiMission-web/rest/consulter/frais").Result;

            if (response.IsSuccessStatusCode)
            {
                
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<notefraisemploye>>().Result;
                return View();
            }
            else
            {
                return ViewBag.result = "error";
            }
        }
        public ActionResult remove(int id)
        {
            HttpClient client = new HttpClient();
            
            client.BaseAddress = new Uri("http://localhost:9080/");
            HttpResponseMessage response = client.DeleteAsync("PiMission-web/rest/consulter/deleteFrais/" + id).Result;
           return  RedirectToAction("Accueil");
        }
     
    }
}
