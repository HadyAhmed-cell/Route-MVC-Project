using System.ComponentModel.DataAnnotations;

namespace Route.NetPL.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Password is Required")]
        [MinLength(5, ErrorMessage = "minimum length is 5")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [MinLength(5, ErrorMessage = "minimum length is 5")]
        [Compare(nameof(Password), ErrorMessage = "Password mismatch")]

        public string ConfirmPassword { get; set; }

        public string Email { get; set; }


        public string Token { get; set; }
    }
}
