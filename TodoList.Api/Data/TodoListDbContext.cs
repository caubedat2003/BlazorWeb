using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoList.Api.Entities;
using Task = TodoList.Api.Entities.Task;

namespace TodoList.Api.Data
{
    public class TodoListDbContext : IdentityDbContext<User, Role, Guid>
    {
        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options) {
        
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Patient> Patients { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Call the base method to ensure any default configurations are applied
            builder.Entity<User>() // Configure the UserRole property of the User entity
                .Property(x => x.UserRole)
                .HasConversion<int>(); //configures a value converter for the UserRole property
        }
    }
}
