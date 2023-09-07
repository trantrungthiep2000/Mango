using Mango.Services.AuthAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.AuthAPI.Data
{
    /// <summary>
    /// Information of application database context
    /// CreatedBy: ThiepTT(28/08/2023)
    /// </summary>
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// applicationUsers
        /// </summary>
        public DbSet<ApplicationUser> applicationUsers { get; set; }

        /// <summary>
        /// On model creating
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder</param>
        /// CreatedBy: ThiepTT(28/08/2023)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}