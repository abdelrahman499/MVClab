using MVClab.Models;

namespace MVClab.Repository
{
    public interface IStudentRepository
    {
        public void Add(Student student);

        public void Update(Student student);

        public void Delete(int id);

        public List<Student> Get();

        public Student GetByID(int id);

        public void Save();
    }
        
}
