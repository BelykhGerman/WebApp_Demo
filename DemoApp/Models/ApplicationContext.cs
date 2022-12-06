using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Models {

    public class ApplicationContext : IdentityDbContext {
        public DbSet<IdentityUser> IdentityUsers { get; set; } = null!;

        public ApplicationContext( DbContextOptions<ApplicationContext> options )
            : base ( options ) {
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder ) {
            base.OnModelCreating ( modelBuilder );
        }
    }
}