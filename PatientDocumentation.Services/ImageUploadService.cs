using PatientDocumenation.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PatientDocumentation.Services
{
    public class ImageUploadService
    {
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            BinaryReader reader = new BinaryReader(image.InputStream);
            byte[] imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        public byte[] GetImage(Provider provider)
        {
            if (provider == null)
            {
                return new byte[0];
            }
            else
                return provider.Image;
        }

        //will need ^^ for Clinic as well
    }
}
