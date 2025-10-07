using MVClab.Context;
using MVClab.Models;

namespace MVClab.Repository
{
    public class StudentRepository : IStudentRepository
    {
        CompanyContext db;
        public StudentRepository(CompanyContext _db)
        {
            db = _db;
        }
        public void Add(Student student)
        {
            db.Add(student);
        }
        public void Update(Student student)
        {
            db.Update(student);
        }
        public void Delete(int id)
        {
            Student stud = GetByID(id);
            db.Remove(stud);
        }
        public List<Student> Get()
        {
            return db.Students.ToList();
        }
        public Student GetByID(int id)
        {
            return db.Students.FirstOrDefault(d => d.SSN == id);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
