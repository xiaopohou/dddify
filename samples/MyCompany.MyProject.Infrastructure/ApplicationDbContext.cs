using Dddify.EntityFrameworkCore;
using Dddify.Security.Identity;
using Dddify.Timing;
using Microsoft.EntityFrameworkCore;
using MyCompany.MyProject.Domain.Entities;
using MediatR;

namespace MyCompany.MyProject.Infrastructure
{
    public class ApplicationDbContext : DddifyDbContext
    {
        public ApplicationDbContext(DbContextOptions options, IDbContextDependencies dependencies)
            : base(options, dependencies)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Todo> Todos { get; set; }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
