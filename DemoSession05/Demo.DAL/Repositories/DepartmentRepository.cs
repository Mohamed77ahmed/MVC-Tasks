using Demo.DAL.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Repositories
{
    public class DepartmentRepository(ApplicationDbContext context) : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context = context;

        public Department? GetById(int id, ApplicationDbContext context)
        {
            var department = _context.Departments.Find(id);
            return department;

        }
        //Get All Department 
        public IEnumerable<Department> GetAll(bool WithTracking = false)
        {
            if (WithTracking) return _context.Departments.ToList();
            else return _context.Departments.AsNoTracking();

        }
        //Add Department 
        public int Add(Department department)
        {
            _context.Departments.Add(department);
            return _context.SaveChanges();
        }
        //Update Department 
        public int Update(Department department)
        {
            _context.Departments.Update(department);
            return _context.SaveChanges();
        }
        //Delete Department 
        public int Remove(Department department)
        {
            _context.Departments.Remove(department);
            return _context.SaveChanges();

        }

        //public object GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        Department? IDepartmentRepository.GetById(int id)
        {
            var department = _context.Departments.Find(id);
            return department;

        }
    }
}
