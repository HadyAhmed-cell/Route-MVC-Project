using Route.NetBLL.Interfaces;
using Route.NetDAL.Context;
using Route.NetDAL.Entities;

namespace Route.NetBLL.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly RouteNetContext _context;

        public DepartmentRepository(RouteNetContext context) : base(context)
        {
            _context = context;
        }


    }
}
