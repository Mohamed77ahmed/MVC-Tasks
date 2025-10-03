using Demo.BLL.DTOs;

namespace Demo.BLL.Services
{
    public interface IDepartmentService
    {
        int AddDepartment(CreatedDepartmentDto departmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDto> GetAllDepartment();
        DepartmentDetailDto? GetById(int id);
        int UpdatedDepartment(UpdatedDepartmentDto departmentDto);
    }
}