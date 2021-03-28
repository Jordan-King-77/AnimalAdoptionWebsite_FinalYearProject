using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AnimalAdoptionWebsite_FinalYearProject.Models
{
    public class AnimalRepository : IRepository<Animal>
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public void Add(Animal entity)
        {
            context.Animals.Add(entity);
            context.SaveChanges();
        }

        public UserManager<ApplicationUser> CreateUserStore()
        {
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);

            return manager;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Animal Find(int? Id)
        {
            return context.Animals.Find(Id);
        }

        public Animal FindGuid(Guid? id)
        {
            return context.Animals.Find(id);
        }

        public List<Animal> ToList()
        {
            return context.Animals.ToList();
        }

        public void Update(Animal entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}