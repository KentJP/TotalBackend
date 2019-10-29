using Microsoft.EntityFrameworkCore;
using TotalBackend.Core.Entity;

namespace TotalBackend.infrastructure.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public DbSet<Incident> Incident { get; set; }
    }
}
