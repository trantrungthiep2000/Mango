using Mango.Services.ShoppingCartAPI.Models;

namespace Mango.Services.ShoppingCartAPI.Services.IServices
{
    /// <summary>
    /// Information of interface coupon service
    /// CreatedBy: ThiepTT(12/09/2023)
    /// </summary>
    public interface ICouponService
    {
        /// <summary>
        /// Get coupon by code
        /// </summary>
        /// <param name="couponCode">Code of coupon</param>
        /// <returns>Information of coupon</returns>
        /// CreatedBy: ThiepTT(12/09/2023)
        public Task<Coupon> GetCouponByCode(string couponCode);
    }
}
