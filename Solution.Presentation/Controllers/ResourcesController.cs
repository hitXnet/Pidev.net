using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class ResourcesController : Controller
    {
        IResourcesService ResourcesService;
        public ResourcesController()
        {
            ResourcesService = new ResourcesService();
        }
        // GET: Resources
        public ActionResult Index()
        {
            var ListResources = new List<ResourcesVM>();
            var listResourcesDomain = ResourcesService.GetMany();

            foreach (Resources r in listResourcesDomain)
               


                ListResources.Add(new ResourcesVM()
                {
                    ResourceId = r.ResourceId,
                    TypeResource = r.TypeResource,
                    Date_Location = r.Date_Location,
                    Latitude =  r.Latitude.ToString().Replace(",", "."),
                    Longitude = r.Longitude.ToString().Replace(",", "."),
                    Description = r.Description
                    
                });
            return View(ListResources);
        }

        //// GET: Resource/Create
        public ActionResult Create()
        {

            var resources = ResourcesService.GetMany();
            ViewBag.Resources =
                new SelectList(resources, "ResourceId", "TypeResource");
            return View();
        }

        // POST: Resources/Create
        [HttpPost]
        public ActionResult Create(ResourcesVM resourcevm)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("Create");
            }

            Resources res = new Resources
            {

                TypeResource = resourcevm.TypeResource,
                Date_Location = resourcevm.Date_Location,
                Longitude = double.Parse(resourcevm.Longitude, System.Globalization.CultureInfo.InvariantCulture),
                Latitude = double.Parse(resourcevm.Latitude, System.Globalization.CultureInfo.InvariantCulture),
                Description = resourcevm.Description
            };
             ResourcesService.Add(res);
            ResourcesService.Commit();
       

               return RedirectToAction("Index");
            }

        // GET: Resource/Edit/5
        public ActionResult Edit(int id)
        {
            Resources r = ResourcesService.GetById(id);
            var res = new ResourcesVM
            {
                Date_Location = r.Date_Location,
                Description = r.Description,
                Latitude = r.Latitude.ToString().Replace(",", "."),
                Longitude = r.Longitude.ToString().Replace(",", "."),
                TypeResource = r.TypeResource,
            };
            return View(res);
        }

        // POST: Resource/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Models.ResourcesVM rv)
        {
            
                Domain.Entities.Resources r1 = ResourcesService.GetById(id);
              

                r1.TypeResource = rv.TypeResource;
            r1.Longitude = double.Parse(rv.Longitude, System.Globalization.CultureInfo.InvariantCulture);
            r1.Latitude = double.Parse(rv.Latitude, System.Globalization.CultureInfo.InvariantCulture);
                //r1.Latitude = double.Parse(rv.Latitude.ToString().Replace(",", "."));
                //r1.Longitude = double.Parse(rv.Longitude.ToString().Replace(",", "."));
                r1.Description = rv.Description;
                r1.Date_Location = rv.Date_Location;
               ResourcesService.Update(r1);
                ResourcesService.Commit();
                return RedirectToAction("Index");
           

        }


        // GET: Diplome/Delete/5
        public ActionResult Delete(int id)
        {
            var c = ResourcesService.GetById(id);
            ResourcesService.Delete(c);
            ResourcesService.Commit();
            return RedirectToAction("Index");
        }

        // POST: Diplome/Delete/5
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



    }
}