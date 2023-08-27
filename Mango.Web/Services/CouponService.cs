using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Mango.Web.Utility;

namespace Mango.Web.Services
{
    /// <summary>
    /// Information of coupon service
    /// CreatedBy: ThiepTT(27/08/2023)
    /// </summary>
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {

            _baseService = baseService;
        }

        /// <summary>
        /// Get coupon by code async
        /// </summary>
        /// <param name="couponCode">Code of coupon</param>
        /// <returns>Information of coupon</returns>
        /// CreatedBy: ThiepTT(27/08/2023)
        public async Task<ResponseDto?> GetCouponByCodeAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + $"/api/Coupons/GetCouponByCode/{couponCode}",
            });
        }

        /// <summary>
        /// Get all coupons async
        /// </summary>
        /// <returns>List of coupon</returns>
        /// CreatedBy: ThiepTT(27/08/2023)
        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/Coupons/GetAllCoupons",
            });
        }

        /// <summary>
        /// Get coupon by id async
        /// </summary>
        /// <param name="couponId">Id of coupon</param>
        /// <returns>Information of coupon</returns>
        /// CreatedBy: ThiepTT(27/08/2023)
        public async Task<ResponseDto?> GetCouponByIdAsync(int couponId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + $"/api/Coupons/GetCouponById/{couponId}",
            });
        }

        /// <summary>
        /// Create a coupon async
        /// </summary>
        /// <param name="couponDto">CouponDto</param>
        /// <returns>Number coupon create success</returns>
        /// CreatedBy: ThiepTT(27/08/2023)
        public async Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Url = SD.CouponAPIBase + "/api/Coupons/CreateCoupon",
                Data = couponDto,
            });
        }

        /// <summary>
        /// Update a coupon async
        /// </summary>
        /// <param name="couponDto">CouponDto</param>
        /// <param name="couponId">Id of coupon</param>
        /// <returns>Number coupon update success</returns>
        /// CreatedBy: ThiepTT(27/08/2023)
        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto, int couponId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Url = SD.CouponAPIBase + $"/api/Coupons/UpdateCoupon/{couponId}",
                Data = couponDto,
            });
        }

        /// <summary>
        /// Delete a coupon async
        /// </summary>
        /// <param name="coupon">Coupon</param>
        /// <returns>Number coupon delete success</returns>
        /// CreatedBy: ThiepTT(27/08/2023)
        public async Task<ResponseDto?> DeleteCouponAsync(Coupon coupon)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CouponAPIBase + $"/api/Coupons/DeleteCoupon/{coupon.CouponId}",
            });
        }
    }
}
