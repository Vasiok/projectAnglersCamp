using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                AnglersCampEntities db = new AnglersCampEntities();
                string userEmail = value.ToString();
                int count = db.Members.Where(m => m.MemberEmail == userEmail).ToList().Count();
                if (count != 0)
                {
                    return new ValidationResult("A user with this email allready exists");
                }
                else
                {
                    return ValidationResult.Success;
                }

            }
            else
	        {
                return new ValidationResult("These field is required"); 
	        }
        }        

    }

    public class UniquesUserAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                AnglersCampEntities db = new AnglersCampEntities();
                string userName = value.ToString();
                int count = db.Members.Where(m => m.MemberName == userName).ToList().Count();
                if (count != 0)
                {
                    return new ValidationResult("A user with this name allready exists");
                }
                else
                {
                    return ValidationResult.Success;
                }

            }
            else
            {
                return new ValidationResult("These field is required");
            }
        }
    }




    public class MemberValidation
    {
        [Required]
        [UniquesUser]
        [Display(Name = "User Name")]
        public string MemberName { get; set; }

        [Required]
        [EmailAddress]
        [UniqueEmail]
        [Display(Name = "Email")]
        public string MemberEmail { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string MemberPassword { get; set; }


        [DataType(DataType.Password)]
        [Required]
        [Compare("MemberPassword")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Picture")]
        public string MemberPicture { get; set; }

        [Display(Name = "Club(s)")]
        public string MemberClub { get; set; }
    }



    [MetadataType(typeof(MemberValidation))]
    public partial class Member
    {
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
       
    }
}
