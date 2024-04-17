using EmployeeCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace EmployeeCRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }
        public DbSet<Employee> employees {  get; set; } 

    }
}
