using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudyingMvcCore.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StudyingMvcCore.App.Controllers
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

        [Route("Home/Error/{id:length(3,3)}")]
        public IActionResult Errors(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Message = "Error!";
                modelErro.Title = "Ocorreu um erro!";
                modelErro.ErrorCode = id;
            }
            else if (id == 404)
            {
                modelErro.Message = "The page does not exist!";
                modelErro.Title = "Page not found!";
                modelErro.ErrorCode = id;
            }
            else if (id == 403)
            {
                modelErro.Message = "Your're not allowed to do it.";
                modelErro.Title = "Access denied!";
                modelErro.ErrorCode = id;
            }
            else
            {
                return StatusCode(500);
            }

            return View("Error", modelErro);
        }
    }
}
