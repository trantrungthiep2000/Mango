using Mango.Web.Models;

namespace Mango.Web.Services.IServices
{
    /// <summary>
    /// Information of interface coupon service
    /// CreatedBy: ThiepTT(26/08/2023)
    /// </summary>
    public interface ICouponService
    {
        /// <summary>
        /// Get coupon by code async
        /// </summary>
        /// <param name="couponCode">Code of coupon</param>
        /// <returns>Information of coupon</returns>
        /// CreatedBy: ThiepTT(26/08/2023)
        public Task<ResponseDto?> GetCouponByCodeAsync(string couponCode);

        /// <summary>
        /// Get all coupons async
        /// </summary>
        /// <returns>List of coupon</returns>
        /// CreatedBy: ThiepTT(26/08/2023)
        public Task<ResponseDto?> GetAllCouponsAsync();

        /// <summary>
        /// Get coupon by id async
        /// </summary>
        /// <param name="couponId">couponId</param>
        /// <returns>Information of coupon</returns>
        /// CreatedBy: ThiepTT(26/08/2023)
        public Task<ResponseDto?> GetCouponByIdAsync(int couponId);

        /// <summary>
        /// Create a coupon async
        /// </summary>
        /// <param name="couponDto">CouponDto</param>
        /// <returns>Number coupon create success</returns>
        /// CreatedBy: ThiepTT(26/08/2023)
        public Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto);

        /// <summary>
        /// Update a coupon async
        /// </summary>
        /// <param name="couponDto">CouponDto</param>
        /// <param name="couponId">Id of coupon</param>
        /// <returns>Number coupon update success</returns>
        /// CreatedBy: ThiepTT(26/08/2023)
        public Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto, int couponId);

        /// <summary>
        /// Delete a coupon async
        /// </summary>
        /// <param name="couponId">Id of coupon</param>
        /// <returns>number coupon delete success</returns>
        /// CreatedBy: ThiepTT(26/08/2023)
        public Task<ResponseDto?> DeleteCouponAsync(Coupon coupon);
    }
}
