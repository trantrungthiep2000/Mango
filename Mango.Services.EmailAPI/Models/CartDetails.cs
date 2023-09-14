namespace Mango.Services.EmailAPI.Models
{
    /// <summary>
    /// Information of cart details
    /// CreatedBy: ThiepTT(13/09/2023)
    /// </summary>
    public class CartDetails
    {
        /// <summary>
        /// Id of cart details
        /// </summary>
        public int CartDetailsId { get; set; }

        /// <summary>
        /// Id of cart header
        /// </summary>
        public int CartHeaderId { get; set; }

        /// <summary>
        /// Cart header
        /// </summary>
        public CartHeader? CartHeader { get; set; }

        /// <summary>
        /// Id of product
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Product
        /// </summary>
        public Product? Product { get; set; }

        /// <summary>
        /// Count
        /// </summary>
        public int Count { get; set; }
    }
}