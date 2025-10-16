using Demo.BLL.DTOs.DepartmenDtos;
using Demo.BLL.DTOs.EmployeeDtos;
using Demo.BLL.Services.Classes;
using Demo.BLL.Services.Interfaces;
using Demo.PL.ViewModels.DepartmentViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeesController(IEmployeeService _employeeService, ILogger<HomeController> _logger, IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index()
        {
            var employee =_employeeService.GetAllEmployees();
            return View(employee);
        }

        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(CreatedEmployeeDto dto) 
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int res = _employeeService.AddEmployee(dto);
                    if (res > 0) return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee Can't Be Added");
                        return View(dto);
                    }




                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(dto);
                    }
                    else
                    {
                        //_logger.LogError(ex.Message);
                        return View(dto);
                    }


                }

            }
            else return View(dto);
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
            
          
            return View(employee);
        }
        //[HttpPost]
        //public ActionResult Edit([FromRoute] int id, DepartmentEditViewModel viewModel)
        //{
        //    if (!ModelState.IsValid) return View(viewModel);
        //    else
        //    {
        //        try
        //        {
        //            var updateDeptDto = new UpdatedDepartmentDto()
        //            {
        //                Id = id,
        //                Code = viewModel.Code,
        //                Description = viewModel.Description,
        //                Name = viewModel.Name,
        //                DateOfCreation = viewModel.DateOfCreation


        //            };
        //            var res = _employeeService.UpdatedEmployee(updateDeptDto);
        //            if (res > 0) return RedirectToAction(nameof(Index));
        //            else
        //            {
        //                ModelState.AddModelError(string.Empty, "Department Can't Be Added");
        //                return View(viewModel);
        //            }

        //        }
        //        catch (Exception ex)
        //        {

        //            if (_environment.IsDevelopment())
        //            {
        //                ModelState.AddModelError(string.Empty, ex.Message);
        //                return View(viewModel);
        //            }
        //            else
        //            {
        //                //_logger.LogError(ex.Message);
        //                return View(viewModel);
        //            }


                }


            }
