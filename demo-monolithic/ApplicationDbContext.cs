using demo_monolithic.Models;
using Microsoft.EntityFrameworkCore;

namespace demo_monolithic
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
                
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
