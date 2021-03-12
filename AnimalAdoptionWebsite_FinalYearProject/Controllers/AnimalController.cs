using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalAdoptionWebsite_FinalYearProject.Controllers
{
    public class AnimalController : Controller
    {
        // GET: Animal
        [Authorize(Roles = "Admin,User")]
        public ActionResult CreateAnimal()
        {
            return View();
        }


    }
}