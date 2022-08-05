using System;
using System.Data.Entity;
using System.Linq;

namespace StudentEnrolment
{
    internal static class SubjectManagement
    {
        public static void ListAllSubjects(DbSet<Subject> subjects)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nID\tName");
            Console.ResetColor();

            foreach (var subject in subjects)
            {
                Console.WriteLine("{0}\t{1}", subject.Id, subject.Name);
            }
        }

        public static void AddSubject(DbSet<Subject> subjects, DbSet<CourseSubject> courseSubjects)
        {
            var subject = new Subject();
            var courseSubject = new CourseSubject();
            Console.WriteLine("Subject name: ");
            subject.Name = Console.ReadLine();
            Console.WriteLine("Subject description: ");
            subject.Description = Console.ReadLine();
            Console.WriteLine("Course ID which the subject belongs to: ");
            courseSubject.CourseId = Convert.ToInt16(Console.ReadLine());

            subjects.Add(subject);
            courseSubjects.Add(courseSubject);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Subject added.");
            Console.ResetColor();
        }

        public static void DeleteSubject(DbSet<Subject> subjects, DbSet<CourseSubject> courseSubjects)
        {
            Console.WriteLine("Subject ID to delete: ");
            var subjectId = Convert.ToInt32(Console.ReadLine());
            var subject = subjects.Include(c => c.CourseSubjects).Single(s => s.Id == subjectId);

            courseSubjects.RemoveRange(subject.CourseSubjects);
            subjects.Remove(subject);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Subject has been removed");
            Console.ResetColor();
        }
    }
}
