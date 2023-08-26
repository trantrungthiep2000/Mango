using Mango.Web.Models;
using Mango.Web.Services.IServices;

namespace Mango.Web.Services
{
    public class CouponService : ICouponService<Coupon, int>
    {
        private readonly IBaseService<Coupon> _baseService;

        public CouponService(IBaseService<Coupon> baseService)
        {

            _baseService = baseService;
        }

        public Task<ResponseDto<int>> CreateCouponAsync(CouponDto couponDto)
        {
        }
        public Task<ResponseDto<int>> DeleteCouponAsync(int couponId)
        {
        }

        public Task<ResponseDto<IEnumerable<Coupon>>> GetAllCouponsAsync()
        {
        }

        public Task<ResponseDto<Coupon>> GetCouponByCodeAsync(string couponCode)
        {
        }

        public Task<ResponseDto<Coupon>> GetCouponByIdAsync(int couponId)
        {
        }

        public Task<ResponseDto<int>> UpdateCouponAsync(CouponDto couponDto, int couponId)
        {
        }
    }
}
