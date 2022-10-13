using BugTracker.DataAccess;
using BugTracker.Interfaces;
using BugTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace BugTracker.Controllers
{
    public class BugsController : Controller
    {
        private readonly IBoardItemModel _boardItemModel;
        private readonly IdentityAppContext _context;
        private readonly ILogger<BugsController> _logger;

        public BugsController(ILogger<BugsController> logger, IdentityAppContext context, IBoardItemModel boardItemModel)
        {
            _logger = logger;
            _context = context;
            _boardItemModel = boardItemModel;
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
                BugStatus = "New", //All bugs created will default to new, so this is hardcoded
                BugDescription = bug.BugDescription, //Will be whatever is entered into description form              
                CreatedOn = DateTime.Now,
                CreatedBy = User.Identity.Name //Takes in current logged in user to be "CreatedBy" in the table
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
        public IActionResult BugBoard()
        {
            try
            {
                var results = _context.bugs.Where(b => b.BugID > 0).ToList();
                return View(results);
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }
    }
}
