namespace MVClab.Models
{
    public class StudentCourse
    {
        
        public int SSN { get; set; }
        public Student Student { get; set; }
        public int Number {  get; set; }
        public Course Course { get; set; }
        public string Grade { get; set; }


    }
}
