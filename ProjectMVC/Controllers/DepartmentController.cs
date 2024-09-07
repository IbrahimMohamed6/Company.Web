using Company.Data.Entites;
using Company.Reposatry.Interfaces;
using Company.Services;
using Company.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentServices; 

        public DepartmentController(IDepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }
        public IActionResult Index()  
        {
            var AllDepartment = _departmentServices.GetAll();
            return View(AllDepartment);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _departmentServices.Add(department);
                    return RedirectToAction(nameof(Index));

                }
                ModelState.AddModelError("DepartMentError", "Validition Error");
                return View(department);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Department Error", ex.Message);
                return View(department);

            }


        }

        public IActionResult Details(int? id)
        {
            var Department = _departmentServices.GetById(id);
            if (Department == null)
                return NotFound();
            return View(Department);
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            var Department = _departmentServices.GetById(id);
            if (Department == null)
                return NotFound();
            return View(Department);

        }

        [HttpPost]
        public IActionResult Update(int?id ,Department department)
        {
            if(department.Id != id.Value)
                return NotFound();
            if (ModelState.IsValid)
            {
                // Save department to database
                // dbContext.Departments.Add(department);
                // dbContext.SaveChanges();
                _departmentServices.Update(department);// Redirect to a list or details page

                return RedirectToAction(nameof(Index)); // Redirect to a list or details page

            }
            return View(department);
        }
       
        public IActionResult Delete(int? id)
        {
            var department= _departmentServices.GetById(id);
            if (department.Id != id.Value)
                return NotFound();
            if (ModelState.IsValid)
            {
                // Save department to database
                // dbContext.Departments.Add(department);
                // dbContext.SaveChanges();
                _departmentServices.Delete(department);// Redirect to a list or details page

                return RedirectToAction(nameof(Index)); // Redirect to a list or details page

            }
            return View(department);

        }
             
    }

}
