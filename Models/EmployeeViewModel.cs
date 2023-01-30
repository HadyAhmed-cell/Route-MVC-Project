using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Route.NetPL.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        [MaxLength(50, ErrorMessage = "Maximum Length is 50 Chars")]
        [MinLength(6, ErrorMessage = "Minimum Length is 6 Chars")]
        public string Name { get; set; }
        [Range(18, 60, ErrorMessage = "Age Must Be Between 18 and 60")]
        [ValidateNever]
        public int Age { get; set; }

        public string Address { get; set; }
        [DataType(DataType.Currency)]
        [Range(4000, 8000, ErrorMessage = "Salary Must be between 4000 and 8000")]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; }
        [EmailAddress]

        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [ValidateNever]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        [DataType(DataType.Date)]

        public DateTime CreationDate { get; set; }

        public IFormFile? Image { get; set; }

        public string? ImgName { get; set; }

        public int DepartmentId { get; set; }

        public DepartmentViewModel? department { get; set; }
    }
}
