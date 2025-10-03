using Demo.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class DepartmentsController(IDepartmentService _departmentService):Controller
    {
        // DepartmentService departmentservice used Across all actions
        // EmployeeService --> Assign manager :this service needed only for one action

        [HttpGet]
        public IActionResult Index() 
        {
            var department = _departmentService.GetAllDepartment();
            return View(department);  
        }
    }
}
