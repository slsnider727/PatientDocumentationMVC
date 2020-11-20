using Microsoft.AspNet.Identity;
using PatientDocumenation.Data;
using PatientDocumentation.Models.AppointmentModels;
using PatientDocumentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientDocumentation.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        [Authorize(Roles = "Admin,Receptionist,Provider")]
        public ActionResult Index()
        {
            var service = CreateAppointmentService();
            var model = service.GetAppointments();
            return View(model);
        }

        //GET: AppointmentsByUser
        [Authorize(Roles = "Provider")]
        public ActionResult IndexByUser()
        {
            var userId = User.Identity.GetUserId();
            var service = CreateAppointmentService();
            var model = service.GetAppointmentsByUser(userId);
            return View(model);
        }

        //GET: AppointmentsByPatient
        [Authorize(Roles = "Admin,Receptionist,Provider")]
        public ActionResult IndexByPatient(int id)
        {
            var patientService = new PatientService();
            string patientName = patientService.GetPatientById(id).FullName;
            ViewBag.Heading = "Appointments for " + patientName;
            var service = CreateAppointmentService();
            var model = service.GetAppointmentsByPatient(id);
            return View(model);
        }

        // GET: Create
        [Authorize(Roles = "Admin,Receptionist")]
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create
        [Authorize(Roles = "Admin,Receptionist")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var service = CreateAppointmentService();
            if (service.CreateAppointment(model))
            {
                TempData["SaveResult"] = "New Appointment created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Appointment could not be created.");
            return View(model);
        }

        //GET: Details
        [Authorize(Roles = "Admin,Receptionist,Provider")]
        public ActionResult Details(int id)
        {
            var service = CreateAppointmentService();
            var model = service.GetAppointmentById(id);
            return View(model); 
        }

        //GET: Edit
        [Authorize(Roles = "Admin,Receptionist")]
        public ActionResult Edit(int id)
        {
            var service = CreateAppointmentService();
            var detail = service.GetAppointmentById(id);
            var model = new AppointmentEdit
            {
                AppointmentId = detail.AppointmentId,
                ScheduledStart = detail.ScheduledStart,
                Length = detail.Length,
                PatientId = detail.PatientId,
                ProviderId = detail.ProviderId
            };
            return View(model);
        }

        //POST: Edit
        [Authorize(Roles = "Admin,Receptionist")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AppointmentEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (model.AppointmentId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateAppointmentService();
            if (service.UpdateAppointment(model))
            {
                TempData["SaveResult"] = "Your appointment was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your appointment could not be updated.");
            return View(model);
        }

        //GET: Delete
        [Authorize(Roles = "Admin,Receptionist")]
        public ActionResult Delete(int id)
        {
            var service = CreateAppointmentService();
            var model = service.GetAppointmentById(id);
            return View(model);
        }

        //POST: Delete
        [Authorize(Roles = "Admin,Receptionist")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAppointment(int id)
        {
            var service = CreateAppointmentService();
            service.DeleteAppointment(id);
            TempData["SaveResult"] = "Your appointment was deleted.";
            return RedirectToAction("Index");
        }


        private AppointmentService CreateAppointmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var appointmentService = new AppointmentService(userId);
            return appointmentService;
        }
    }
}