using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrolment
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var dbContext = new StudentEnrolmentDbContext();

            DbBootStrap.DbCheck(dbContext);

            var students = dbContext.Students;
            var courses = dbContext.Courses;
            var subjects = dbContext.Subjects;
            var courseSubjects = dbContext.CourseSubjects;
            var courseMemberships = dbContext.CourseMemberships;

            do
            {
                Console.WriteLine("\n=====================================" +
                                  "\n   Student's Enrolment Management" +
                                  "\n=====================================" +
                                  "\nStudents" +
                                  "\n  1) List     2) Add      3) Delete" +
                                  "\n ------------------------------------" +
                                  "\nCourses" +
                                  "\n  4) List     5) Add      6) Delete" +
                                  "\n ------------------------------------" +
                                  "\nSubjects" +
                                  "\n  7) List     8) Add      9) Delete" +
                                  "\n ------------------------------------" +
                                  "\n 10) Enroll student in a course" +
                                  "\n 11) Cancel student enrolment" +
                                  "\n 12) Student's enrolment course check" +
                                  "\n ------------------------------------" +
                                  "\n  0) Exit application" +
                                  "\n ------------------------------------\n");

                Console.WriteLine("Type your option or press ENTER to exit:");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        StudentsManagement.ListAllStudents(students);
                        break;
                    case "2":
                        StudentsManagement.AddStudent(students);
                        break;
                    case "3":
                        StudentsManagement.DeleteStudent(students);
                        break;
                    case "4":
                        CourseManagement.ListAllCourses(courses);
                        break;
                    case "5":
                        CourseManagement.AddCourse(courses);
                        break;
                    case "6":
                        CourseManagement.DeleteCourse(courses);
                        break;
                    case "7":
                        SubjectManagement.ListAllSubjects(subjects);
                        break;
                    case "8":
                        SubjectManagement.AddSubject(subjects, courseSubjects);
                        break;
                    case "9":
                        SubjectManagement.DeleteSubject(subjects, courseSubjects);
                        break;
                    case "10":
                        MembershipManagement.EnrollStudent(students, courseMemberships);
                        break;
                    case "11":
                        MembershipManagement.CancelStudentEnrolment(students, courseMemberships);
                        break;
                    case "12":
                        MembershipManagement.StudentCourseEnrolled(students, courseMemberships);
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        continue;
                }
                dbContext.SaveChanges();
            } while (true);
        }
    }
}
