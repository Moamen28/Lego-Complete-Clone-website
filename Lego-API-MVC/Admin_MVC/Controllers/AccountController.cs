using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Repository.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;
using USER_API.Authontaction;
using ViewModels;

namespace Admin_MVC.Models.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManger;
        private readonly SignInManager<ApplicationUser> signIn;
        private readonly ILogger<AccountController> loger;
        private readonly RoleManager<IdentityRole<int>> roleManager;
        private readonly IConfiguration configuration;
        public AccountController( IConfiguration _configuration, RoleManager<IdentityRole<int>> _roleManager, UserManager<ApplicationUser> _UserManger, SignInManager<ApplicationUser> _SignIn, ILogger<AccountController> _Loger)
        {
            roleManager = _roleManager;
            userManger = _UserManger;
            signIn = _SignIn;
            loger = _Loger;
            configuration = _configuration;
        }



        [HttpGet]
        public IActionResult CreateAdmin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdmin(CreateAdminViewModel NewAdmin)
        {
            if (ModelState.IsValid)
            {
                var user = NewAdmin.ToModel();
                var result = await userManger.CreateAsync(user, NewAdmin.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        #region Register as Admin

        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(CreateAdminViewModel model)
        {
            var user = model.ToModel();
            var result = await userManger.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Massage = "user Creation Failed" });
            }
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole<int>(UserRoles.Admin));

            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole<int>(UserRoles.User));

            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManger.AddToRoleAsync(user, UserRoles.Admin);
            }
            return Ok(new Response { Status = "Success", Massage = "User Create Scuceful" });
        }

        #endregion Register as Admin


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel ModelUser)
        {
            if (ModelState.IsValid)
            {
                var result = await signIn.PasswordSignInAsync(ModelUser.Email, ModelUser.Password, ModelUser.RemomberMe, false);
                if (result.Succeeded)
                {
                    //get current user
                    var user = await userManger.FindByNameAsync(ModelUser.Email);

                    //var temp =await roleManager.FindByNameAsync(UserRoles.Admin);
                    var userRoles = await userManger.GetRolesAsync(user);

                    foreach (var rol in userRoles)
                    {
                        if (rol == "Admin")
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    return View(ModelUser);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid UserName Or Password Attempt");
                }
            }
            return View(ModelUser);
        }


        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await signIn.SignOutAsync();

            return RedirectToAction("Login");
        }



        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManger.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var token = await userManger.GeneratePasswordResetTokenAsync(user);

                    var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);

                    MailHelper.sendMail("Password Reset Link", passwordResetLink);

                    //loger.Log(LogLevel.Warning, passwordResetLink);

                    return RedirectToAction("ConfirmForgetPassword");
                }

                return RedirectToAction("ConfirmForgetPassword");

            }

            return View(model);
        }




        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }




        [HttpGet]
        public IActionResult ResetPassword(string Email, string Token)
        {
            if(Email == null || Token == null )
            {
                ModelState.AddModelError("", "Invalid Data");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManger.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await userManger.ResetPasswordAsync(user, model.Token, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ConfirmResetPassword");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }

                return RedirectToAction("ConfirmResetPassword");
            }

            return View(model);
        }




        public IActionResult ConfirmResetPassword()
        {
            return View();
        }


        #region GetAllUsers
        [HttpGet]
        public IActionResult GetUsers()
        {
            var res =  userManger.GetUsersInRoleAsync(UserRoles.User);
            return View(res);
        }

        //public async Task<List<ApplicationUser>> GetUsers()
        //{
        //    var res = await userManger.GetUsersInRoleAsync(UserRoles.User);
        //    return res.ToList();
        //}
        #endregion
    }
}
