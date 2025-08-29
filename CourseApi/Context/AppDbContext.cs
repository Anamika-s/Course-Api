using CourseApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CourseApi.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Models.UserViewModel> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) {

            //try
            //{
            //    var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            //    if (databaseCreator != null)
            //    {
            //        // Create the database if it doesn't exist
            //        if (!databaseCreator.CanConnect())
            //        {
            //            databaseCreator.Create();
            //        }

            //        // Create tables if they don't exist
            //        if (!databaseCreator.HasTables())
            //        {
            //            databaseCreator.CreateTables();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Database creation failed: {ex.Message}");
            //}

        }
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

            modelBuilder.Entity<UserViewModel>().HasData(
                new UserViewModel() { UserId = 1, UserName = "user1", Password = "admin", RoleId = 1 },
                new UserViewModel() { UserId = 2, UserName = "user2", Password = "manager", RoleId = 2 },
                new UserViewModel() { UserId = 3, UserName = "user3", Password = "user", RoleId = 3 }
               );










        }

    }
}
