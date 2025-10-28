using Demo.DAL.Data.Contexts;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BLL.Factories;
using Demo.DAL.Repositories.Interfaces;
using Demo.BLL.Services.Interfaces;
using Demo.BLL.DTOs.DepartmenDtos;

namespace Demo.BLL.Services.Classes
{
    public class DepartmentService(IUnitOFWork _unitOFWork) : IDepartmentService
    {

        //Get All
        public IEnumerable<DepartmentDto> GetAllDepartment()
        {
            var depts = _unitOFWork.DepartmentRepository.GetAll();
            var departmentToReturn = depts.Select(d => d.ToDepartmentDto()); //extension method

            return departmentToReturn;
        }

        // Get By Id
        public DepartmentDetailDto? GetById(int id)
        {
            var dept = _unitOFWork.DepartmentRepository.GetById(id);
            //if (dept == null) return null;
            //else
            //{
            //    var deptToReturn = new DepartmentDetailDto()
            //    {
            //        Id = dept.Id,
            //        Name= dept.Name,
            //        Code = dept.Code,
            //        Description=dept.Description,
            //        CreatedBy=dept.CreatedBy,
            //        IsDeleted=dept.IsDeleted,
            //        DateOfCreation=DateOnly.FromDateTime(dept.CreatedON),
            //        LastModifiedOn=DateOnly.FromDateTime(dept.LastModifiedOn)




            //    };

            //}
            //return dept == null ? null : new DepartmentDetailDto(dept);                //copy constructor mapping

            return dept is null ? null : dept.ToDepartmentDetailDto();
            // extension method

        }

        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            var entity = departmentDto.ToEntity();
             _unitOFWork.DepartmentRepository.Add(entity);
            return _unitOFWork.SaveChanges();
        }

        public int UpdatedDepartment(UpdatedDepartmentDto departmentDto)
        {
            var entity = departmentDto.ToEntity();
           _unitOFWork.DepartmentRepository.Update(entity);
            return _unitOFWork.SaveChanges();
        }

        public bool DeleteDepartment(int id)
        {
            var dept = _unitOFWork.DepartmentRepository.GetById(id);
            if (dept is null) return false;
            else
            {
                 _unitOFWork.DepartmentRepository.Remove(dept);
                if (_unitOFWork.SaveChanges() > 0) return true;
                else return false;
            }
        }
    }
}
