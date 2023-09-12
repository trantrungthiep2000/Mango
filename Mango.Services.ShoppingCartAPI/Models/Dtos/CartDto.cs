namespace Mango.Services.ShoppingCartAPI.Models.Dtos
{
    /// <summary>
    /// Information of cart dto
    /// CreatedBy: ThiepTT(11/09/2023)
    /// </summary>
    public class CartDto
    {
        /// <summary>
        /// Cart header
        /// </summary>
        public CartHeader? CartHeader { get; set; }

        /// <summary>
        /// List cart details
        /// </summary>
        public IEnumerable<CartDetails>? CartDetails { get; set; }
    }
}
