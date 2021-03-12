namespace AnimalAdoptionWebsite_FinalYearProject.Migrations
{
    using AnimalAdoptionWebsite_FinalYearProject.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AnimalAdoptionWebsite_FinalYearProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AnimalAdoptionWebsite_FinalYearProject.Models.ApplicationDbContext context)
        {
            //Create Roles
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if(!context.Roles.Any(r => r.Name == "Admin"))
            {
                var role = new IdentityRole { Id = "1", Name = "Admin" };
                roleManager.Create(role);
            }

            if(!context.Roles.Any(r => r.Name == "User"))
            {
                var role = new IdentityRole { Id = "2", Name = "User" };
                roleManager.Create(role);
            }


            //Create users to put into the created roles
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if(!context.Users.Any(u => u.UserName == "Admin@gmail.co.uk"))
            {
                var user = new ApplicationUser
                {
                    UserName = "Admin@gmail.co.uk",
                    Email = "Admin@gmail.co.uk",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Admin",
                    LastName = "Admin",
                    Gender = "Male",
                    Address = "London",
                    PhoneNumber = "0800750224",
                    DateOfBirth = new DateTime(1980, 5, 21)
                };

                userManager.Create(user, "Password123!");
                userManager.AddToRole(user.Id, "Admin");
            }

            if(!context.Users.Any(u => u.UserName == "Steve@gmail.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "Steve@gmail.com",
                    Email = "Steve@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Steve",
                    LastName = "Walker",
                    Gender = "Male",
                    Address = "London",
                    PhoneNumber = "0800920118",
                    DateOfBirth = new DateTime(1986, 1, 1)
                };

                userManager.Create(user, "Password1!");
                userManager.AddToRole(user.Id, "User");
            }

            if(!context.Users.Any(u => u.UserName == "DavidFoster@gmail.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "DavidFoster@gmail.com",
                    Email = "DavidFoster@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "David",
                    LastName = "Foster",
                    Gender = "Male",
                    Address = "Stoke-On-Trent",
                    PhoneNumber = "0145824438",
                    DateOfBirth = new DateTime(1988, 4, 11)
                };

                userManager.Create(user, "Foster1!");
                userManager.AddToRole(user.Id, "User");
            }

            //Create animals to populate the database
            if(!context.Animals.Any(a => a.Name == "Rex"))
            {
                ApplicationUser user = userManager.FindByEmail("DavidFoster@gmail.com");

                var animal = new Animal
                {
                    Id = Guid.NewGuid(),
                    Name = "Rex",
                    Type = "Dog",
                    Gender = "Male",
                    DateOfBirth = new DateTime(2020, 5, 11),
                    Description = "Rex is a friendly dog who likes playing and cuddles.",
                    MedicalHistory = "Rex is a very healthy dog, with no known health issues.",
                    Behaviour = "Rex is very friendly, playful pup, who will happily cuddle with you on the sofa!",
                    BackgroundInfo = "Rex was left with us after his previous owner was unable to continue taking care of him.",
                    HouseholdRequirements = "Rex needs a lot of garden space to run around and exercise in.",
                    DietaryNeeds = "Rex will be happy with a pure kibble diet, although he would also appreciate some meat, fish or rice for a special treat!",
                    CompatibleWithOtherAnimals = "Yes",
                    CompatibleWithChildren = "Yes",
                    Tag1 = "Happy",
                    Tag2 = "Playful",
                    Tag3 = "Energetic",
                    Tag4 = "Affectionate",
                    Tag5 = "Loving",
                    Rehomer = user
                };

                context.Animals.AddOrUpdate(animal);
            }

            if (!context.Animals.Any(a => a.Name == "Oliver"))
            {
                ApplicationUser user = userManager.FindByEmail("Steve@gmail.com");

                var animal = new Animal
                {
                    Id = Guid.NewGuid(),
                    Name = "Oliver",
                    Type = "Cat",
                    Gender = "Male",
                    DateOfBirth = new DateTime(2020, 5, 11),
                    Description = "Oliver is a calm cat who enjoys relaxing.",
                    MedicalHistory = "Oliver has notable hearing difficulties.",
                    Behaviour = "Oliver enjoys a calm atmosphere, and does not take well to excitable situations.",
                    BackgroundInfo = "We found Oliver as a stray cat, and has been with us ever since.",
                    HouseholdRequirements = "Oliver may need his own quiet corner of the house to go to occassionally.",
                    DietaryNeeds = "Oliver needs to eat both tinned and dried food. Tinned for nourishment, and dried to clean his teeth.",
                    CompatibleWithOtherAnimals = "No",
                    CompatibleWithChildren = "No",
                    Tag1 = "Calm",
                    Tag2 = "Hesitant",
                    Tag3 = "Nervous",
                    Tag4 = "Peaceful",
                    Tag5 = "Relaxing"//,
                    //Rehomer = user
                };

                context.Animals.AddOrUpdate(animal);
            }
        }
    }
}
