using GOT.Data;
using GOT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GOT.Controllers
{
    public class HomeController : Controller
    {
        private readonly GotDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private static bool isLogged = false;


        public HomeController(ILogger<HomeController> logger, GotDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            if (isLogged)
            {
                SetCookie("isLogged", "logged", 600000);
            }
            else
            {
                SetCookie("isLogged", "logout", 600000);
            }

            return View();
        }

        public IActionResult AdminPanel()
        {
            return View();
        }


        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogIn(string login, string password)
        {
            if (login != null && password != null)
            {
                var gotDbContext = _context.Tourists;
                var searchedUser = gotDbContext.FirstOrDefault(u => u.Login == login);

                if (searchedUser.Password == password)
                {
                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(searchedUser));
                    isLogged = true;
                    SetCookie("isLogged", "logged", 600000);

                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        public IActionResult Logout()
        {
            isLogged = false;

            SetCookie("isLogged", "logout", 600000);

            return RedirectToAction("Index");
        }


        public void SetCookie(string key, string value, int? numberOfSeconds = null)
        {
            CookieOptions option = new CookieOptions();
            if (numberOfSeconds.HasValue)
                option.Expires = DateTime.Now.AddSeconds(numberOfSeconds.Value);
            Response.Cookies.Append(key, value, option);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
