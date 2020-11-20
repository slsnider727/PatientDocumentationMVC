using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientDocumentation.Controllers
{
    public class ImageUploadController : Controller
    {
        // GET: ImageUpload
        public ActionResult Index()
        {
            return View();
        }

        //POST: ImageUpload
        [HttpPost]
        public ActionResult UploadImages(HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (image != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/UploadedImages"), Path.GetFileName(image.FileName)); //Maybe change this to the name of the provider?
                        image.SaveAs(path);
                    }
                    ViewBag.FileStatus = "Image uploaded successfully.";
                }
                catch(Exception)
                {
                    ViewBag.FileStatus = "Error: Could not successfully upload image file.";
                }
            }
            return View("Index");
        }
    }
}