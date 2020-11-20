using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PatientDocumenation.Data;
using PatientDocumentation.Data;
using PatientDocumentation.Models.AppointmentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDocumentation.Services
{
    public class AppointmentService
    {
        private readonly Guid _userId;
        public AppointmentService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateAppointment(AppointmentCreate model)
        {
            var entity = new Appointment()
            {
                ScheduledStart = model.ScheduledStart,
                Length = model.Length,
                PatientId = model.PatientId,
                ProviderId = model.ProviderId,
                Created = DateTimeOffset.Now,
                CreatedBy = _userId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Appointments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AppointmentListItem> GetAppointments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Appointments.ToList();
                List<AppointmentListItem> Result = new List<AppointmentListItem>();
                foreach (Appointment e in query)
                {
                    AppointmentListItem appointment = new AppointmentListItem
                    {
                        AppointmentId = e.AppointmentId,
                        Patient = e.Patient.FullName,
                        ScheduledStart = e.ScheduledStart,
                        Length = e.Length,
                        Provider = e.Provider.FullName,
                        PatientId = e.PatientId
                    };
                    Result.Add(appointment);
                }
                return Result;
            }
        }

        public IEnumerable<AppointmentListItem> GetAppointmentsByPatient(int patientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Appointments.ToList();
                List<AppointmentListItem> Result = new List<AppointmentListItem>();
                foreach (Appointment e in query)
                {
                    if (e.PatientId == patientId)
                    {
                        AppointmentListItem appointment = new AppointmentListItem
                        {
                            AppointmentId = e.AppointmentId,
                            Patient = e.Patient.FullName,
                            ScheduledStart = e.ScheduledStart,
                            Length = e.Length,
                            Provider = e.Provider.FullName,
                            PatientId = e.PatientId
                        };
                        Result.Add(appointment);
                    }
                }
                    return Result;
            }
        }

        public IEnumerable<AppointmentListItem> GetAppointmentsByUser(string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Appointments.ToList();
                List<AppointmentListItem> result = new List<AppointmentListItem>();
                foreach (Appointment e in query)
                {
                    if (e.Provider.UserId == userId)
                    {
                        AppointmentListItem appointment = new AppointmentListItem
                        {
                            AppointmentId = e.AppointmentId,
                            Patient = e.Patient.FullName,
                            ScheduledStart = e.ScheduledStart,
                            Length = e.Length,
                            Provider = e.Provider.FullName,
                            PatientId = e.PatientId
                        };
                        result.Add(appointment);
                    }
                }
                return result;
            }
        }

        public AppointmentDetail GetAppointmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Appointments.Single(e => e.AppointmentId == id);
                return new AppointmentDetail
                {
                    AppointmentId = entity.AppointmentId,
                    ScheduledStart = entity.ScheduledStart,
                    Length = entity.Length,
                    Created = entity.Created,
                    CreatedBy = entity.CreatedBy,
                    Modified = entity.Modified,
                    ModifiedBy = entity.ModifiedBy,
                    PatientId = entity.PatientId,
                    Patient = entity.Patient.FullName,
                    ProviderId = entity.ProviderId,
                    Provider = entity.Provider.FullName
                };
            }
        }

        public bool UpdateAppointment(AppointmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Appointments.Single(e => e.AppointmentId == model.AppointmentId);
                entity.ScheduledStart = model.ScheduledStart;
                entity.Length = model.Length;
                entity.PatientId = model.PatientId;
                entity.ProviderId = model.ProviderId;
                entity.Modified = DateTimeOffset.Now;
                entity.ModifiedBy = _userId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAppointment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Appointments.Single(e => e.AppointmentId == id);
                ctx.Appointments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
