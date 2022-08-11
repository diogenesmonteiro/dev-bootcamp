using System.ComponentModel.DataAnnotations;

namespace StudentEnrolmentWebApp.Models
{
    public class CourseMembership
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Student ID is required.")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Course ID is required.")]
        public int CourseId { get; set; }
    }
}
