using AnimalAdoptionWebsite_FinalYearProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditAnimal(Guid Id)
        {
            ViewBag.AnimalId = Id;

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditAnimal(Guid Id, AnimalViewModel model)
        {
            if(Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var animal = animalRP.FindGuid(Id);
            if (animal == null)
            {
                return HttpNotFound();
            }

            if(model.Name != null) { animal.Name = model.Name; }            
            if (model.Description != null) { animal.Description = model.Description; }
            if (model.MedicalHistory != null) { animal.MedicalHistory = model.MedicalHistory; }
            if (model.DietaryNeeds != null) { animal.DietaryNeeds = model.DietaryNeeds; }
            if (model.Behaviour != null) { animal.Behaviour = model.Behaviour; }
            if (model.BackgroundInfo != null) { animal.BackgroundInfo = model.BackgroundInfo; }
            if (model.HouseholdRequirements != null) { animal.HouseholdRequirements = model.HouseholdRequirements; }            

            animal.Type = model.Type;
            animal.Gender = model.Gender;
            animal.CompatibleWithChildren = model.CompatibleWithChildren;
            animal.CompatibleWithOtherAnimals = model.CompatibleWithOtherAnimals;
            animal.Tag1 = model.Tag1;
            animal.Tag2 = model.Tag2;
            animal.Tag3 = model.Tag3;
            animal.Tag4 = model.Tag4;
            animal.Tag5 = model.Tag5;

            animalRP.Update(animal);                

            return View("AnimalDisplay", animal);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult FindAnimal()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
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

        [AllowAnonymous]
        public ViewResult SearchAnimal()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult SearchAnimalResults(SearchViewModel model)
        {
            if(ModelState.IsValid)
            {
                var animals = animalRP.Search(model);

                return View(animals);
            }

            return View("SearchAnimal", model);
        }

        [Authorize(Roles = "Admin")]
        public ViewResult UploadImageToAnimal(Guid? Id)
        {
            ViewBag.Id = Id;

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult UploadImageToAnimal(Guid? Id, HttpPostedFileBase Image)
        {
            try
            {
                if (Id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var animal = animalRP.FindGuid(Id);

                if (animal == null)
                {
                    return HttpNotFound();
                }

                string strDateTime = DateTime.Now.ToString("ddMMyyyyHHMMss");
                string finalPath = "\\Images\\" + strDateTime + Image.FileName;

                Image.SaveAs(Server.MapPath("~") + finalPath);

                animal.Image = finalPath;
                animalRP.Update(animal);

                return View("AnimalDisplay", animal);
            }

            catch(Exception ex)
            {
                ViewBag.Exception = ex.Message.ToString();
                return View("Index");
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ChangeAvailability(Guid Id)
        {
            if(Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var animal = animalRP.FindGuid(Id);

            if(animal == null)
            {
                return HttpNotFound();
            }

            if (animal.IsUnavailable == false) { animal.IsUnavailable = true; }
            else if (animal.IsUnavailable == true) { animal.IsUnavailable = false; }

            animalRP.Update(animal);

            return View("AnimalDisplay", animal);
        }

        [Authorize(Roles = "User")]
        public ActionResult RegisterInterest(Guid Id)
        {
            if(Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var animal = animalRP.FindGuid(Id);

            if(animal == null)
            {
                return HttpNotFound();
            }

            animal.InterestedUsers++;
            animalRP.Update(animal);

            return View("AnimalDisplay", animal);
        }
    }
}