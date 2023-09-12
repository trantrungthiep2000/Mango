using Mango.Services.ShoppingCartAPI.Models;

namespace Mango.Services.ShoppingCartAPI.Services.IServices
{
    /// <summary>
    /// Information of interface product service
    /// CreatedBy: ThiepTT(12/09/2023)
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Get products
        /// </summary>
        /// <returns>List of product</returns>
        /// CreatedBy: ThiepTT(12/09/2023)
        public Task<IEnumerable<Product>> GetProducts();
    }
}
