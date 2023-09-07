using Mango.Web.Models;

namespace Mango.Web.Services.IServices
{
    /// <summary>
    /// Information of interface product service
    /// CreatedBy: ThiepTT(06/09/2023)
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Get all products async
        /// </summary>
        /// <returns>List of product</returns>
        /// CreatedBy: ThiepTT(06/09/2023)
        public Task<ResponseDto?> GetAllProductsAsync();

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="productId">Id of product</param>
        /// <returns>Information of product</returns>
        /// CreatedBy: ThiepTT(06/09/2023)
        public Task<ResponseDto?> GetProductByIdAsync(int productId);

        /// <summary>
        /// Create a product async
        /// </summary>
        /// <param name="productDto">ProductDto</param>
        /// <returns>Number product create success</returns>
        /// CreatedBy: ThiepTT(06/09/2023)
        public Task<ResponseDto?> CreateProductAsync(ProductDto productDto);

        /// <summary>
        /// Update a product async
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>Number product update success</returns>
        /// CreatedBy: ThiepTT(06/09/2023)
        public Task<ResponseDto?> UpdateProductAsync(Product product);

        /// <summary>
        /// Delete a product async
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>Number product delete success</returns>
        /// CreatedBy: ThiepTT(06/09/2023)
        public Task<ResponseDto?> DeleteProductAsync(Product product);
    }
}
