using Route.NetBLL.Interfaces;

namespace Route.NetBLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IEmployeeRepository _employeeRepository, IDepartmentRepository _departmentRepository)
        {
            EmployeeRepository = _employeeRepository;
            DepartmentRepository = _departmentRepository;
        }

        public IEmployeeRepository EmployeeRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }
    }
}
