using Mango.Services.ShoppingCartAPI.Models;
using Mango.Services.ShoppingCartAPI.Models.Dtos;
using Mango.Services.ShoppingCartAPI.Services.IServices;
using Newtonsoft.Json;

namespace Mango.Services.ShoppingCartAPI.Services
{
    /// <summary>
    /// Information of coupon service
    /// CreatedBy: ThiepTT(12/09/2023)
    /// </summary>
    public class CouponService : ICouponService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CouponService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Get coupon by code
        /// </summary>
        /// <param name="couponCode">Code of coupon</param>
        /// <returns>Coupon</returns>
        /// CreatedBy: ThiepTT(12/09/2023)
        public async Task<Coupon> GetCouponByCode(string couponCode)
        {
            var client = _httpClientFactory.CreateClient("Coupon");
            var response = await client.GetAsync($"/api/Coupons/GetCouponByCode/{couponCode}");
            var apiContent = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<ResponseDto>(apiContent);

            if (res != null && res.IsSuccess)
            {
                return JsonConvert.DeserializeObject<Coupon>(Convert.ToString(res.Result)!)!;
            }

            return new Coupon();
        }
    }
}
