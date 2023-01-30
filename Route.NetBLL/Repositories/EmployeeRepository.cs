using Microsoft.EntityFrameworkCore;
using Route.NetBLL.Interfaces;
using Route.NetDAL.Context;
using Route.NetDAL.Entities;

namespace Route.NetBLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly RouteNetContext _context;

        public EmployeeRepository(RouteNetContext context) : base(context)
        {
            _context = context;
        }

        public Task<IEnumerable<Employee>> GetEmplyeesByDepartmentName(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> Search(string Name)
        => await _context.Employees.Where(e => e.Name.Contains(Name)).ToListAsync();
    }
}
