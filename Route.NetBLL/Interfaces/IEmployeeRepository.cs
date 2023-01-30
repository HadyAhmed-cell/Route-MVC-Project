using Route.NetDAL.Entities;

namespace Route.NetBLL.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetEmplyeesByDepartmentName(string Name);

        Task<IEnumerable<Employee>> Search(string Name);
    }
}
