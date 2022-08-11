using System.ComponentModel.DataAnnotations;

namespace StudentEnrolmentWebApp.Models
{
    public class CourseSubject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Course ID is required.")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Subject ID is required.")]
        public int SubjectId { get; set; }
    }
}
