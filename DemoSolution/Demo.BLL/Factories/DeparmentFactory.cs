using Demo.BLL.DTOs;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Factories
{
    public static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Department department)
        {
            return new DepartmentDto()
            {
                DeptId = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateOfCreation = DateOnly.FromDateTime(department.CreatedON)
            };

        }
        public static DepartmentDetailDto ToDepartmentDetailDto(this Department dept)
        {
            return new DepartmentDetailDto()
            {
                Id= dept.Id,
                Name = dept.Name,
                Code = dept.Code,
                Description = dept.Description,
                DateOfCreation = DateOnly.FromDateTime(dept.CreatedON),
                LastModifiedOn = DateOnly.FromDateTime(dept.LastModifiedOn),
                LastModifiedBy = dept.LastModifiedBy,
                IsDeleted = dept.IsDeleted,
                CreatedBy = dept.CreatedBy,

            };
                
        }

        public static Department ToEntity(this CreatedDepartmentDto dto)
        {
            return new Department()
            {
                Name = dto.Name,
                Code = dto.Code,
                Description = dto.Description,
                CreatedON = dto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }
        public static Department ToEntity(this UpdatedDepartmentDto dto)
        {
            return new Department()
            {
                Name = dto.Name,
                Code = dto.Code,
                Description = dto.Description,
                CreatedON = dto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }

    }
}
