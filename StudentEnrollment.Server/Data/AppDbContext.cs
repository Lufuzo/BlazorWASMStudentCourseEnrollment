using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Shared.Models;

namespace StudentEnrollment.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<Enrollment>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(sc => sc.CourseId);


            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, CourseName = "Systems Software", CourseCode = "SS101" },
                new Course { CourseId = 2, CourseName = "Technical Programming", CourseCode = "TP101" },
                new Course { CourseId = 3, CourseName = "Development Software", CourseCode = "DS101" },
                new Course { CourseId = 4, CourseName = "Information Systems", CourseCode = "IMS101" }
            );

        }
    }
}
