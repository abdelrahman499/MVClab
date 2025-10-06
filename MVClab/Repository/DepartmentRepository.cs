using MVClab.Context;
using MVClab.Models;

namespace MVClab.Repository
{
    public class DepartmentRepository
    {
        CompanyContext db;
        public void Add(Department department)
        {
            db.Add(department);
        }
        public void Update(Department department)
        {
            db.Update(department);
        }
        public void Delete(int id)
        {
            Department dept = GetByID(id); 
            db.Remove(dept);
        }
        public List<Department> Get()
        {
            return db.Departments.ToList();
        }
        public Department GetByID(int id)
        {
            return db.Departments.FirstOrDefault(d => d.DepartmentId == id);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
