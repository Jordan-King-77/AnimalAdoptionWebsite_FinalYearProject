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

        public IEnumerable<Animal> Search(SearchViewModel search)
        {
            var model =
                from m in context.Animals
                orderby m.Name ascending
                where (search.Name == null || m.Name.StartsWith(search.Name))
                where (search.Gender == null || m.Gender.StartsWith(search.Gender))
                where (search.Type == null || m.Type.StartsWith(search.Type))
                where (search.CompatibleWithOtherAnimals == null || m.CompatibleWithOtherAnimals.StartsWith(search.CompatibleWithOtherAnimals))
                where (search.CompatibleWithChildren == null || m.CompatibleWithChildren.StartsWith(search.CompatibleWithChildren))
                where (search.Tag == null || m.Tag1.StartsWith(search.Tag) || m.Tag2.StartsWith(search.Tag) || m.Tag3.StartsWith(search.Tag) || m.Tag4.StartsWith(search.Tag) || m.Tag5.StartsWith(search.Tag))
                where (search.DateOfBirthStartDT == null && search.DateOfBirthEndDT == null || m.DateOfBirth > search.DateOfBirthStartDT && m.DateOfBirth < search.DateOfBirthEndDT)
                select m;

            return model;
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