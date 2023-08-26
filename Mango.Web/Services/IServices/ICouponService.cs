using Mango.Web.Models;

namespace Mango.Web.Services.IServices
{
    /// <summary>
    /// Information of interface coupon service
    /// CreatedBy: ThiepTT(26/08/2023)
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    /// <typeparam name="K">Key</typeparam>
    public interface ICouponService<T, K> where T : class
    {
        /// <summary>
        /// Get coupon by code async
        /// </summary>
        /// <param name="couponCode">Code of coupon</param>
        /// <returns>Information of coupon</returns>
        /// CreatedBy: ThiepTT(26/08/2023)
        public Task<ResponseDto<T>> GetCouponByCodeAsync(string couponCode);

        /// <summary>
        /// Get all coupons async
        /// </summary>
        /// <returns>List of coupon</returns>
        /// CreatedBy: ThiepTT(26/08/2023)
        public Task<ResponseDto<IEnumerable<T>>> GetAllCouponsAsync();

        /// <summary>
        /// Get coupon by id async
        /// </summary>
        /// <param name="couponId">couponId</param>
        /// <returns>Information of coupon</returns>
        /// CreatedBy: ThiepTT(26/08/2023)
        public Task<ResponseDto<T>> GetCouponByIdAsync(int couponId);

        /// <summary>
        /// Create a coupon async
        /// </summary>
        /// <param name="couponDto">CouponDto</param>
        /// <returns>Number coupon create success</returns>
        /// CreatedBy: ThiepTT(26/08/2023)
        public Task<ResponseDto<K>> CreateCouponAsync(CouponDto couponDto);

        /// <summary>
        /// Update a coupon async
        /// </summary>
        /// <param name="couponDto">CouponDto</param>
        /// <param name="couponId">Id of coupon</param>
        /// <returns>Number coupon update success</returns>
        /// CreatedBy: ThiepTT(26/08/2023)
        public Task<ResponseDto<K>> UpdateCouponAsync(CouponDto couponDto, int couponId);

        /// <summary>
        /// Delete a coupon async
        /// </summary>
        /// <param name="couponId">Id of coupon</param>
        /// <returns>number coupon delete success</returns>
        /// CreatedBy: ThiepTT(26/08/2023)
        public Task<ResponseDto<K>> DeleteCouponAsync(int couponId);
    }
}
