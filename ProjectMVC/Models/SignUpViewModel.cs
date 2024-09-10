using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="First Name Is Requiesd")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Is Requiesd")]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage ="Email Is Not Valid")]
        [Required(ErrorMessage = "Email Name Is Requiesd")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password Is Requierd")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?=(?:.*(.))(?!\1).{5,}).{6,}$",
         ErrorMessage = "Password must have at least 6 characters, including at least one digit, one lowercase letter, one uppercase letter, one non-alphanumeric character, and at least 2 unique characters.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password Is Requierd")]
        [Compare(nameof(Password),ErrorMessage ="Confirm Password Not Match Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage ="Is Agree Is Requierd")]
        public bool IsAgree { get; set; } 
    }
}
