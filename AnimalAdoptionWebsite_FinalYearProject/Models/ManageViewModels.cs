using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace AnimalAdoptionWebsite_FinalYearProject.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }

    public class AnimalViewModel : IValidatableObject
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Animal Name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Animal Type is required")]
        [Display(Name = "Type (Dog, Cat, etc)")]
        public string Type { get; set; }

        [Required(ErrorMessage = "The Animal Gender is required")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Previous Owner Email (If applicable)")]
        public string RehomerEmail { get; set; }
        public ApplicationUser Rehomer { get; set; } = null;

        [Required(ErrorMessage = "The Date of Birth is required")]
        [Display(Name = "Date of Birth")]
        public string DateOfBirthString { get; set; }

        [Required(ErrorMessage = "The date of birth could not be parsed. Please try another format")]
        public DateTime DateOfBirthDT { get; set; }

        [Required(ErrorMessage = "Please give a brief description of your animal")]
        [StringLength(500)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [StringLength(500)]
        [Display(Name = "Medical History")]
        public string MedicalHistory { get; set; }

        [StringLength(500)]
        [Display(Name = "Dietary Needs")]
        public string DietaryNeeds { get; set; }

        [Required(ErrorMessage = "Please provide honest details on the behaviour of your animal")]
        [StringLength(500)]
        [Display(Name = "Behaviour")]
        public string Behaviour { get; set; }

        [StringLength(500)]
        [Display(Name = "Background Information")]
        public string BackgroundInfo { get; set; }

        [StringLength(500)]
        [Display(Name = "Household Requirements")]
        public string HouseholdRequirements { get; set; }

        [Display(Name = "Compatible with other animals")]
        public string CompatibleWithOtherAnimals { get; set; }

        [Display(Name = "Compatible with children")]
        public string CompatibleWithChildren { get; set; }

        [Display(Name = "Tag 1")]
        public string Tag1 { get; set; }
        [Display(Name = "Tag 2")]
        public string Tag2 { get; set; }
        [Display(Name = "Tag 3")]
        public string Tag3 { get; set; }
        [Display(Name = "Tag 4")]
        public string Tag4 { get; set; }
        [Display(Name = "Tag 5")]
        public string Tag5 { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //IRepository<Animal> animalRP = new AnimalRepository();

            //var userManager = animalRP.CreateUserStore();

            //if (RehomerEmail != null)
            //{
            //    var user = userManager.FindByEmail(RehomerEmail);

            //    if (user != null)
            //    {
            //        Rehomer = user;
            //    }
            //}

            if (MedicalHistory == null)
            {
                MedicalHistory = "The medical history of " + Name + " is currently unknown";
            }

            if (DietaryNeeds == null)
            {
                DietaryNeeds = Name + " has no specified dietary needs";
            }

            if (BackgroundInfo == null)
            {
                BackgroundInfo = "We have no information on the background of " + Name;
            }

            if (HouseholdRequirements == null)
            {
                HouseholdRequirements = "We were not provided information on the household requirements of " + Name;
            }

            DateTime d;
            if (!DateTime.TryParse(DateOfBirthString, out d))
            {
                yield return new ValidationResult("Date format could not be parsed");
            }
            else
            {
                DateOfBirthDT = d;
            }


            if (Tag1 == Tag2 || Tag1 == Tag3 || Tag1 == Tag4 || Tag1 == Tag5)
            {
                yield return new ValidationResult("Two or more of the tags you have chosen are the same, please choose 5 different tags");
            }

            if (Tag2 == Tag1 || Tag2 == Tag3 || Tag2 == Tag4 || Tag2 == Tag5)
            {
                yield return new ValidationResult("Two or more of the tags you have chosen are the same, please choose 5 different tags");
            }

            if (Tag3 != null)
            {
                if (Tag3 == Tag1 || Tag3 == Tag2 || Tag3 == Tag4 || Tag3 == Tag5)
                {
                    yield return new ValidationResult("Two or more of the tags you have chosen are the same, please choose 5 different tags");
                }
            }

            if (Tag4 != null)
            {
                if (Tag4 == Tag1 || Tag4 == Tag2 || Tag4 == Tag3 || Tag4 == Tag5)
                {
                    yield return new ValidationResult("Two or more of the tags you have chosen are the same, please choose 5 different tags");
                }
            }

            if (Tag5 != null)
            {
                if (Tag5 == Tag1 || Tag5 == Tag2 || Tag5 == Tag3 || Tag5 == Tag4)
                {
                    yield return new ValidationResult("Two or more of the tags you have chosen are the same, please choose 5 different tags");
                }
            }

            //animalRP.Dispose();
        }

        public class SearchViewModel : IValidatableObject
        {


            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                throw new NotImplementedException();
            }
        }
    }
}