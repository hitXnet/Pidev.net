using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult remove(int id)
        {
            HttpClient Client = new HttpClient();
            HttpResponseMessage response = Client.DeleteAsync("http://localhost:9080/Pi_dev-web/rest/Post/delete/" + id).Result;
            return RedirectToAction("Index");
        }
    }
}