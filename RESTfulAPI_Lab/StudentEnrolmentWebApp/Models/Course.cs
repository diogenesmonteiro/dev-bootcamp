using System.ComponentModel.DataAnnotations;

namespace StudentEnrolmentWebApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Course name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Course description is required.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Course funding information is required.")]
        public bool IsPartFunded { get; set; }
    }
}
