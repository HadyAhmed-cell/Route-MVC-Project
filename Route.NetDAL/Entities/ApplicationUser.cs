using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Route.NetDAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public bool IsAgree { get; set; }
    }
}
