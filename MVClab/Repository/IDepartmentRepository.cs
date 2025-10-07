using MVClab.Models;

namespace MVClab.Repository
{
    public interface IDepartmentRepository
    {
        public void Add(Department department);


        public void Update(Department department);


        public void Delete(int id);


        public List<Department> Get();


        public Department GetByID(int id);


        public void Save();
        
    }
}
