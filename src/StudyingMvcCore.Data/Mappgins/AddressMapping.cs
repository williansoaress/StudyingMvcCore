using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyingMvcCore.Business.Models;

namespace StudyingMvcCore.Data.Mappgins
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .ToTable("Addresses");

            builder
                .HasKey(a => a.Id);

            builder
                .Property(c => c.Country)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder
                .Property(c => c.State)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder
                .Property(c => c.City)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder
                .Property(c => c.PostalCode)
                .IsRequired()
                .HasColumnType("varchar(100)");
            
            builder
                .Property(c => c.Street)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder
                .Property(c => c.Number)
                .IsRequired()
                .HasColumnType("varchar(100)");
        }
    }
}
