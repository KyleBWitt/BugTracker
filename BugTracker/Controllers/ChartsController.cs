﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    public class ChartsController : Controller
    {
        public IActionResult ChartDisplay()
        {
            return View();
        }
    }
}
