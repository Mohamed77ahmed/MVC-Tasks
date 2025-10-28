using Demo.BLL.DTOs.DepartmenDtos;

namespace Demo.BLL.Services.Interfaces
{
    public interface IDepartmentService
    {
        
        IEnumerable<DepartmentDto> GetAllDepartment();
        DepartmentDetailDto? GetById(int id);
        int AddDepartment(CreatedDepartmentDto departmentDto);

        int UpdatedDepartment(UpdatedDepartmentDto departmentDto);
        bool DeleteDepartment(int id);
    }
}