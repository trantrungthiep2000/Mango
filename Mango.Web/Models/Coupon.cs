namespace Mango.Web.Models
{
    /// <summary>
    /// Information of coupon
    /// CreatedBy: ThiepTT(26/08/2023)
    /// </summary>
    public class Coupon
    {
        /// <summary>
        /// Id of coupon
        /// </summary>
        public int CouponId { get; set; }

        /// <summary>
        /// Code of coupon
        /// </summary>
        public string CouponCode { get; set; } = string.Empty;

        /// <summary>
        /// Discount amount
        /// </summary>
        public double DiscountAmount { get; set; }

        /// <summary>
        /// Min amount
        /// </summary>
        public int MinAmount { get; set; }
    }
}
