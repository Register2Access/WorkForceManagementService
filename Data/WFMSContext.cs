using Microsoft.EntityFrameworkCore;
using WorkForceManagementService.Entities;

namespace WorkForceManagementService.Data
{
    public partial class WFMSContext : DbContext
    {
        public WFMSContext(DbContextOptions<WFMSContext> options) : base(options)
        {
            
        }

        //public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<User> Users { get; set; } = null!;
    }
}
