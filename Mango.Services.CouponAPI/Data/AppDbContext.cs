using Mango.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.CouponAPI.Data
{
    /// <summary>
    /// Information of application database context
    /// CreatedBy: ThiepTT(24/08/2023)
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Coupons
        /// </summary>
        public DbSet<Coupon> Coupons { get; set; }

        /// <summary>
        /// On model creating
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder</param>
        /// CreatedBy: ThiepTT(24/08/2023)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData( new Coupon
            {
                CouponId = 1,
                CouponCode = "10OFF",
                DiscountAmount = 10,
                MinAmount = 20,
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = "20OFF",
                DiscountAmount = 20,
                MinAmount = 40,
            });
        }
    }
}
