using AutoMapper;
using Demo.BLL.DTOs.EmployeeDtos;
using Demo.DAL.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.MappingProfiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {

            //CreateMap< EmployeeDto, Employee>();        //one way
            //CreateMap<Employee, EmployeeDto>().ReverseMap();     // two ways
            CreateMap<Employee, EmployeeDto>().ForMember(dest => dest.EmpGender, option => option.MapFrom(src => src.Gender))        //one way
                                              .ForMember(dest => dest.EmpType, option => option.MapFrom(src => src.EmployeeTypes))
                                              .ForMember(dest => dest.Department, option => option.MapFrom(src => src.Department !=null ? src.Department.Name:null));
                                               


            CreateMap< Employee, EmployeeDetailsDto>().ForMember(dest => dest.EmployeeType, option => option.MapFrom(src => src.EmployeeTypes))        
                                                     .ForMember(dest => dest.Gender, option => option.MapFrom(src => src.Gender))       
                                                     .ForMember(dest => dest.HiringDate, option => option.MapFrom (src =>DateOnly.FromDateTime(src.HiringDate))).ForMember(dest => dest.Department, option => option.MapFrom(src => src.Department != null ? src.Department.Name : null))     
            .ReverseMap();
            CreateMap<CreatedEmployeeDto, Employee>().ForMember(dest => dest.HiringDate, option => option.MapFrom(src => src.HiringDate.ToDateTime(new TimeOnly())));

            CreateMap<UpdatedEmployeeDto, Employee>().ForMember(dest => dest.HiringDate, option => option.MapFrom(src => src.HiringDate.ToDateTime(new TimeOnly()))); ;
        }
    }
}
