using Company.Data.Entites;
using Company.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Company.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RolesController> _logger;

        public RolesController(RoleManager<IdentityRole> roleManager
            ,UserManager<ApplicationUser>  userManager
            ,ILogger<RolesController> logger)
        {
           _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var Roles=await _roleManager.Roles.ToListAsync();
            return View(Roles);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Create(IdentityRole role)
        {
            if (ModelState.IsValid) 
            { 
                var Rsult=await _roleManager.CreateAsync(role);
                if (Rsult.Succeeded)
                   return RedirectToAction(nameof(Index));

                foreach (var item in Rsult.Errors)
                    _logger.LogError(item.Description);
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }
        public async Task<IActionResult> Details(string id, string v = "Details")
        {
            var Role = await _roleManager.FindByIdAsync(id);
            if (Role is null)
                return NotFound();

            var RoleViewModel = new RoleViewModel
            {
                Id = Role.Id,
                Name = Role.Name
            };
            return View(v, RoleViewModel);

        }
       
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            return await Details(id, "Update");
        }
        [HttpPost]
        public async Task<IActionResult> Update(string id, RoleViewModel model)
        {
            if (id != model.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    var Role = await _roleManager.FindByIdAsync(id);
                    if (Role is null)
                        return NotFound();
                    Role.Name = model.Name;
                    Role.NormalizedName = model.Name.ToUpper();
                    var Result = await _roleManager.UpdateAsync(Role);
                    if (Result.Succeeded)
                    {
                        _logger.LogInformation("Role Updaded Succesfully ");

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
            return View(model);
        }
        public async Task<IActionResult> Delete(string id)
        {
            try
            {


                var Role = await _roleManager.FindByIdAsync(id);
                if (Role is null)
                    return NotFound();
                var Result = await _roleManager.DeleteAsync(Role);
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

        public async Task< IActionResult> AddOrRemoveUsers(string RoleId)
        {
            var Role=await _roleManager.FindByIdAsync(RoleId);
            if (Role is null)
                return NotFound();
            ViewBag.RolId = RoleId;
            var Users =await _userManager.Users.ToListAsync();
            var UsersInRole = new List<UserInRoleViewModel>();
            foreach (var user in Users)
            {
                var UserInRole = new UserInRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };
                if(await _userManager.IsInRoleAsync(user,Role.Name))
                   UserInRole.IsSelected = true;
                else
                   UserInRole.IsSelected = false;

                UsersInRole.Add(UserInRole);


            }
            return View(UsersInRole);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrRemoveUsers(string RoleId,List<UserInRoleViewModel> Users)
        {
            var Role=await _roleManager.FindByIdAsync(RoleId);
            if(Role is null)
                return NotFound();
            if (ModelState.IsValid)
            {
                foreach(var user in Users)
                {
                    var appUser=await _userManager.FindByIdAsync(user.UserId);  
                    if(appUser is not null)
                    {
                        if (user.IsSelected && !await _userManager.IsInRoleAsync(appUser, Role.Name))
                        {
                            await _userManager.AddToRoleAsync(appUser,Role.Name);
                        }
                        else if (!user.IsSelected&& await _userManager.IsInRoleAsync(appUser, Role.Name))
                        {
                            await _userManager.RemoveFromRoleAsync(appUser, Role.Name);
                        }
                    }
                        


                }
                return RedirectToAction("Update",new {Id=RoleId});

            }
            return View(Users);
        }

    }
}
