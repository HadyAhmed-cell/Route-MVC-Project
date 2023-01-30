using System.ComponentModel.DataAnnotations;

namespace Route.NetDAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        public string ImgName { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department department { get; set; }
    }
}
