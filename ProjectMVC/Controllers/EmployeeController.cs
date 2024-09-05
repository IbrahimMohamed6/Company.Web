using Company.Data.Entites;
using Company.Reposatry.Interfaces;
using Company.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _employeeServices;

        public EmployeeController(IEmployeeServices employeeServices )
        {
           _employeeServices = employeeServices;
        }
        public IActionResult Index()
        {
            var AllDepartment = _employeeServices.GetAll();
            return View(AllDepartment);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
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
        public IActionResult Update(int? id, Employee employee)
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
