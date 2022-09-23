using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsWithRouting.Models;
using System.Diagnostics;
using ProductsWithRouting.Services;

namespace ProductsWithRouting.Controllers
{
    public class UsersController : Controller
    {
        private List<User> myUsers;

        public UsersController(Data data)
        {
            myUsers = data.Users;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("PasswordInput");
        }

        [HttpPost]
        public IActionResult Index(Password id)
        {
            if (!(id.password is "df2323eoT")) return Unauthorized();
            return View(myUsers);
        }

        public IActionResult PasswordInput()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
