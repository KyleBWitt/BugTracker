using BugTracker2.DataAccess;
using BugTracker2.Interfaces;
using BugTracker2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker2.Controllers
{
    public class BugsController : Controller
    {

        private readonly IBugModel _bugModel;
        private readonly ILogger<BugsController> _logger;
        private readonly AppDbContext _context;

        public BugsController(ILogger<BugsController> logger, AppDbContext context, IBugModel bugModel)
        {
            _logger = logger;
            _context = context;
            _bugModel = bugModel;

        }

        public IActionResult Index()
        {
            return View();
        }
        
        //[HttpPost]
        public IActionResult SubmitTicket(BugModel bug)
        {
            //BugModel Object created for insert into query
            BugModel data = new()
            {
                 BugStatus = "New",
                BugDescription = bug.BugDescription //Will be whatever is entered into description form              
            };
                    
            //Only sends if description is entered.  Was sending as soon as page loaded and sending NULL values to DB
            if(data.BugDescription != null)
            {
                BugModel.CreateBug(data);
            };

            //Clears bug description submission form
            ModelState.Clear();
            return View();
        }

        //Get Bugs
        public IActionResult BugHistory()
        {
            return View();
        }

    }
}
