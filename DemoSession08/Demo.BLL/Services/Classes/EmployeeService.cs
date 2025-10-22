using AutoMapper;
using Demo.BLL.DTOs.EmployeeDtos;
using Demo.BLL.Services.AttachmentServices;
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
    public class EmployeeService(IUnitOFWork _unitOFWork,IMapper _mapper,IAttachmentServices 
        _attachmentServices) : IEmployeeService
    {
        //private readonly EmployeeRepository employeeRepository = _unitOFWork.EmployeeRepository;

        public IEnumerable<EmployeeDto> GetAllEmployees(string ? EmployeeSearchName, bool withTracking = false)
        {
            //var employees = _unitOFWork.EmployeeRepository.GetAll(e=>e.Name.ToLower().Contains( EmployeeSearchName.ToLower())).ToList();




            #region MyRegion
            ////var employeeDto = employees.Select(employee => new EmployeeDto 
            ////{ Id = employee.Id,
            ////Name = employee.Name,
            ////Salary = employee.Salary,
            ////Age = employee.Age,
            ////IsActive = employee.IsActive,
            ////Email = employee.Email,
            ////Gender=employee.Gender.ToString(),
            ////EmployeeType=employee.EmployeeTypes.ToString(), 

            ////});     
            #endregion

            ////Destination                source
            //var employeeDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            //return employeeDto;

            IEnumerable<Employee> employees;
            if (string.IsNullOrWhiteSpace(EmployeeSearchName))
                employees = _unitOFWork.EmployeeRepository.GetAll().ToList();

            else employees = _unitOFWork.EmployeeRepository.GetAll(e => e.Name.ToLower()
                                                .Contains(EmployeeSearchName.ToLower()))
                                                .ToList();

           return _mapper.Map<IEnumerable<Employee>,IEnumerable<EmployeeDto>>(employees);

           

        }

        public EmployeeDetailsDto? GetById(int id)
        {
            var employee= _unitOFWork.EmployeeRepository.GetById(id);
           
            return employee is null?null: _mapper.Map<EmployeeDetailsDto>(employee);
        }
        public int AddEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee=_mapper.Map<Employee>(employeeDto);


            if(employeeDto.Image is not null)
            employee.ImageName = _attachmentServices.Upload(employeeDto.Image, "Images");

           _unitOFWork.EmployeeRepository.Add(employee);

            return _unitOFWork.SaveChanges();

        }

        public bool DeleteEmployee(int id)
        {
           var employee= _unitOFWork.EmployeeRepository.GetById(id);
            if(employee is null) return false;
            else
            {
                employee.IsDeleted = true;
                _unitOFWork.EmployeeRepository.Update(employee);
                return _unitOFWork.SaveChanges()>0 ?true :false;
            }
        }

       

       

        public int UpdatedEmployee(UpdatedEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
             _unitOFWork.EmployeeRepository.Update(employee);
            return _unitOFWork.SaveChanges();

        }
    }
}
