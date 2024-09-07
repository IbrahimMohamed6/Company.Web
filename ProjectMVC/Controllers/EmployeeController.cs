using Company.Data.Entites;
using Company.Reposatry.Interfaces;
using Company.Services;
using Company.Services.Employee.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        private readonly IDepartmentServices _departmentServices;

        public EmployeeController(IEmployeeServices employeeServices ,IDepartmentServices departmentServices )
        {
           _employeeServices = employeeServices;
            _departmentServices = departmentServices;
        }
        public IActionResult Index(string SearchInput)
        {
            // ViewBag.Message = "Hallow From Employee Index(ViewBag)";
            IEnumerable<EmployeeDto> employees =new List<EmployeeDto>();
             if(string.IsNullOrEmpty(SearchInput))
                employees = _employeeServices.GetAll();
             else
             employees= _employeeServices.GetEmployeeByName(SearchInput);
              return View(employees);

        }
        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.Departments=_departmentServices.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeDto employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _employeeServices.Add(employee);
                   
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the employee. Please try again later.");
                }

            }

            return View(employee);
        }

        public IActionResult Details(int? id)
        {
            var Department = _employeeServices.GetById(id.Value);
            if (Department == null)
                return NotFound();
            return View(Department);
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            var Department = _employeeServices.GetById(id.Value);
            if (Department == null)
                return NotFound();
            return View(Department);

        }

        [HttpPost]
        public IActionResult Update(int? id,EmployeeDto employee)
        {
            if (employee.Id != id.Value)
                return NotFound();
            if (ModelState.IsValid)
            {
                // Save department to database
                // dbContext.Departments.Add(department);
                // dbContext.SaveChanges();
                _employeeServices.Update(employee);// Redirect to a list or details page

                return RedirectToAction(nameof(Index)); // Redirect to a list or details page

            }
            return View(employee);
        }

        public IActionResult Delete(int? id)
        {
            var department = _employeeServices.GetById(id.Value);
            if (department.Id != id.Value)
                return NotFound();
            if (ModelState.IsValid)
            {
                // Save department to database
                // dbContext.Departments.Add(department);
                // dbContext.SaveChanges();
                    _employeeServices.Delete(department);// Redirect to a list or details page

                return RedirectToAction(nameof(Index)); // Redirect to a list or details page

            }
            return View(department);

        }
    }
}
