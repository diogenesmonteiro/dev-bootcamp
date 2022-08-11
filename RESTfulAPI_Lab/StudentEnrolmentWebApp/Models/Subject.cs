using System.ComponentModel.DataAnnotations;

namespace StudentEnrolmentWebApp.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Subject name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Subject description is required.")]
        public string Description { get; set; }
    }
}
