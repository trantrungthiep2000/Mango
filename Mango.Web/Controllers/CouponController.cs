using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    /// <summary>
    /// Information of coupon controller
    /// CreatedBy: ThiepTT(27/08/2023)
    /// </summary>
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        /// <summary>
        /// Coupon index
        /// </summary>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(27/08/2023)
        public async Task<IActionResult> CouponIndex()
        {
            var coupons = new List<Coupon>();

            var response = await _couponService.GetAllCouponsAsync();

            if (response != null && response.IsSuccess)
            {
                coupons = JsonConvert.DeserializeObject<List<Coupon>>(Convert.ToString(response.Result)!);
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(coupons);
        }

        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto couponDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _couponService.CreateCouponAsync(couponDto);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Coupon created successfully";
                    return RedirectToAction(nameof(CouponIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }

            return View(couponDto);
        }

        public async Task<IActionResult> CouponDelete(int couponId)
        {
            var response = await _couponService.GetCouponByIdAsync(couponId);

            if (response != null && response.IsSuccess)
            {
                var coupon = JsonConvert.DeserializeObject<Coupon>(Convert.ToString(response.Result)!);

                return View(coupon);
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CouponDelete(Coupon coupon)
        {
            var response = await _couponService.DeleteCouponAsync(coupon);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Coupon deleted successfully";
                return RedirectToAction(nameof(CouponIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(coupon);
        }
    }
}
