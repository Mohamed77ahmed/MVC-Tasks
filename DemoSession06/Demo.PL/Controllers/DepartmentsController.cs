using Demo.BLL.DTOs;
using Demo.BLL.DTOs.DepartmenDtos;
using Demo.BLL.Services.Interfaces;
using Demo.PL.ViewModels.DepartmentViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Demo.PL.Controllers
{
    public class DepartmentsController(IDepartmentService _departmentService, ILogger<HomeController> _logger,IWebHostEnvironment _environment) :Controller
    {
        private readonly IDepartmentService departmentService = _departmentService;
        private readonly ILogger<HomeController> logger = _logger;
        private readonly IWebHostEnvironment environment = _environment;

        // DepartmentService departmentservice used Across all actions
        // EmployeeService --> Assign manager :this service needed only for one action

        [HttpGet]
        public IActionResult Index() 
        {
            var department = departmentService.GetAllDepartment();
            return View(department);  
        }


        [HttpGet]
        public IActionResult Create() 
        {
            return View();
            
        }

        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto departmentDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int res = departmentService.AddDepartment(departmentDto);
                    if (res > 0) return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department Can't Be Added");
                        return View(departmentDto);
                    }




                }
                catch (Exception ex)
                {
                    if(_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(departmentDto);
                    }
                    else 
                    {
                        //_logger.LogError(ex.Message);
                        return View(departmentDto);
                    }

                    
                }

            }
            else return View(departmentDto);
        }



        [HttpGet]
        public IActionResult Details(int? id) 
        {
            if(!id.HasValue) return BadRequest();

            var department=_departmentService.GetById(id.Value);
            if(department is null) return NotFound();   
            return View(department);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var department = _departmentService.GetById(id.Value);
            if (department is null) return NotFound();
            var deptViewModel = new DepartmentEditViewModel()
            {
                Code = department.Code,
                Description = department.Description,
                Name = department.Name,
                DateOfCreation  = department.DateOfCreation

            };
            return View(deptViewModel);
        }

        [HttpPost]
        public ActionResult Edit( [FromRoute] int id,DepartmentEditViewModel viewModel)
        { 
            if(!ModelState.IsValid) return View(viewModel);
            else
            {
                try
                {
                    var updateDeptDto = new UpdatedDepartmentDto()
                    {
                        Id=id,
                        Code = viewModel.Code,
                        Description = viewModel.Description,
                        Name = viewModel.Name,
                        DateOfCreation = viewModel.DateOfCreation


                    };
                    var res=_departmentService.UpdatedDepartment(updateDeptDto);
                    if (res > 0) return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department Can't Be Added");
                        return View(viewModel);
                    }

                }
                catch (Exception ex)
                {

                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(viewModel);
                    }
                    else
                    {
                        //_logger.LogError(ex.Message);
                        return View(viewModel);
                    }


                }
            }
        
      
        }

        [HttpPost]
        public IActionResult Delete( int id)
        { 
            if(id==0)return BadRequest();
            try
            {
                bool isDeleted=_departmentService.DeleteDepartment(id);
                if(isDeleted) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Department Can's Be Deleted");

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
                    return View("ErrorView",ex);
                }


            }

        }
    }

   
}
