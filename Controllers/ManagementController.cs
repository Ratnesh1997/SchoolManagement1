using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Controllers
{
    public class ManagementController : Controller
    {
        private readonly DataContext categoryServices;
        public ManagementController(DataContext CategoryServices)
        {
            this.categoryServices = CategoryServices;
          
        }
        public IActionResult Index()
        {

            var cats = categoryServices.ImageUploads.ToList();
            return View(cats);
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var cats = categoryServices.ImageUploads.FirstOrDefault(x=>x.Id==id);

            return PartialView("_Details",cats);
        }
    }
}
