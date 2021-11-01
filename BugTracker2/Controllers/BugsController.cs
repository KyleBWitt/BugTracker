using BugTracker2.DataAccess;
using BugTracker2.Interfaces;
using BugTracker2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace BugTracker2.Controllers
{
    public class BugsController : Controller
    {
        private readonly IBugModel _bugModel;
        private readonly IdentityAppContext _context;
        private readonly ILogger<BugsController> _logger;

        public BugsController(ILogger<BugsController> logger, IdentityAppContext context, IBugModel bugModel)
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
            BugModel data = new()
            {     
                BugStatus = "New",
                BugDescription = bug.BugDescription, //Will be whatever is entered into description form              
                CreatedOn = DateTime.Now
            };
                    
            //Only sends if description is entered.  Was sending as soon as page loaded and sending NULL values to DB
            if(data.BugDescription != null)
            {
                _context.bugs.Add(data);
                _context.SaveChanges();
            };

            ModelState.Clear();
            return View();
        }

        //[HttpGet]
        public IActionResult BugHistory()
        {
            try
            {
                var results = _context.bugs.Where(b => b.BugID > 0).ToList();
                return View(results);
            }
            catch(Exception ex)
            {
                return (IActionResult)ex;
            }
           
        }

    }
}
