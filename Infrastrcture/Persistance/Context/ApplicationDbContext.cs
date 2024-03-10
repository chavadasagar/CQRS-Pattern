using Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Infrastrcture.Persistance.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        public DbSet<Todo> Todo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
