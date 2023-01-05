using DemoApp.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Core.DAL {

    public class ApplicationContext : IdentityDbContext {
        public DbSet<IdentityUser> IdentityUsers { get; set; } = null!;
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Friend> Friends { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;

        public ApplicationContext( DbContextOptions<ApplicationContext> options )
            : base ( options ) {
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder ) {
            base.OnModelCreating ( modelBuilder );
        }
    }
}