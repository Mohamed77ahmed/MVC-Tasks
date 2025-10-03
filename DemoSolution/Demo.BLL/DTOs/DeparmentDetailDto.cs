using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DTOs
{
    public class DepartmentDetailDto
    {
        //public DepartmentDetailDto(Department dept)
        //{
        //    Id = dept.Id;
        //    Name = dept.Name;
        //    Code = dept.Code;
        //    Description = dept.Description;
        //    DateOfCreation = DateOnly.FromDateTime(dept.CreatedON);
        //    LastModifiedOn = DateOnly.FromDateTime(dept.LastModifiedOn);
        //    LastModifiedBy = dept.LastModifiedBy;
        //    IsDeleted = dept.IsDeleted;
        //    CreatedBy = dept.CreatedBy;


        //}
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public DateOnly DateOfCreation { get; set; }
        public DateOnly LastModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public int LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; } 

    }
}
