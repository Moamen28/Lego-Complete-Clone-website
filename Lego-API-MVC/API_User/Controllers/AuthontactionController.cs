using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using USER_API.Authontaction;

namespace API_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthontactionController : ControllerBase
    {
        #region Define The propertys and consructor injecton and inilize

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;
        private readonly IConfiguration configuration;

        public AuthontactionController(UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole<int>> roleManager, IConfiguration _configuration)
        {
            this.userManager = _userManager;
            this.roleManager = roleManager;
            this.configuration = _configuration;
        }

        #endregion Define The propertys and consructor injecton and inilize

        #region Register as Customer

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var userExist = await userManager.FindByNameAsync(model.UserName);
            if (userExist != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Massage = "User Alrady Exist" });
            ApplicationUser user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Massage = "user Creation Failed" });
            }
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole<int>(UserRoles.Admin));

            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole<int>(UserRoles.User));

            if (await roleManager.RoleExistsAsync(UserRoles.User))
            {
                await userManager.AddToRoleAsync(user, UserRoles.User);
            }
            return Ok(new Response { Status = "Success", Massage = "User Create Scuceful" });
        }

        #endregion Register as Customer

        #region GetAllUsers
        [HttpGet]
        [Route("GetUsers")]
        public async Task<List<ApplicationUser>> GetUsers()
        {
            var res = await userManager.GetUsersInRoleAsync(UserRoles.User);
            return res.ToList();
        }
        #endregion

        #region Get User By UserName
        [HttpGet]
        [Route("GetUsersByUserName/{userName}")]
        public async Task<ApplicationUser> GetUser(string userName)
        {
            var result = await userManager.FindByEmailAsync(userName);

            return result;


        }
        #endregion

        #region Login as Admin oR Customer

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims =  new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };
                foreach (var userrole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role,  userrole));
                }
                var authSigninkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
                var token =  new JwtSecurityToken(

                    issuer: configuration["JWT:ValidIssuer"],
                      audience: configuration["JWT:ValidAudience"],
                      expires: DateTime.Now.AddHours(5),
                      claims: authClaims,
                      signingCredentials: new SigningCredentials(authSigninkey, SecurityAlgorithms.HmacSha256)
                      );
                return  Ok( new
                {
                     token =  new JwtSecurityTokenHandler().WriteToken( token),
                });
            }
            return Unauthorized();
        }

        #endregion Login as Admin oR Customer

        #region Register as Admin

        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExist = await userManager.FindByNameAsync(model.UserName);
            if (userExist != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Massage = "User Alrady Exist" });
            ApplicationUser user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            var result = await userManager.CreateAsync(user, model.Password);
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
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            return Ok(new Response { Status = "Success", Massage = "User Create Scuceful" });
        }

        #endregion Register as Admin

        #region Edit User By UserName
        [HttpPost]
        [Route("Edit")]
        public async Task<ApplicationUser> Edit([FromBody] RegisterModel model)
        {
            var result = await userManager.FindByEmailAsync(model.UserName);
            result.FirstName = model.FirstName;
            result.LastName = model.LastName;
            result.Address = model.Address;
            result.Email = model.Email;
            result.PhoneNumber = model.PhoneNumber;
            await userManager.UpdateAsync(result);
            return result;
        }
        #endregion

    }
}