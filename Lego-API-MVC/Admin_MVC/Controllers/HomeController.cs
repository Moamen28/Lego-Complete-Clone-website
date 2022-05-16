using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USER_API.Authontaction;

namespace Admin_MVC.Models.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
