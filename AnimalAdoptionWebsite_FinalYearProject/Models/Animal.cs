using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AnimalAdoptionWebsite_FinalYearProject.Models
{
    public class Animal
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser Rehomer { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        public string Gender { get; set; }

        [StringLength(20)]
        public string Type { get; set; }
        public DateTime DateOfBirth { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(200)]
        public string MedicalHistory { get; set; }

        [StringLength(200)]
        public string DietaryNeeds { get; set; }

        [StringLength(200)]
        public string Behaviour { get; set; }

        [StringLength(200)]
        public string BackgroundInfo { get; set; }

        [StringLength(200)]
        public string HouseholdRequirements { get; set; }

        public string CompatibleWithOtherAnimals { get; set; }
        public string CompatibleWithChildren { get; set; }

        public string Image { get; set; }
        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
        public string Tag3 { get; set; }
        public string Tag4 { get; set; }
        public string Tag5 { get; set; }
    }
}