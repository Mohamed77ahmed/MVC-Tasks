using Demo.BLL.DTOs.DepartmenDtos;
using Demo.BLL.DTOs.EmployeeDtos;
using Demo.BLL.Services.Classes;
using Demo.BLL.Services.Interfaces;
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Models.Shared.Enums;
using Demo.PL.ViewModels.DepartmentViewModels;
using Demo.PL.ViewModels.EmployeeViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeesController(IEmployeeService _employeeService, ILogger<HomeController> _logger, IWebHostEnvironment _environment) : Controller
    {
        
        public IActionResult Index(string? EmployeeSearchName)
        {
            var employee = _employeeService.GetAllEmployees(EmployeeSearchName);
            return View(employee);
        }

        [HttpGet]
        public ActionResult Create([FromServices]IDepartmentService _departmentService)
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dto = new CreatedEmployeeDto()
                    {
                        Name = model.Name,
                        Age = model.Age,
                        Email = model.Email,
                        DepartmentId = model.DepartmentId,
                        Address = model.Address,
                        EmployeeType = model.EmployeeType,
                        Gender = model.Gender,
                        HiringDate = model.HiringDate,
                        IsActive = model.IsActive,
                        PhoneNumber = model.PhoneNumber,
                        Salary = model.Salary,
                        Image = model.Image

                    };
                    int res = _employeeService.AddEmployee(dto);
                    string msg;
                    if (res > 0) msg = $" Employee {dto.Name} Is Added Successfully  ";
                    else msg = $" Employee {dto.Name} Can't Be Added ";
                    TempData["Message"] = msg;
                    return RedirectToAction(nameof(Index));




                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(model);
                    }
                    else
                    {
                        //_logger.LogError(ex.Message);
                        return View(model);
                    }


                }

            }
            else return View(model);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var employee = _employeeService.GetById(id.Value);
            if (employee is null) return NotFound();
            return View(employee);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var employee = _employeeService.GetById(id.Value);
            if (employee is null) return NotFound();
            var dto = new EmployeeViewModel()
            {

                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary,
                HiringDate = employee.HiringDate,
                IsActive = employee.IsActive,
                EmployeeType = Enum.Parse<EmployeeTypes>(employee.EmployeeType),
                Gender = Enum.Parse<Gender>(employee.Gender),
                DepartmentId = employee.DepartmentId


            };

            return View(dto);
        }
        [HttpPost]
        public ActionResult Edit([FromRoute] int id, EmployeeViewModel model)
        {

            


            if (!ModelState.IsValid) return View(model);
            else
            {
                try
                {
                    var dto = new UpdatedEmployeeDto()
                    {
                        Name = model.Name,
                        Age = model.Age,
                        Email = model.Email,
                        DepartmentId = model.DepartmentId,
                        Address = model.Address,
                        EmployeeType = model.EmployeeType,
                        Gender = model.Gender,
                        HiringDate = model.HiringDate,
                        IsActive = model.IsActive,
                        PhoneNumber = model.PhoneNumber,
                        Salary = model.Salary,
                    };
                    var res = _employeeService.UpdatedEmployee(dto);
                    if (res > 0) return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee Can't Be Added");
                        return View(model);
                    }

                }
                catch (Exception ex)
                {

                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(model);
                    }
                    else
                    {
                        //_logger.LogError(ex.Message); // for deployement
                        return View(model);
                    }

                }
            }
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool isDeleted = _employeeService.DeleteEmployee(id);
                if (isDeleted) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee Can's Be Deleted");

                    return RedirectToAction(nameof(Delete), new { id });
                }

            }
            catch (Exception ex)
            {

                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //_logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }


            }

        }
    }
}
