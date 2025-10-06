using System.ComponentModel.DataAnnotations;

namespace MVClab.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string deptName { get; set; }
        public string Manager    { get; set; }
        [Required]
        [RegularExpression("^(EG|USA)$", ErrorMessage = "Location must be either 'EG' or 'USA'.")]
        public string Location { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();


    }
}
