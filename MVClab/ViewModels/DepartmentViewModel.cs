namespace MVClab.ViewModels
{
    public class DepartmentViewModel
    {
        public string DepartmentName { get; set; }
        public string Manager { get; set; }
        public int StudentCount { get; set; }
        public int InstructorCount { get; set; }
        public List<string> InstructorNames { get; set; }
        public List<string> StudentNames { get; set; }
        public string CustomMessage { get; set; }
    }
}
