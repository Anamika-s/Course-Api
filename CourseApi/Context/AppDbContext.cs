using CourseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseApi.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}

        // to provide some initial data
        // seed data
        // Fluent Api > OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>
                ().HasData(
                new Role() { RoleId = 1, RoleName = "Admin" },
                new Role() { RoleId = 2, RoleName = "Manager" },
                new Role() { RoleId = 3, RoleName = "User" }
                );

            modelBuilder.Entity<User>().HasData(
                new User() { UserId = 1, UserName = "user1", Password = "admin", RoleId = 1 },
                new User() { UserId = 2, UserName = "user2", Password = "manager", RoleId = 2 },
                new User() { UserId = 3, UserName = "user3", Password = "user", RoleId = 3 }
               );










        }

    }
}
