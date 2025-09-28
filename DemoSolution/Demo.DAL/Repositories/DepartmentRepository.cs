using Demo.DAL.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Repositories
{
    public class DepartmentRepository(ApplicationDbContext context)
    {
        private readonly ApplicationDbContext _context = context;

        public Department? GetById(int id, ApplicationDbContext context)
        {
            var department = _context.Departments.Find(id);
            return department; 

        }
        //Get All Department 
        //Add Department 
        //Update Department 
        //Delete Department 
    }
}
