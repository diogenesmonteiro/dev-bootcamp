using System;
using System.Data.Entity;
using System.Linq;

namespace StudentEnrolment
{
    internal static class MembershipManagement
    {
        public static void EnrollStudent(DbSet<Student> students, DbSet<CourseMembership> courseMemberships)
        {
            var courseMembership = new CourseMembership();
            Console.WriteLine("Student ID: ");
            courseMembership.StudentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Course ID: ");
            courseMembership.CourseId = Convert.ToInt32(Console.ReadLine());

            courseMemberships.Add(courseMembership);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Student is now enrolled in the designated course");
            Console.ResetColor();
        }

        public static void CancelStudentEnrolment(DbSet<Student> students, DbSet<CourseMembership> courseMemberships)
        {
            Console.WriteLine("Student ID: ");
            var studentId = Convert.ToInt32(Console.ReadLine());
            var student = students.Include(c => c.CourseMemberships).Single(s => s.Id == studentId);

            courseMemberships.RemoveRange(student.CourseMemberships);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Student enrolment is cancelled.");
            Console.ResetColor();
        }
        public static void StudentCourseEnrolled(DbSet<Student> students, DbSet<CourseMembership> courseMemberships)
        {
            Console.WriteLine("Student ID: ");
            var studentId = Convert.ToInt32(Console.ReadLine());
            var student = students.Include(c => c.CourseMemberships).Single(s => s.Id == studentId);
            var course = courseMemberships.Find(studentId).Course;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Student ID {0} named {1} {2} is enrolled in course ID {3} - {4}."
                , student.Id, student.FirstName, student.LastName, course.Id, course.Name);
            Console.ResetColor();
        }
    }
}
