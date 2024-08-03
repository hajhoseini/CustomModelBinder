using CustomModelBinder.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CustomModelBinder.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //example : https://localhost:7121/home/AddUser?user=1|ali|66
        public IActionResult AddUser([ModelBinder(binderType:typeof(UserCustomModelBinder))] User newUser)
        {
            return View();
        }
    }
}