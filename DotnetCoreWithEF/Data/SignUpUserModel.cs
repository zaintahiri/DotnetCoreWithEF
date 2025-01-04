using System.ComponentModel.DataAnnotations;

namespace DotnetCoreWithEF.Data
{
    public class SignUpUserModel
    {
        [Display(Name ="Email Address")]
        [Required(ErrorMessage ="Please enter Email Address")]
        [EmailAddress(ErrorMessage ="Please enter valid email address")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter strong password")]
        [Compare("ConfirmPasswrod",ErrorMessage ="Password does not match")]
        [DataType(dataType:DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please enter confirm password")]
        [DataType(dataType: DataType.Password)]
        public string ConfirmPasswrod { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter FirstName")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter LastName")]
        public string LastName { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }
    }
}
