using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Route.NetPL.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Department Name")]

        public string Name { get; set; }
    }
}