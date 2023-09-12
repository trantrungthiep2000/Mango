using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Services.ShoppingCartAPI.Models.Dtos
{
    /// <summary>
    /// Information of cart header dto
    /// CreatedBy: ThiepTT(11/09/2023)
    /// </summary>
    public class CartHeaderDto
    {
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
