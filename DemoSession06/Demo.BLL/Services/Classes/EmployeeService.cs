using AutoMapper;
using Demo.BLL.DTOs.EmployeeDtos;
using Demo.BLL.Services.Interfaces;
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Repositories.Classes;
using Demo.DAL.Repositories.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services.Classes
{
    public class EmployeeService(IEmployeeRepository _employeeRepository,IMapper _mapper) : IEmployeeService
    {
        //private readonly EmployeeRepository employeeRepository = _employeeRepository;

        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false)
        {
            var employees = _employeeRepository.GetAll();
            //var employeeDto = employees.Select(employee => new EmployeeDto 
            //{ Id = employee.Id,
            //Name = employee.Name,
            //Salary = employee.Salary,
            //Age = employee.Age,
            //IsActive = employee.IsActive,
            //Email = employee.Email,
            //Gender=employee.Gender.ToString(),
            //EmployeeType=employee.EmployeeTypes.ToString(), 



            //});                  
                                          //Destination                source
            var employeeDto= _mapper.Map< IEnumerable <EmployeeDto >>(employees);
            return employeeDto;
        }

        public EmployeeDetailsDto? GetById(int id)
        {
            var employee= _employeeRepository.GetById(id);
           
            return employee is null?null: _mapper.Map<EmployeeDetailsDto>(employee);
        }
        public int AddEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee=_mapper.Map<Employee>(employeeDto);
            return _employeeRepository.Add(employee);

        }

        public bool DeleteEmployee(int id)
        {
           var employee= _employeeRepository.GetById(id);
            if(employee is null) return false;
            else
            {
                employee.IsDeleted = true;
                return _employeeRepository.Update(employee)>0 ?true :false;
            }
        }

       

       

        public int UpdatedEmployee(UpdatedEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            return _employeeRepository.Update(employee);    
        }
    }
}
