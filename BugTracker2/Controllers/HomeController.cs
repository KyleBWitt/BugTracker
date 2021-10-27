using BugTracker2.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BugTracker2.DataAccess;
using System.Data;
using BugTracker2.Interfaces;

namespace BugTracker2.Controllers
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
            //This CreateBug worked.  Need to figure out how to get input from from and use this method

            //BugProcessor.CreateBug("New", "Testing another CreateBug through just calling the function in the IActionResult instead of having the whole logic there");
            _logger.LogInformation($"Testing _logger injection");
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
    }
}
