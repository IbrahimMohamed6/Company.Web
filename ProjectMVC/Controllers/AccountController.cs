using Company.Data.Entites;
using Company.Services.Helper;
using Company.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace Company.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #region Sign Up
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
                var Result = await _userManager.CreateAsync(User, Input.Password);
                if (Result.Succeeded)
                    return RedirectToAction("LogIn");
                foreach (var error in Result.Errors)
                    ModelState.AddModelError("", error.Description);
            }
            return View(Input);
        }
        #endregion


        #region Sign In
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel Input)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user is not null)
                {
                    if (await _userManager.CheckPasswordAsync(user, Input.Password))
                    {
                        var Result = await _signInManager.PasswordSignInAsync(user, Input.Password, Input.RememberMe, true);
                        if(Result.Succeeded)
                           return RedirectToAction("Index","Home");
                    }
                }
                ModelState.AddModelError("", "Incorrect Email Or Password");
                return View(Input);
            }
            return View(Input);

        }

        #endregion

        public new async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("LogIn");
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel Input)
        {
            if (ModelState.IsValid) 
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user is not null) 
                { 
                    var Token= await _userManager.GeneratePasswordResetTokenAsync(user);
                    var url = Url.Action("ResetPassword", "Account", new
                    {
                        Email = Input.Email,
                        Token = Token,
                        //Request.Scheme
                    }, protocol: Request.Scheme);
                    var email = new Email
                    {
                        Body = url,
                        Subject = "Reset Password",
                        To = Input.Email
                    };
                    EmailSettings.SendEmail(email);
                    return RedirectToAction(nameof(SheckYourInbox));
                }
            } 
            return View(Input);
        }
        public IActionResult SheckYourInbox()
        {
            return View();
        }
        public IActionResult ResetPassword(string Email,string Token)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel Input)
        {
            if (ModelState.IsValid) 
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if(user is not null)
                {
                    var Result = await _userManager.ResetPasswordAsync(user, Input.Token, Input.Password);
                    if (Result.Succeeded)
                    return RedirectToAction(nameof(Login));

                    foreach (var error in Result.Errors)
                        ModelState.AddModelError("", error.Description);

                }
            }
            return View(Input);
        }
        public IActionResult AccessDenid()
        {
            return View();
        }
    }
}
