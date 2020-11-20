using Microsoft.AspNet.Identity;
using PatientDocumenation.Data;
using PatientDocumentation.Models.AppointmentModels;
using PatientDocumentation.Models.TreatmentNoteModels;
using PatientDocumentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientDocumentation.Controllers
{
    public class TreatmentNoteController : Controller
    {
        // GET: TreatmentNote
        [Authorize(Roles = "Admin,Receptionist,Provider")]
        public ActionResult Index(int id)
        {
            var service = CreateTreatmentNoteService();
            var model = service.GetNotes(id);
            return View(model);
        }

        // GET: Create
        [Authorize(Roles = "Admin,Provider")]
        public ActionResult Create(int id)
        {
            var service = CreateTreatmentNoteService();
            var appointment = service.GetAppointmentById(id);
            var model = new TreatmentNoteCreate
            {
                AppointmentId = appointment.AppointmentId,
                PatientId = appointment.PatientId,
                StartTime = DateTime.Now
            };
            return View(model);
        }

        // POST: Create
        [Authorize(Roles = "Admin,Provider")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TreatmentNoteCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var service = CreateTreatmentNoteService();
            if (service.CreateTreatmentNote(model))
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var aptservice = new AppointmentService(userId);
                AppointmentDetail appointment = aptservice.GetAppointmentById(model.AppointmentId);
                TempData["SaveResult"] = "Your note was saved.";
                return RedirectToAction("Index", "TreatmentNote", new { id = appointment.PatientId });
            }
            ModelState.AddModelError("", "Note could not be created.");
            return View(model);
        }

        // GET: Details
        [Authorize(Roles = "Admin,Receptionist,Provider")]
        public ActionResult Details(int id)
        {
            var service = CreateTreatmentNoteService();
            var model = service.GetNoteById(id);

            return View(model);
        }

        // GET: Edit
        [Authorize(Roles = "Admin,Provider")]
        public ActionResult Edit(int id)
        {
            var service = CreateTreatmentNoteService();
            var detail = service.GetNoteById(id);
            var model = new TreatmentNoteEdit
            {
                TreatmentNoteId = detail.TreatmentNoteId,
                StartTime = detail.StartTime,
                EndTime = detail.EndTime,
                Content = detail.Content
            };
            return View(model);
        }

        // POST: Edit
        [Authorize(Roles = "Admin,Provider")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TreatmentNoteEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (model.TreatmentNoteId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateTreatmentNoteService();
            if (service.UpdateTreatmentNote(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        //GET: Delete
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var service = CreateTreatmentNoteService();
            var model = service.GetNoteById(id);

            return View(model);
        }

        //POST: Delete
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTreatmentNote(int id)
        {
            var service = CreateTreatmentNoteService();
            service.DeleteTreatmentNote(id);
            TempData["SaveResult"] = "Your note was deleted.";
            return RedirectToAction("Index", "Patient", null);
        }

        private TreatmentNoteService CreateTreatmentNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var treatmentNoteService = new TreatmentNoteService(userId);
            return treatmentNoteService;
        }
    }
}