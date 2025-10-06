using MVClab.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVClab.ViewModels
{
    public class StudentViewModel
    {
        public int SSN { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        
        public int deptId { get; set; }
       
        
    }
}
