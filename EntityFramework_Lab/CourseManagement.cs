using System;
using System.Data.Entity;

namespace StudentEnrolment
{
    internal static class CourseManagement
    {
        public static void ListAllCourses(DbSet<Course> courses)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nID\tPartly Funded\tName");
            Console.ResetColor();

            foreach (var course in courses)
            {
                Console.WriteLine("{0}\t{1}\t\t{2}", course.Id, course.IsPartFunded, course.Name);
            }
        }

        public static void AddCourse(DbSet<Course> courses)
        {
            var course = new Course();
            Console.WriteLine("Course name: ");
            course.Name = Console.ReadLine();
            Console.WriteLine("Course description: ");
            course.Description = Console.ReadLine();
            Console.WriteLine("Is the course part funded (true/false): ");
            course.IsPartFunded = Convert.ToBoolean(Console.ReadLine());

            courses.Add(course);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Course added.");
            Console.ResetColor();
        }

        public static void DeleteCourse(DbSet<Course> courses)
        {
            Console.WriteLine("Course ID to delete: ");
            var courseId = Convert.ToInt32(Console.ReadLine());
            var course = courses.Find(courseId);

            courses.Remove(course);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Course with ID {0} has been removed", courseId);
            Console.ResetColor();
        }
    }
}
