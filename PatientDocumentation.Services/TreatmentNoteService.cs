using PatientDocumenation.Data;
using PatientDocumentation.Data;
using PatientDocumentation.Models.AppointmentModels;
using PatientDocumentation.Models.TreatmentNoteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDocumentation.Services
{
    public class TreatmentNoteService
    {
        private readonly Guid _userId;
        public TreatmentNoteService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateTreatmentNote(TreatmentNoteCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Appointment appointment = GetAppointmentById(model.AppointmentId);
                //Appointment appointment = ctx.Appointments.Single(e => e.AppointmentId == model.AppointmentId);
                var entity = new TreatmentNote()
            {
                AuthorId = _userId,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                Content = model.Content,
                AppointmentId = model.AppointmentId,
                Created = DateTimeOffset.Now,
                PatientId = appointment.PatientId
            };

                ctx.TreatmentNotes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public Appointment GetAppointmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Appointments.Single(e => e.AppointmentId == id);
            }
        }

        //Is there a better way to do this?
        public IEnumerable<TreatmentNoteListItem> GetNotes(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.TreatmentNotes.ToList();
                List<TreatmentNoteListItem> Result = new List<TreatmentNoteListItem>();
                foreach (TreatmentNote e in query)
                {
                    if (e.Appointment.PatientId == id)
                    {
                        TreatmentNoteListItem treatmentNote = new TreatmentNoteListItem
                        {
                            TreatmentNoteId = e.TreatmentNoteId,
                            PatientName = e.Appointment.Patient.FullName,
                            ProviderName = e.Appointment.Provider.FullName,
                            Created = e.Created,
                            AppointmentDate = e.Appointment.ScheduledStart
                        };
                        Result.Add(treatmentNote);
                    }
                }
                return Result;
            }
        }

        public TreatmentNoteDetail GetNoteById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.TreatmentNotes.Single(e => e.TreatmentNoteId == id);
                return new TreatmentNoteDetail
                {
                    TreatmentNoteId = entity.TreatmentNoteId,
                    AuthorId = entity.AuthorId,
                    Patient = entity.Appointment.Patient.FullName,
                    Provider = entity.Appointment.Provider.FullName,
                    StartTime = entity.StartTime,
                    EndTime = entity.EndTime,
                    TotalTreatTime = entity.TotalTreatTime,
                    Content = entity.Content,
                    Created = entity.Created,
                    Modified = entity.Modified,
                    AppointmentId = entity.AppointmentId,
                    PatientId = entity.Appointment.PatientId
                };
            }
        }

        public bool UpdateTreatmentNote(TreatmentNoteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.TreatmentNotes.Single(e => e.TreatmentNoteId == model.TreatmentNoteId && e.AuthorId == _userId);
                entity.StartTime = model.StartTime;
                entity.EndTime = model.EndTime;
                entity.Content = model.Content;
                entity.Modified = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTreatmentNote(int treatmentNoteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.TreatmentNotes.Single(e => e.TreatmentNoteId == treatmentNoteId);
                ctx.TreatmentNotes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
