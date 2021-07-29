using Microsoft.EntityFrameworkCore;
using StudyingMvcCore.Business.Models;
using System.Linq;

namespace StudyingMvcCore.Data.Context
{
    public class StudyingMvcCoreDbContext : DbContext
    {
        public StudyingMvcCoreDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudyingMvcCoreDbContext).Assembly);

            //disable delete cascade
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
