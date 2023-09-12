using Mango.Services.ShoppingCartAPI.Models;
using Mango.Services.ShoppingCartAPI.Models.Dtos;
using Mango.Services.ShoppingCartAPI.Services.IServices;
using Newtonsoft.Json;

namespace Mango.Services.ShoppingCartAPI.Services
{
    /// <summary>
    /// Information of product service
    /// CreatedBy: ThiepTT(12/09/2023)
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Get products
        /// </summary>
        /// <returns>List of product</returns>
        /// CreatedBy: ThiepTT(12/09/2023)
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var client = _httpClientFactory.CreateClient("Product");
            var response = await client.GetAsync("/api/Products/GetAllProducts");
            var apiContent = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<ResponseDto>(apiContent);

            if (res!.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Product>>(Convert.ToString(res.Result)!)!;
            }

            return new List<Product>(); 
        }
    }
}