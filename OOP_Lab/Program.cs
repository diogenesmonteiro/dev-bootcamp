using System;
using System.Collections.Generic;

namespace student_enrolment
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var students = new DataImporter().Import<Student>("students.csv");
            var courses = new DataImporter().Import<Course>("courses.csv");
            var subjects = new DataImporter().Import<Subject>("subjects.csv");
            var courseSubjects = new DataImporter().Import<CourseSubject>("coursesubjects.csv");
            var courseMemberships = new DataImporter().Import<CourseMembership>("coursememberships.csv");

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
                                  "\n ------------------------------------\n");

                Console.WriteLine("Type your option or press ENTER to exit:");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        StudentsList(students);
                        break;
                    case "2":
                        StudentAdd(students);
                        break;
                    case "3":
                        StudentDelete(students);
                        break;
                    case "4":
                        CourseList(courses);
                        break;
                    case "5":
                        CourseAdd(courses);
                        break;
                    case "6":
                        CourseDelete(courses);
                        break;
                    case "7":
                        SubjectList(subjects);
                        break;
                    case "8":
                        SubjectAdd(subjects, courseSubjects);
                        break;
                    case "9":
                        SubjectDelete(subjects, courseSubjects);
                        break;
                    case "10":
                        StudentEnrolment(students, courses, courseMemberships);
                        break;
                    case "11":
                        StudentCancelEnrolment(students, courses, courseMemberships);
                        break;
                    case "12":
                        StudentCourse(students, courseMemberships, courses);
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            } while (true);

            static void StudentsList(List<Student> students)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nID\tName");
                Console.ResetColor();
                foreach (var student in students)
                {
                    Console.WriteLine("{0}\t{1} {2}", student.Id, student.FirstName, student.LastName);
                }
            }

            // Students
            static void StudentAdd(List<Student> students)
            {
                var studentId = Convert.ToString(students.Count + 1);
                Console.WriteLine("Student first name: ");
                var studentFirstName = Console.ReadLine();
                Console.WriteLine("Student last name: ");
                var studentLastName = Console.ReadLine();

                students.Add(new Student(studentId, studentFirstName, studentLastName));

                DataExporter.Export(students, "students.csv");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Student added with ID {0}", studentId);
                Console.ResetColor();
            }

            static void StudentDelete(List<Student> students)
            {
                Console.WriteLine("Student ID to delete: ");
                var studentId = Console.ReadLine();

                students.Remove(students.Find(x => x.Id == studentId));

                DataExporter.Export(students, "students.csv");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Student with ID {0} has been removed", studentId);
                Console.ResetColor();
            }

            // Courses

            static void CourseList(List<Course> courses)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nID\tName - Description");
                Console.ResetColor();

                foreach (var course in courses)
                {
                    Console.WriteLine("{0}\t{1} - {2}", course.Id, course.Name, course.Description);
                }
            }

            static void CourseAdd(List<Course> courses)
            {
                var courseId = Convert.ToString(courses.Count + 1);
                Console.WriteLine("Course name: ");
                var courseName = Console.ReadLine();
                Console.WriteLine("Course description: ");
                var courseDescription = Console.ReadLine();
                Console.WriteLine("Is the course part funded (true/false): ");
                var courseIsPartFunded = Console.ReadLine();

                courses.Add(new Course(courseId, courseName, courseDescription, courseIsPartFunded));

                DataExporter.Export(courses, "courses.csv");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Course added with ID {0}", courseId);
                Console.ResetColor();
            }

            static void CourseDelete(List<Course> courses)
            {
                Console.WriteLine("Course ID to delete: ");
                var courseId = Console.ReadLine();

                courses.Remove(courses.Find(x => x.Id == courseId));

                DataExporter.Export(courses, "courses.csv");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Course with ID {0} has been removed", courseId);
                Console.ResetColor();
            }

            // Subjects

            static void SubjectList(List<Subject> subjects)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nID\tName - Description");
                Console.ResetColor();

                foreach (var subject in subjects)
                {
                    Console.WriteLine("{0}\t{1} - {2}", subject.Id, subject.Name, subject.Description);
                }
            }

            static void SubjectAdd(List<Subject> subjects, List<CourseSubject> courseSubjects)
            {
                var subjectId = Convert.ToString(subjects.Count + 1);
                var courseSubjectId = Convert.ToString(courseSubjects.Count + 1);
                Console.WriteLine("Subject name: ");
                var subjectName = Console.ReadLine();
                Console.WriteLine("Subject description: ");
                var subjectDescription = Console.ReadLine();
                Console.WriteLine("Course ID which the subject belongs to: ");
                var courseId = Console.ReadLine();

                courseSubjects.Add(new CourseSubject(courseSubjectId, courseId, subjectId));
                subjects.Add(new Subject(subjectId, subjectName, subjectDescription));

                DataExporter.Export(courseSubjects, "coursesubjects.csv");
                DataExporter.Export(subjects, "subjects.csv");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Subject added with ID {0}", subjectId);
                Console.ResetColor();
            }

            static void SubjectDelete(List<Subject> subjects, List<CourseSubject> courseSubjects)
            {
                Console.WriteLine("Subject ID to delete: ");
                var subjectId = Console.ReadLine();

                courseSubjects.Remove(courseSubjects.Find(x => x.SubjectId == subjectId));
                subjects.Remove(subjects.Find(x => x.Id == subjectId));

                DataExporter.Export(courseSubjects, "coursesubjects.csv");
                DataExporter.Export(subjects, "subjects.csv");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Subject with ID {0} has been removed", subjectId);
                Console.ResetColor();
            }

            // Course membership

            static void StudentEnrolment(List<Student> students, List<Course> courses, List< CourseMembership> courseMemberships)
            {
                Console.WriteLine("Student ID: ");
                var studentId = Console.ReadLine();
                Console.WriteLine("Course ID: ");
                var courseId = Console.ReadLine();
                var courseMembershipId = Convert.ToString(courseMemberships.Count + 1);

                courseMemberships.Add(new CourseMembership(courseMembershipId, studentId, courseId));

                DataExporter.Export(courseMemberships, "coursememberships.csv");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Student ID {0} is now enrolled in course ID {1}", studentId, courseId);
                Console.ResetColor();
            }
            static void StudentCancelEnrolment(List<Student> students, List<Course> courses, List<CourseMembership> courseMemberships)
            {
                Console.WriteLine("Student ID: ");
                var studentId = Console.ReadLine();
                var student = students.Find(x => x.Id == studentId);
                var cmCourse = courseMemberships.Find(x => x.StudentId == student.Id);

                courseMemberships.Remove(courseMemberships.Find(x => x.StudentId == studentId));

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Student ID {0} enrolment in course ID {1} is cancelled."
                    , student.Id, cmCourse.CourseId);
                Console.ResetColor();
            }

            static void StudentCourse(List<Student> students, List<CourseMembership> courseMemberships, List<Course> courses)
            {
                Console.WriteLine("Student ID: ");
                var studentId = Console.ReadLine();
                var student = students.Find(x => x.Id == studentId);
                var cmCourse = courseMemberships.Find(x => x.StudentId == student.Id);
                var course = courses.Find(x => x.Id == cmCourse.CourseId);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Student ID {0} named {1} {2} is enrolled in {3}."
                    , student.Id, student.FirstName, student.LastName, course.Name);
                Console.ResetColor();
            }
        }
    }
}
