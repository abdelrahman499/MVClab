using MVClab.Models;
using MVClab.ViewModels;
using AutoMapper;
namespace MVClab.Mappings
{
    public class StudentMapping :Profile
    {
        public StudentMapping()
        {
            CreateMap<Student, StudentViewModel>();
            CreateMap<StudentViewModel, Student>();
        }
    }
}
