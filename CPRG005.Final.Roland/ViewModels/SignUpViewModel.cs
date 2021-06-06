using System.ComponentModel.DataAnnotations;

namespace CPRG005.Final.Roland.ViewModels
{
    public class SignUpViewModel
    {
        [Display(Name = "Username")]
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "You must confirm your password.")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Characters must be alphanumeric.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Characters must be alphanumeric.")]
        public string LastName { get; set; }

        [Phone]
        public string Phone { get; set; }

        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Characters must be alphanumeric.")]
        public string City { get; set; }
    }
}
