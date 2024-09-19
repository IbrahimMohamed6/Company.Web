using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Web.Models
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage = "Email Is Not Valid")]
        [Required(ErrorMessage = "Email Name Is Requiesd")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Is Requierd")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
