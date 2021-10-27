using Microsoft.EntityFrameworkCore;
using BugTracker2.Models;

namespace BugTracker2.DataAccess
{
    public class AppDbContext : DbContext
    {
        ///All of this was implemented for EF
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<BugModel> Bugs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BugModel>().HasNoKey();
            modelBuilder.Entity<UserModel>().HasNoKey();

        }
    }

    
}
