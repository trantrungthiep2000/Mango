using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Mango.Web.Utility;

namespace Mango.Web.Services
{
    /// <summary>
    /// information of cart serivce
    /// CreatedBy: ThiepTT(12/09/2023)
    /// </summary>
    public class CartService : ICartService
    {
        private readonly IBaseService _baseService;

        public CartService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        /// <summary>
        /// Get cart by user id async
        /// </summary>
        /// <param name="userId">Id of user</param>
        /// <returns>ResponseDto</returns>
        /// CreatedBy: ThiepTT(12/09/2023)
        public async Task<ResponseDto?> GetCartByUserIdAsync(string userId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ShoppingCartAPIBase + $"/api/Carts/GetCart/{userId}",
            });
        }

        /// <summary>
        /// Apply coupon async
        /// </summary>
        /// <param name="cartDto">CartDto</param>
        /// <returns>ResponseDto</returns>
        /// CreatedBy: ThiepTT(12/09/2023)
        public async Task<ResponseDto?> ApplyCouponAsync(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Url = SD.ShoppingCartAPIBase + "/api/Carts/ApplyCoupon",
                Data = cartDto,
            });
        }

        /// <summary>
        /// Cart upsert async
        /// </summary>
        /// <param name="cartDto">CartDto</param>
        /// <returns>ResponseDto</returns>
        /// CreatedBy: ThiepTT(12/09/2023)
        public async Task<ResponseDto?> CartUpsertAsync(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Url = SD.ShoppingCartAPIBase + "/api/Carts/CartUpsert",
                Data = cartDto,
            });
        }

        /// <summary>
        /// Remove from cart async
        /// </summary>
        /// <param name="cartDetailsId">Id of cart details</param>
        /// <returns>ResponseDto</returns>
        /// CreatedBy: ThiepTT(12/09/2023)
        public async Task<ResponseDto?> RemoveFromCartAsync(int cartDetailsId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ShoppingCartAPIBase + $"/api/Carts/RemoveCart/{cartDetailsId}",
            });
        }
    }
}
