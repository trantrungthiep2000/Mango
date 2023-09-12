using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Services.ShoppingCartAPI.Models
{
    /// <summary>
    /// Information of cart details
    /// CreatedBy: ThiepTT(11/09/2023)
    /// </summary>
    public class CartDetails
    {
        /// <summary>
        /// Id of cart details
        /// </summary>
        [Key]
        public int CartDetailsId { get; set; }

        /// <summary>
        /// Id of cart header
        /// </summary>
        public int CartHeaderId { get; set; }

        /// <summary>
        /// Cart header
        /// </summary>
        [ForeignKey("CartHeaderId")]
        public CartHeader? CartHeader { get; set; }

        /// <summary>
        /// Id of product
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Product
        /// </summary>
        [NotMapped]
        public Product? Product { get; set; }

        /// <summary>
        /// Count
        /// </summary>
        public int Count { get; set; }
    }
}
