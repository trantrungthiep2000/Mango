namespace Mango.Services.ShoppingCartAPI.Models.Dtos
{
    /// <summary>
    /// Information of coupon dto
    /// CreatedBy: ThiepTT(11/09/2023)
    /// </summary>
    public class CouponDto
    {
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
