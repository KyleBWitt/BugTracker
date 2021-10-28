using BugTracker2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BugTracker2.DataAccess
{
    public class IdentityAppContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public IdentityAppContext(DbContextOptions<IdentityAppContext> options) : base(options)
        {
            
        }
    }
}
