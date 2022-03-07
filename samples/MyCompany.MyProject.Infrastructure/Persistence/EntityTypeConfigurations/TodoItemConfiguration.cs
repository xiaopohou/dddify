using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCompany.MyProject.Domain.Entities;

namespace MyCompany.MyProject.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.Property(t => t.Id)
              .ValueGeneratedNever();

            builder.Property(t => t.Title)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(t => t.Note)
              .HasMaxLength(500)
              .IsRequired();
        }
    }
}
