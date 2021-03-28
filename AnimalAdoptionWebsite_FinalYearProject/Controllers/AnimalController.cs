using AnimalAdoptionWebsite_FinalYearProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AnimalAdoptionWebsite_FinalYearProject.Controllers
{
    public class AnimalController : Controller
    {
        private IRepository<Animal> animalRP;

        public AnimalController()
        {
            animalRP = new AnimalRepository();
        }

        public AnimalController(IRepository<Animal> repository)
        {
            animalRP = repository;
        }

        // GET: CreateAnimal
        [Authorize(Roles = "Admin,User")]
        public ViewResult CreateAnimal()
        {
            return View();
        }

        //POST: CreateAnimal
        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public ActionResult CreateAnimal(AnimalViewModel model)
        {
            ApplicationUser rehomer = null;
            if (ModelState.IsValid)
            {
                if(model.RehomerEmail != null)
                {
                    var userManager = animalRP.CreateUserStore();

                    rehomer = userManager.FindByEmail(model.RehomerEmail);
                }

                Animal animal = new Animal
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Type = model.Type,
                    Gender = model.Gender,
                    DateOfBirth = model.DateOfBirthDT,
                    Description = model.Description,
                    MedicalHistory = model.MedicalHistory,
                    Behaviour = model.Behaviour,
                    BackgroundInfo = model.BackgroundInfo,
                    HouseholdRequirements = model.HouseholdRequirements,
                    DietaryNeeds = model.DietaryNeeds,
                    CompatibleWithOtherAnimals = model.CompatibleWithOtherAnimals,
                    CompatibleWithChildren = model.CompatibleWithChildren,
                    Tag1 = model.Tag1,
                    Tag2 = model.Tag2,
                    Tag3 = model.Tag3,
                    Tag4 = model.Tag4,
                    Tag5 = model.Tag5,
                    Rehomer = rehomer
                };

                animalRP.Add(animal);

                return View("AnimalDisplay", animal);
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult FindAnimal(Guid? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var animal = animalRP.FindGuid(id);

            if(animal == null)
            {
                return HttpNotFound();
            }

            return View("AnimalDisplay", animal);
        }

        //TODO: Implement Search Function
    }
}