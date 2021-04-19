using AnimalAdoptionWebsite_FinalYearProject.Controllers;
using AnimalAdoptionWebsite_FinalYearProject.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Web.Mvc;

namespace FinalYearProject_UnitTests
{
    [TestClass]
    public class AnimalUnitTests
    {
        [TestMethod]
        public void CreateAnimalGet_ReturnsView()
        {
            var controller = new AnimalController(new FakeAnimalRepository());
            Assert.IsInstanceOfType(controller.CreateAnimal(), typeof(ViewResult));
        }

        //[TestMethod]
        //public void CreateAnimalPost_ReturnsView()
        //{
        //    var controller = new AnimalController(new FakeAnimalRepository());

        //    AnimalViewModel m = new AnimalViewModel
        //    {
        //        Name = "Test",
        //        Type = "Dog",
        //        Gender = "Male",
        //        DateOfBirthString = "20 April 2020",
        //        Description = "Test",
        //        MedicalHistory = "Test",
        //        Behaviour = "Test",
        //        BackgroundInfo = "Test",
        //        HouseholdRequirements = "Test",
        //        DietaryNeeds = "Test",
        //        CompatibleWithOtherAnimals = "Yes",
        //        CompatibleWithChildren = "Yes",
        //        Tag1 = "Playful",
        //        Tag2 = "Energetic",
        //        Tag3 = "Happy",
        //        Tag4 = "Affectionate",
        //        Tag5 = "Loving",
        //        RehomerEmail = "steve@gmail.com",
        //    };

        //    Assert.IsInstanceOfType(controller.CreateAnimal(m), typeof(ViewResult));
        //}

        [TestMethod]
        public void CreateAnimalPost_InvalidModel()
        {
            var controller = new AnimalController(new FakeAnimalRepository());

            AnimalViewModel m = new AnimalViewModel();

            Assert.IsInstanceOfType(controller.CreateAnimal(m), typeof(ViewResult));
        }

        [TestMethod]
        public void EditAnimalGet_ReturnsView()
        {
            var controller = new AnimalController(new FakeAnimalRepository());

            Assert.IsInstanceOfType(controller.EditAnimal(Guid.NewGuid()), typeof(ViewResult));
        }

        [TestMethod]
        public void EditAnimalPost_ReturnsView()
        {
            var controller = new AnimalController(new FakeAnimalRepository());

            AnimalViewModel m = new AnimalViewModel();

            Assert.IsInstanceOfType(controller.EditAnimal(Guid.NewGuid(), m), typeof(ViewResult));
        }

        [TestMethod]
        public void EditAnimalPost_IdNull()
        {
            var controller = new AnimalController(new FakeAnimalRepository());
            AnimalViewModel m = new AnimalViewModel();

            var expected = (int)HttpStatusCode.BadRequest;

            var actionResult = controller.EditAnimal(null, m) as HttpStatusCodeResult;

            Assert.IsNotNull(actionResult);
            Assert.AreEqual(expected, actionResult.StatusCode);
        }

