using BugTracker.DataAccess;
using BugTracker.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class BugModel : IBoardItemModel
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
        public string CreatedBy { get; set; }

    }
}
