using System.ComponentModel.DataAnnotations;

namespace StudentEnrolmentWebApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Student first name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Student last name is required.")]
        public string LastName { get; set; }   
    }
}
