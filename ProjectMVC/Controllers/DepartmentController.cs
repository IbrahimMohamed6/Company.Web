using Company.Reposatry.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentreposatry _departmentreposatry;

        public DepartmentController(IDepartmentreposatry departmentreposatry)
        {
            _departmentreposatry = departmentreposatry;
        }
        public IActionResult Index()
        {
            var AllDepartment = _departmentreposatry.GetAll();
            return View(AllDepartment);
        }

        
    }
}
