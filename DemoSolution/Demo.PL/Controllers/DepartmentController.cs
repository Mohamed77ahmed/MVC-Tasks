using Demo.BLL;

namespace Demo.PL.Controllers
{
    public class DepartmentController
    {
        // DepartmentService departmentservice used Across all actions
        // EmployeeService --> Assign manager :this service needed only for one action

        public DepartmentController(DepartmentService departmentService)// Call Service Department Service
        {
            
        }// Ask CLR to Create Object From Department
    }
}
