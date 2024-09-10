using Company.Data.Entites;
using Company.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser>  userManager)
        {
            _userManager = userManager;
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel Input)
        {
            if (ModelState.IsValid) 
            {
                var User = new ApplicationUser
                {
                    UserName = Input.Email.Split("@")[0],
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    Lastname = Input.LastName,
                    IsActive = true
                };
                var Result=await _userManager.CreateAsync(User,Input.Password);
                if (Result.Succeeded)
                    return RedirectToAction("SignIn");
                foreach (var error in Result.Errors)
                    ModelState.AddModelError("", error.Description);
            }
            return View(Input);
        }
    }
}
