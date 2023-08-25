using System.ComponentModel.DataAnnotations;

namespace Mango.Services.CouponAPI.Models
{
    /// <summary>
    /// Information of coupon
    /// CreatedBy: ThiepTT(24/08/2023)
    /// </summary>
    public class Coupon
    {
        /// <summary>
        /// Id of coupon
        /// </summary>
        [Key]
        public int CouponId { get; set; }

        /// <summary>
        /// Code of coupon
        /// </summary>
        [Required]
        public string CouponCode { get; set; } = string.Empty;

        /// <summary>
        /// Discount amount
        /// </summary>
        [Required]
        public double DiscountAmount { get; set; }

        /// <summary>
        /// Min amount
        /// </summary>
        public int MinAmount { get; set; }
    }
}
