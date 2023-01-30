using System.ComponentModel.DataAnnotations;

namespace Route.NetPL.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [MinLength(5, ErrorMessage = "minimum length is 5")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [MinLength(5, ErrorMessage = "minimum length is 5")]
        [Compare(nameof(Password), ErrorMessage = "Password mismatch")]

        public string ConfirmPassword { get; set; }
        [Required]
        public bool IsAgree { get; set; }

    }
}
