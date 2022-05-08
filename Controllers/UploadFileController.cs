using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DataAccess;
using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Controllers
{
    public class UploadFileController : Controller
    {
        private readonly DataContext categoryServices;
        [Obsolete]
        private readonly IHostingEnvironment environment;

        [Obsolete]
        public UploadFileController(DataContext CategoryServices,
            IHostingEnvironment _environment)
        {
            this.categoryServices = CategoryServices;
            environment = _environment;
        }


        public IActionResult Create()

        {
            return View();
        }
        [HttpPost]
        [Obsolete]
        public IActionResult Create(ImageUpload model)
        {
            //var path = environment.WebRootPath;
            //var filepath = "Images" + model.Image.FileName;
            //var fullpath = Path.Combine(path, filepath);
            //categoryServices.UploadFile(model.Image, fullpath);

            var img = Request.Form.Files;
            string dbpath = string.Empty;
            if (img.Count > 0)
            {
                string path = environment.WebRootPath;
                string fullpath = Path.Combine(path, "Images", img[0].FileName);
                dbpath = "/Images/" + img[0].FileName;
                FileStream stream = new FileStream(fullpath, FileMode.Create);
                img[0].CopyTo(stream);

            }
            model.Image = dbpath;
            categoryServices.ImageUploads.Add(model);
            categoryServices.SaveChanges();
            return RedirectToAction("Index","Management");
            //var ImageUpload = new ImageUpload()
            //{
            //    Name = model.Name,
            //    Contact = model.Contact,
            //    Address = model.Address,
            //    Image = dbpath

            //};

        }

       
    }
    }
