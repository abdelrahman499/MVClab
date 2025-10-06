using System.ComponentModel.DataAnnotations;

namespace MVClab.Models
{
    public class Course
    {
        [Key]
        public int Number { get; set; }
        [Required]
        public string crsName { get; set; }
        [Required]
        public string Topic { get; set; }
        [Range(10,100)]
        public int Degree { get; set; }
        [Range(0,100)]
        public int MinDegree { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
        public ICollection<CourseInstructor> CourseInstructors { get; set; } = new List<CourseInstructor>();

    }
}
