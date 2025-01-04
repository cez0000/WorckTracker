using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkTracker.Models;

namespace WorkTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WorkTracker.Models.ActivityType> ActivityType { get; set; } = default!;
        public DbSet<WorkTracker.Models.Activity> Activity { get; set; } = default!;
    }
}
