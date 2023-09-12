using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Services.ShoppingCartAPI.Models
{
    /// <summary>
    /// Information of cart header
    /// CreatedBy: ThiepTT(11/09/2023)
    /// </summary>
    public class CartHeader
    {
        /// <summary>
        /// Id of cart header
        /// </summary>
        [Key]
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
        [NotMapped]
        public double Discount { get; set; }

        /// <summary>
        /// CartTotal
        /// </summary>
        [NotMapped]
        public double CartTotal { get; set; }
    }
}