namespace MVClab.Models
{
    public class CourseInstructor
    {
        public int Number { get; set; }
        public Course Course { get; set; }
        public int SSN {  get; set; }
        public Instructor Instructor { get; set; }
        public int  Hours { get; set; }
    }
}
