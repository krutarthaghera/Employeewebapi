using EmpAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        //public DbSet<Country> Countries { get; set; }

        public DbSet<Department> Departments { get; set; }

        //public DbSet<User> User { get; set; }

    }
}