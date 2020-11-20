using PatientDocumentation.Models.PatientModels;
using PatientDocumentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientDocumentation.Controllers
{
    
    public class PatientController : Controller
    {
        // GET: Patient
        [Authorize(Roles = "Admin,Receptionist,Provider")]
        public ActionResult Index()
        {
            var service = new PatientService();
            var model = service.GetPatients();
            return View(model);
        }

        // GET: Create
        [Authorize(Roles = "Admin,Receptionist")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [Authorize(Roles = "Admin,Receptionist")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatientCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var service = new PatientService();
            if (service.CreatePatient(model))
            {
                TempData["SaveResult"] = "New Patient created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Patient could not be created.");
            return View(model);
        }

        //GET: Detail
        [Authorize(Roles = "Admin,Receptionist,Provider")]
        public ActionResult Details(int id)
        {
            var service = new PatientService();
            var model = service.GetPatientById(id);
            return View(model);
        }

        //GET: Edit
        [Authorize(Roles = "Admin,Receptionist,Provider")]
        public ActionResult Edit(int id)
        {
            var service = new PatientService();
            var detail = service.GetPatientById(id);
            var model = new PatientEdit
            {
                PatientId = detail.PatientId,
                FirstName = detail.FirstName,
                LastName = detail.LastName,
                DOB = detail.DOB,
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
        [Authorize(Roles = "Admin,Receptionist,Provider")]
        public ActionResult Edit(int id, PatientEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (model.PatientId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = new PatientService();
            if (service.UpdatePatient(model))
            {
                TempData["SaveResult"] = "Patient information updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Patient could not be updated.");
            return View(model);
        }

        //GET: Delete
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var service = new PatientService();
            var model = service.GetPatientById(id);
            return View(model);
        }

        //POST: Delete
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePatient(int id)
        {
            var service = new PatientService();
            service.DeletePatient(id);
            TempData["SaveResult"] = "Patient deleted.";
            return RedirectToAction("Index");
        }
    }
}