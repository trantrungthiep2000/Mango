using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Mango.Web.Utility;

namespace Mango.Web.Services
{
    /// <summary>
    /// Information of product service
    /// CreatedBy: ThiepTT(06/09/2023)
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;

        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        /// <summary>
        /// Get all products async
        /// </summary>
        /// <returns>List of product</returns>
        /// CreatedBy: ThiepTT(07/09/2023)
        public async Task<ResponseDto?> GetAllProductsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/Products/GetAllProducts",
            });
        }

        /// <summary>
        /// Get product by id async
        /// </summary>
        /// <param name="productId">Id of product</param>
        /// <returns>Information of product</returns>
        /// CreatedBy: ThiepTT(07/09/2023)
        public async Task<ResponseDto?> GetProductByIdAsync(int productId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + $"/api/Products/GetProductById/{productId}",
            });
        }

        /// <summary>
        /// Create a product async
        /// </summary>
        /// <param name="productDto">ProductDto</param>
        /// <returns>Number product create success</returns>
        /// CreatedBy: ThiepTT(07/09/2023)
        public async Task<ResponseDto?> CreateProductAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Url = SD.ProductAPIBase + "/api/Products/CreateProduct",
                Data = productDto,
            });
        }

        /// <summary>
        /// Update a product async
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>Number product update success</returns>
        /// CreatedBy: ThiepTT(07/09/2023)
        public async Task<ResponseDto?> UpdateProductAsync(Product product)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Url = SD.ProductAPIBase + $"/api/Products/UpdateProduct/{product.ProductId}",
                Data = product,
            });
        }

        /// <summary>
        /// Delete a product async
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>Number product delete success</returns>
        /// CreatedBy: ThiepTT(07/09/2023)
        public async Task<ResponseDto?> DeleteProductAsync(Product product)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ProductAPIBase + $"/api/Products/DeleteProduct/{product.ProductId}",
            });
        }
    }
}
