using Microsoft.EntityFrameworkCore;
using StudentEnrolmentWebApp.Models;

namespace StudentEnrolmentWebApp.Data
{
    public class ApiStudentEnrolmentDbContext : DbContext
    {
        public ApiStudentEnrolmentDbContext(DbContextOptions<ApiStudentEnrolmentDbContext>options)
            :base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<CourseSubject> CourseSubjects { get; set; }
        public DbSet<CourseMembership> CourseMemberships { get; set; }
    }
}
