using PatientDocumenation.Data;
using PatientDocumentation.Data;
using PatientDocumentation.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDocumentation.Services
{
    public class PatientService
    {
        public bool CreatePatient(PatientCreate model)
        {
            var entity = new Patient()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DOB = model.DOB,
                Address = model.Address,
                City = model.City,
                State = model.State,
                Zip = model.Zip,
                Phone = model.Phone
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Patients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PatientListItem> GetPatients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Patients.Select(e => new PatientListItem
                {
                    PatientId = e.PatientId,
                    LastName = e.LastName,
                    FirstName = e.FirstName,
                    DOB = e.DOB
                }
                );
                return query.ToArray();
            }
        }

        public PatientDetail GetPatientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Patients.Single(e => e.PatientId == id);
                return new PatientDetail
                {
                    PatientId = entity.PatientId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    FullName = entity.FullName,
                    DOB = entity.DOB,
                    Age = entity.Age,
                    Address = entity.Address,
                    City = entity.City,
                    State = entity.State,
                    Zip = entity.Zip,
                    Phone = entity.Phone
                };
            }
        }

        public bool UpdatePatient(PatientEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Patients.Single(e => e.PatientId == model.PatientId);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.DOB = model.DOB;
                entity.Address = model.Address;
                entity.City = model.City;
                entity.State = model.State;
                entity.Zip = model.Zip;
                entity.Phone = model.Phone;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePatient(int patientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Patients.Single(e => e.PatientId == patientId);
                ctx.Patients.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
