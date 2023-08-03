using Microsoft.EntityFrameworkCore;

namespace WebApp_Day2.Models
{
    public class ITIContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ST_ITI;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}
