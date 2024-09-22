using Company.Data.Entites;
using Company.Services.DepartmentServices.Dto;
using Company.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Company.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
	{
		
		private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;

        public UserController(UserManager<ApplicationUser>
            userManager,ILogger<UserController> logger)
        {
			_userManager = userManager;
           _logger = logger;
        }

        public async Task<IActionResult> Index(string SearchInput)
		{
			List<ApplicationUser> users;
			if (string.IsNullOrEmpty(SearchInput)) 
			{ 
				users =await _userManager.Users.ToListAsync();
			}
			else
			{
				users=await _userManager.Users.Where(users=>
				users.NormalizedEmail.Trim()
				.Contains(SearchInput.Trim().ToUpper())).ToListAsync();
			}
			return View(users);
		}

        public async Task< IActionResult> Details(string id, string v="Details")
        {
			var User = await _userManager.FindByIdAsync(id);
            if (User is  null)
                return NotFound();
            if (v == "Update")
            {
                var UserViewModel = new UserUpdateViewModel
                {
                    Id = User.Id,
                    UserName = User.UserName
                };
                return View(v, UserViewModel);
            }

            return View(v,User);
        }
		[HttpGet]
        public async Task< IActionResult> Update(string id)
        {
            return await Details(id,"Update");
        }
        [HttpPost]
        public async Task< IActionResult> Update(string id, UserUpdateViewModel applicationUser)
        {
            if (id != applicationUser.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
				try
				{
                    var User = await _userManager.FindByIdAsync(id);
                    if (User is null)
                        return NotFound();
                    User.UserName= applicationUser.UserName;
                    User.NormalizedUserName=applicationUser.UserName.ToUpper();
                    var Result = await _userManager.UpdateAsync(User);
                    if (Result.Succeeded)
                    {
                        _logger.LogInformation("User Updaded Succesfully ");

                        return RedirectToAction(nameof(Index));
                    }
                    foreach (var item in Result.Errors)
                        _logger.LogError(item.Description);
                        
                }
				catch (Exception ex)
				{
                    _logger?.LogError(ex.Message);
				}

                 // Redirect to a list or details page

            }
            return View(applicationUser);
        }
        public async Task<IActionResult> Delete(string id)
        {
            try
            {


                var User = await _userManager.FindByIdAsync(id);
                if (User is null)
                    return NotFound();
                var Result = await _userManager.DeleteAsync(User);
                if (Result.Succeeded)
                {
                    _logger.LogInformation("User Deleted Succesfully ");

                    return RedirectToAction(nameof(Index));
                }
                foreach (var item in Result.Errors)
                    _logger.LogError(item.Description);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                _logger?.LogError(ex.Message);
            }
            return RedirectToAction(nameof(Index));

        }
        
    }
}
