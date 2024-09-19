using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class ForgetPasswordViewModel
    {
        [EmailAddress(ErrorMessage = "Email Is Not Valid")]
        [Required(ErrorMessage = "Email  Is Requiesd")]
        public string Email { get; set; }
    }
}
