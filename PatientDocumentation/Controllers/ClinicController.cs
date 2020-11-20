using PatientDocumentation.Models.ClinicModels;
using PatientDocumentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientDocumentation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ClinicController : Controller
    {
        // GET: Clinic
        [AllowAnonymous]
        public ActionResult Index()
        {
            var service = new ClinicService();
            var model = service.GetClinics();
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
        public ActionResult Create(ClinicCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var service = new ClinicService();
            if (service.CreateClinic(model))
            {
                TempData["SaveResult"] = "Clinic added to directory.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Failed to create Clinic.");
            return View(model);
        }

        //GET: Details
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var service = new ClinicService();
            var model = service.GetClinicById(id);
            return View(model);
        }

        //GET: Edit
        public ActionResult Edit(int id)
        {
            var service = new ClinicService();
            var detail = service.GetClinicById(id);
            var model = new ClinicEdit
            {
                ClinicId = detail.ClinicId,
                Name = detail.Name,
                Address = detail.Address,
                City = detail.City,
                State = detail.State,
                Zip = detail.Zip,
                Phone = detail.Phone
            };
            return View(model);
        }

        //POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClinicEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (model.ClinicId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = new ClinicService();
            if (service.UpdateClinic(model))
            {
                TempData["SaveResult"] = "Clinic information successfully updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Clinic could not be updated.");
            return View(model);
        }

        //GET: Delete
        public ActionResult Delete(int id)
        {
            var service = new ClinicService();
            var model = service.GetClinicById(id);
            return View(model);
        }

        //POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteClinic(int id)
        {
            var service = new ClinicService();
            service.DeleteClinic(id);
            TempData["SaveResult"] = "Clinic successfully deleted.";
            return RedirectToAction("Index");
        }
    }
}