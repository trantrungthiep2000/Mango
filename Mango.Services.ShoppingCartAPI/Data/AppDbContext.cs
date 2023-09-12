using Mango.Services.ShoppingCartAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ShoppingCartAPI.Data
{
    /// <summary>
    /// Information of application database context
    /// CreatedBy: ThiepTT(11/09/2023)
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Cart headers
        /// </summary>
        public DbSet<CartHeader> CartHeaders { get; set; }

        /// <summary>
        /// Cart details
        /// </summary>
        public DbSet<CartDetails> CartDetails { get; set; }
    }
}
