using CourseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseApi.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}

    }
}
