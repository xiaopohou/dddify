using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCompany.MyProject.Domain.Entities;

namespace MyCompany.MyProject.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.Property(t => t.Id)
              .ValueGeneratedNever();

            builder.Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.OwnsOne(t => t.Colour)
                .Property(c => c.Code)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
