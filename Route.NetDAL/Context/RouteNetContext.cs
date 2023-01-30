using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Route.NetDAL.Entities;

namespace Route.NetDAL.Context
{
    public class RouteNetContext : IdentityDbContext<ApplicationUser>
    {
        public RouteNetContext(DbContextOptions<RouteNetContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
