using BugTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace BugTracker.DataAccess
{
    public class IdentityAppContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public IdentityAppContext()
        {
        }

        public IdentityAppContext(DbContextOptions<IdentityAppContext> options) : base(options)
        {
        }

        public DbSet<BugModel> bugs { get; set; }
        public DbSet<UserModel> users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
    }
}
