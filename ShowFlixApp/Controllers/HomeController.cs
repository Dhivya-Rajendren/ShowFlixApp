using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShowFlixApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShowFlixApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //string,int, list , array
        
        public IActionResult Index()
        {
        
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }


    
    }
}
