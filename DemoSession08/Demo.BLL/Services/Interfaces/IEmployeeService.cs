using Demo.BLL.DTOs.DepartmenDtos;
using Demo.BLL.DTOs.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees(string? EmployeeSearchName, bool withTracking= false);
        EmployeeDetailsDto? GetById(int id);
        int AddEmployee(CreatedEmployeeDto employeeDto);

        int UpdatedEmployee(UpdatedEmployeeDto employeeDto);
        bool DeleteEmployee(int id);
    }
}
