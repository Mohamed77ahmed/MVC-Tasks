using Demo.DAL.Data.Contexts;

namespace Demo.DAL.Repositories
{
    public interface IDepartmentRepository
    {
        int Add(Department department);
        IEnumerable<Department> GetAll(bool WithTracking = false);
        Department? GetById(int id, ApplicationDbContext context);
        Department? GetById(int id);
        int Remove(Department department);
        int Update(Department department);
    }
}