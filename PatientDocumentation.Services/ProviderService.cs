using PatientDocumenation.Data;
using PatientDocumentation.Data;
using PatientDocumentation.Models.PatientModels;
using PatientDocumentation.Models.ProviderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDocumentation.Services
{
    public class ProviderService
    {
        ImageUploadService _imageService = new ImageUploadService();
        public bool CreateProvider(ProviderCreate model)
        {
            var entity = new Provider()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Title = model.Title,
                License = model.License,
                Specialization = model.Specialization,
                ClinicId = model.ClinicId,
                UserId = model.UserId,
                Image = _imageService.ConvertToBytes(model.ImageFile)
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Providers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProviderListItem> GetProviders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Providers.ToList();
                List<ProviderListItem> Result = new List<ProviderListItem>();
                foreach (Provider e in query)
                {
                    ProviderListItem provider = new ProviderListItem
                    {
                        ProviderId = e.ProviderId,
                        FullName = e.FullName,
                        Specialization = e.Specialization,
                        Clinic = e.Clinic.Name,
                        ImageAsBytes = e.Image
                    };
                    Result.Add(provider);
                }
                return Result;
            }
        }

        public ProviderDetail GetProviderById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Providers.Single(e => e.ProviderId == id);
                return new ProviderDetail
                {
                    ProviderId = entity.ProviderId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Title = entity.Title,
                    FullName = entity.FullName,
                    License = entity.License,
                    Specialization = entity.Specialization,
                    ClinicId = entity.ClinicId,
                    Clinic = entity.Clinic.Name,
                    ClinicPhone = entity.Clinic.Phone,
                    ClinicAddress = entity.Clinic.Address,
                    ClinicCityStateZip = ($"{ entity.Clinic.City}, {entity.Clinic.State} {entity.Clinic.Zip}"),
                    UserId = entity.UserId,
                    ImageAsBytes = entity.Image
                };
            }
        }

        public bool UpdateProvider(ProviderEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Providers.Single(e => e.ProviderId == model.ProviderId);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Title = model.Title;
                entity.License = model.License;
                entity.Specialization = model.Specialization;
                entity.ClinicId = model.ClinicId;
                entity.UserId = model.UserId;
                if (model.Image != null)
                {
                    entity.Image = _imageService.ConvertToBytes(model.Image);
                }

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProvider(int providerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Providers.Single(e => e.ProviderId == providerId);
                ctx.Providers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
