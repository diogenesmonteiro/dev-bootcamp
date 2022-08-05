using System;
using System.Data.Entity;

namespace StudentEnrolment
{
    internal static class StudentsManagement
    {
        public static void ListAllStudents(DbSet<Student> students)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nID\tName");
            Console.ResetColor();

            foreach (var student in students)
            {
                Console.WriteLine("{0}\t{1} {2}", student.Id, student.FirstName, student.LastName);
            }
        }

        public static void AddStudent(DbSet<Student> students)
        {
            var student = new Student();
            Console.WriteLine("Student first name: ");
            student.FirstName = Console.ReadLine();
            Console.WriteLine("Student last name: ");
            student.LastName = Console.ReadLine();

            students.Add(student);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Student added.");
            Console.ResetColor();
        }

        public static void DeleteStudent(DbSet<Student> students)
        {
            Console.WriteLine("Student ID to delete: ");
            var studentId = Convert.ToInt32(Console.ReadLine());
            var student = students.Find(studentId);

            students.Remove(student);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Student with ID {0} has been removed", studentId);
            Console.ResetColor();
        }
    }
}