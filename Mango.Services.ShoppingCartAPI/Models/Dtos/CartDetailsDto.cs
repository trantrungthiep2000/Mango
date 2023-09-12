namespace Mango.Services.ShoppingCartAPI.Models.Dtos
{
    /// <summary>
    /// Information of cart details dto
    /// CreatedBy: ThiepTT(11/09/2023)
    /// </summary>
    public class CartDetailsDto
    {
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