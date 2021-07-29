using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyingMvcCore.Business.Models;

namespace StudyingMvcCore.Data.Mappgins
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .ToTable("Customers");

            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder
                .Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder
                .HasMany(c => c.ToDos)
                .WithOne(t => t.Customer)
                .HasForeignKey(t => t.CustomerId);

            builder
                .HasOne(c => c.Address)
                .WithOne(a => a.Customer);
        }
    }
}
