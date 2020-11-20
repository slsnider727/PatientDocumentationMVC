using PatientDocumenation.Data;
using PatientDocumentation.Data;
using PatientDocumentation.Models.ClinicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace PatientDocumentation.Services
{
    public class ClinicService
    {
        public bool CreateClinic(ClinicCreate model)
        {
            var entity = new Clinic()
            {
                Name = model.Name,
                Address = model.Address,
                City = model.City,
                State = model.State,
                Zip = model.Zip,
                Phone = model.Phone
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Clinics.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ClinicListItem> GetClinics()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Clinics.Select(e => new ClinicListItem
                {
                    ClinicId = e.ClinicId,
                    Name = e.Name,
                    Address = e.Address,
                    City = e.City,
                    State = e.State,
                    Zip = e.Zip,
                    Phone = e.Phone
                }
                );
                return query.ToArray();
            }
        }

        public ClinicDetail GetClinicById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Clinics.Single(e => e.ClinicId == id);
                return new ClinicDetail
                {
                    ClinicId = entity.ClinicId,
                    Name = entity.Name,
                    Address = entity.Address,
                    City = entity.City,
                    State = entity.State,
                    Zip = entity.Zip,
                    Phone = entity.Phone
                };
            }
        }

        public bool UpdateClinic(ClinicEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Clinics.Single(e => e.ClinicId == model.ClinicId);
                entity.Name = model.Name;
                entity.Address = model.Address;
                entity.City = model.City;
                entity.State = model.State;
                entity.Zip = model.Zip;
                entity.Phone = model.Phone;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteClinic(int clinicId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Clinics.Single(e => e.ClinicId == clinicId);
                ctx.Clinics.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
