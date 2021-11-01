using BugTracker2.DataAccess;
using BugTracker2.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BugTracker2.Models
{
    public class BugModel : IBugModel
    {

        private readonly IdentityAppContext _context;

        public BugModel()
        {
        }

        public BugModel(IdentityAppContext context)
        {
            _context = context;
        }

        [Key]
        public int BugID { get; set; }
        public string BugStatus { get; set; }
        public string BugDescription { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
