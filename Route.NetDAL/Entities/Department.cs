using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Route.NetDAL.Entities
{
    public class Department
    {

        public int Id { get; set; }
        [DisplayName("Department Code")]
        public string Code { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Department Name")]
        public string Name { get; set; }

        [DataType(DataType.Date)]

        public DateTime DateOfCreation { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
