using PatientDocumenation.Data;
using PatientDocumentation.Models.ProviderModels;
using PatientDocumentation.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientDocumentation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProviderController : Controller
    {
        // GET: Provider
        [AllowAnonymous]
        public ActionResult Index()
        {
            var service = new ProviderService();
            var model = service.GetProviders();
            return View(model);
        }

        //GET: Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProviderCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            //HttpPostedFileBase file = Request.Files["ImageData"]; //Do I need this line?
            var service = new ProviderService();
            if (service.CreateProvider(model))
            {
                TempData["SaveResult"] = "Provider successfully created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Provider could not be created.");
            return View(model);
        }

        //GET: Details
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var service = new ProviderService();
            var model = service.GetProviderById(id);
            return View(model);
        }

        //GET: Edit
        public ActionResult Edit(int id)
        {
            var service = new ProviderService();
            var detail = service.GetProviderById(id);
            var model = new ProviderEdit
            {
                ProviderId = detail.ProviderId,
                FirstName = detail.FirstName,
                LastName = detail.LastName,
                Title = detail.Title,
                ImageAsBytes = detail.ImageAsBytes,
                ImageFile = detail.ImageFile,
                License = detail.License,
                Specialization = detail.Specialization,
                ClinicId = detail.ClinicId,
                UserId = detail.UserId
            };
            return View(model);
        }

        //POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProviderEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);
            //HttpPostedFileBase file = Request.Files["ImageData"]; //Do I need this line?
            if (model.ProviderId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = new ProviderService();
            if (service.UpdateProvider(model))
            {
                TempData["SaveResult"] = "Provider updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Provider could not be updated.");
            return View(model);
        }

        //GET: Delete
        public ActionResult Delete(int id)
        {
            var service = new ProviderService();
            var model = service.GetProviderById(id);
            return View(model);
        }

        //POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProvider(int id)
        {
            var service = new ProviderService();
            service.DeleteProvider(id);
            TempData["SaveResult"] = "Provider deleted.";
            return RedirectToAction("Index");
        }
    }
}