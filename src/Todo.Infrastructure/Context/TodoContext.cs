using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;
using TodoApp.Infrastructure.Context.Configuration;

namespace TodoApp.Infrastructure.Context
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoConfiguration());
        }
    }
}
