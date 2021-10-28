using Microsoft.EntityFrameworkCore;
using BugTracker2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BugTracker2.DataAccess
{
    public class AppDbContext : DbContext
    {
        ///All of this was implemented for EF
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

    }

    
}
