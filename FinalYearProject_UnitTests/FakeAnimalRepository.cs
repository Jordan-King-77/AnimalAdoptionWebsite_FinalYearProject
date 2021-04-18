using AnimalAdoptionWebsite_FinalYearProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject_UnitTests
{
    class FakeAnimalRepository : IRepository<Animal>
    {
        public bool found;

        public FakeAnimalRepository(bool found = true)
        {
            this.found = found;
        }

        public void Add(Animal entity)
        {
        }

        public UserManager<ApplicationUser> CreateUserStore()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public Animal Find(int? Id)
        {
            if (found)
            {
                return new Animal();
            }
            return null;
        }

        public Animal FindGuid(Guid? id)
        {
            if (found)
            {
                return new Animal();
            }
            return null;
        }

        public IEnumerable<Animal> Search(SearchViewModel search)
        {
            if (found)
            {
                return new List<Animal>();
            }
            return null;
        }

        public List<Animal> ToList()
        {
            return new List<Animal>();
        }

        public void Update(Animal entity)
        {
        }
    }
}
