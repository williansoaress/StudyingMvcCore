using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyingMvcCore.Business.Models;

namespace StudyingMvcCore.Data.Mappgins
{
    public class ToDoMapping : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder
                .ToTable("ToDos");

            builder
                .HasKey(t => t.Id);

            builder
                .Property(c => c.Description)
                .IsRequired()
                .HasColumnType("varchar(200)");
        }
    }
}
