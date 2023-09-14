using Mango.Services.EmailAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.EmailAPI.Data
{
    /// <summary>
    /// Information of application database context
    /// CreatedBy: ThiepTT(13/09/2023)
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Email loggers
        /// </summary>
        public DbSet<EmailLogger> EmailLoggers { get; set; }
    }
}