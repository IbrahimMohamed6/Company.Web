using Company.Reposatry.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeReposatry _employeeReposatry;

        public EmployeeController(IEmployeeReposatry employeeReposatry)
        {
            _employeeReposatry = employeeReposatry;
        }
        public IActionResult GetAll()
        {
            var AllEmployees = _employeeReposatry.GetAll();
            return View(AllEmployees);
        }
    }
}
