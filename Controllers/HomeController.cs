using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TacocatModelTest.Models;

namespace TacocatModelTest.Controllers
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

        public IActionResult Tacocat(Taco model)
        {
            return View(model);
        }


        [HttpPost]
        public IActionResult Tacocat(string input)
        {
            var tacoModel = new Taco
            {
                Input = input
            };

            var result = tacoModel.Input.ToLower().Replace(" ", "");
            var reverse = string.Join("", result.Reverse().ToArray());
            if (reverse == result )
            {
                tacoModel.Output = $"{input} is a palindrome";
            }
            else 
            {
                tacoModel.Output = $"{input} is not a palindrome";
            } 
            return RedirectToAction("Tacocat", tacoModel);
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