        [TestMethod]
        public void EditAnimalPost_AnimalNull()
        {
            var controller = new AnimalController(new FakeAnimalRepository(false));

            AnimalViewModel m = new AnimalViewModel();

            Assert.IsInstanceOfType(controller.EditAnimal(Guid.NewGuid(), m), typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void FindAnimalByIdGet_ReturnsView()
        {
            var controller = new AnimalController(new FakeAnimalRepository());

            Assert.IsInstanceOfType(controller.FindAnimalById(), typeof(ViewResult));
        }

        [TestMethod]
        public void FindAnimalByIdPost_ReturnsRedirectToRouteResult()
        {
            var controller = new AnimalController(new FakeAnimalRepository());

            Assert.IsInstanceOfType(controller.FindAnimalById(Guid.NewGuid()), typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void FindAnimal_ReturnsView()
        {
            var controller = new AnimalController(new FakeAnimalRepository());

            Assert.IsInstanceOfType(controller.FindAnimal(Guid.NewGuid()), typeof(ViewResult));
        }

        [TestMethod]
        public void FindAnimal_IdNull()
        {
            var controller = new AnimalController(new FakeAnimalRepository());

            var expected = (int)HttpStatusCode.BadRequest;

            var actionResult = controller.FindAnimal(null) as HttpStatusCodeResult;

            Assert.IsNotNull(actionResult);
            Assert.AreEqual(expected, actionResult.StatusCode);
        }

        [TestMethod]
        public void FindAnimal_AnimalNull()
        {
            var controller = new AnimalController(new FakeAnimalRepository(false));

            Assert.IsInstanceOfType(controller.FindAnimal(Guid.NewGuid()), typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void SearchAnimalGet_ReturnsView()
        {
            var controller = new AnimalController(new FakeAnimalRepository());

            Assert.IsInstanceOfType(controller.SearchAnimal(), typeof(ViewResult));
        }

        [TestMethod]
        public void SearchAnimalResults_ReturnsView()
        {
            var controller = new AnimalController(new FakeAnimalRepository());

            SearchViewModel m = new SearchViewModel
            {
                Name = "Test",
                Type = "Dog",
                Gender = "Female"
            };

            Assert.IsInstanceOfType(controller.SearchAnimalResults(m), typeof(ViewResult));
        }

        [TestMethod]
        public void SearchAnimalResults_InvalidModel()
        {
            var controller = new AnimalController(new FakeAnimalRepository());

            SearchViewModel m = new SearchViewModel
            {
                DateOfBirthStartString = "20 April 2020"
            };

            Assert.IsInstanceOfType(controller.SearchAnimalResults(m), typeof(ViewResult));
        }

        [TestMethod]
        public void UploadImageToAnimalGet_ReturnsView()
        {
            var controller = new AnimalController(new FakeAnimalRepository());

            Assert.IsInstanceOfType(controller.UploadImageToAnimal(Guid.NewGuid()), typeof(ViewResult));
        }

        [TestMethod]
        public void UploadImageToAnimalPost_ReturnsView()
        {
            var controller = new AnimalController(new FakeAnimalRepository());

            Assert.IsInstanceOfType(controller.UploadImageToAnimal(Guid.NewGuid(), null), typeof(ViewResult));
        }

        [TestMethod]
        public void UploadImageToAnimalPost_IdNull()
        {
            var controller = new AnimalController(new FakeAnimalRepository());

            var expected = (int)HttpStatusCode.BadRequest;

            var actionResult = controller.UploadImageToAnimal(null, null) as HttpStatusCodeResult;

            Assert.IsNotNull(actionResult);
            Assert.AreEqual(expected, actionResult.StatusCode);
        }

        [TestMethod]
        public void UploadImageToAnimalPost_AnimalNull()
        {
            var controller = new AnimalController(new FakeAnimalRepository(false));

            Assert.IsInstanceOfType(controller.UploadImageToAnimal(Guid.NewGuid(), null), typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void ChangeAvailability_ReturnsView()
        {
            var controller = new AnimalController(new FakeAnimalRepository());

            Assert.IsInstanceOfType(controller.ChangeAvailability(Guid.NewGuid()), typeof(ViewResult));
        }

        [TestMethod]
        public void ChangeAvailability_IdNull()
        {
            var controller = new AnimalController(new FakeAnimalRepository());

            var expected = (int)HttpStatusCode.BadRequest;

            var actionResult = controller.ChangeAvailability(null) as HttpStatusCodeResult;

            Assert.IsNotNull(actionResult);
            Assert.AreEqual(expected, actionResult.StatusCode);
        }

        [TestMethod]
        public void ChangeAvailability_AnimalNull()
        {
            var controller = new AnimalController(new FakeAnimalRepository(false));

            Assert.IsInstanceOfType(controller.ChangeAvailability(Guid.NewGuid()), typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void RegisterInterest_ReturnsView()
        {
            var controller = new AnimalController(new FakeAnimalRepository());

            Assert.IsInstanceOfType(controller.RegisterInterest(Guid.NewGuid()), typeof(ViewResult));
        }

        [TestMethod]
        public void RegisterInterest_IdNull()
        {
            var controller = new AnimalController(new FakeAnimalRepository());

            var expected = (int)HttpStatusCode.BadRequest;

            var actionResult = controller.RegisterInterest(null) as HttpStatusCodeResult;

            Assert.IsNotNull(actionResult);
            Assert.AreEqual(expected, actionResult.StatusCode);
        }

        [TestMethod]
        public void RegisterInterest_AnimalNull()
        {
            var controller = new AnimalController(new FakeAnimalRepository(false));

            Assert.IsInstanceOfType(controller.RegisterInterest(Guid.NewGuid()), typeof(HttpNotFoundResult));
        }
    }
}
