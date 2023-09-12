namespace Mango.Web.Models
{
    /// <summary>
    /// Information of cart header
    /// CreatedBy: ThiepTT(12/09/2023)
    /// </summary>
    public class CartHeader
    {
        /// <summary>
        /// Id of cart header
        /// </summary>
        public int CartHeaderId { get; set; }

        /// <summary>
        /// Id of user
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Code of coupon
        /// </summary>
        public string CouponCode { get; set; } = string.Empty;

        /// <summary>
        /// Discount
        /// </summary>
        public double Discount { get; set; }

        /// <summary>
        /// CartTotal
        /// </summary>
        public double CartTotal { get; set; }
    }
}