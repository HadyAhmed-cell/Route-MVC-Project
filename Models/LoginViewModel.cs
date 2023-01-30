using System.ComponentModel.DataAnnotations;

namespace Route.NetPL.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [MinLength(5, ErrorMessage = "minimum length is 5")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

}
