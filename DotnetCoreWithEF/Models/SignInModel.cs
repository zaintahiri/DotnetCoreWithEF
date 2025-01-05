using System.ComponentModel.DataAnnotations;

namespace DotnetCoreWithEF.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage ="Please enter email address"),EmailAddress(ErrorMessage ="Enter valid email address")]
        [Display(Name ="Username")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Please enter password")]
        [DataType(DataType.Password)]
        [Display(Name ="Please enter password")]
        public string Password { get; set; }
        
        public bool RememberMe { get; set; }
    }
}
