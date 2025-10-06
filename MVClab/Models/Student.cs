using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVClab.Models
{
    public class Student
    {
        [Key]
        public int SSN { get; set; }
        public string Name {  get; set; }
        public int Age { get; set; }
        public string Address {  get; set; }
        public string Image { get; set; }
        [ForeignKey(nameof(deptId))]
        public int  deptId { get; set; }
        public Department Department { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
