using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Repositories.Interfaces
{
    public interface IUnitOFWork
    {
        public IDepartmentRepository DepartmentRepository { get; } //Public ReadOnly
        public IEmployeeRepository EmployeeRepository { get; } //Public ReadOnly

        int SaveChanges();


    }
}
