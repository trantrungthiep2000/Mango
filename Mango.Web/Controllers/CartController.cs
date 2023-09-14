using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace Mango.Web.Controllers
{
    /// <summary>
    /// Information of cart controller
    /// CreatedBy: ThiepTT(12/09/2023)
    /// </summary>
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        /// <summary>
        /// Cart index
        /// </summary>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(12/09/2023)
        [Authorize]
        public async Task<IActionResult> CartIndex()
        {
            return View(await LoadCartDtoBasedOnLoggedInUser());
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="cartDetailsId">Id of cart details</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(12/09/2023)
        public async Task<IActionResult> Remove(int cartDetailsId)
        {
            var response = await _cartService.RemoveFromCartAsync(cartDetailsId);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Cart updated successfully";
                return RedirectToAction(nameof(CartIndex));
            }

            return View();
        }

        /// <summary>
        /// Apply coupon
        /// </summary>
        /// <param name="cartDto">CartDto</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(12/09/2023)
        [HttpPost]
        public async Task<IActionResult> ApplyCoupon(CartDto cartDto)
        {
            var response = await _cartService.ApplyCouponAsync(cartDto);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Cart updated successfully";
                return RedirectToAction(nameof(CartIndex));
            }

            return View();
        }

        /// <summary>
        /// Email cart
        /// </summary>
        /// <param name="cartDto">CartDto</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(13/09/2023)
        [HttpPost]
        public async Task<IActionResult> EmailCart(CartDto cartDto)
        {
            var cart = await LoadCartDtoBasedOnLoggedInUser();
            cart.CartHeader!.Email = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Email)?.FirstOrDefault()?.Value!;
            var response = await _cartService.EmailCartAsync(cart);
           
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Email will be processed and sent shortly";
                return RedirectToAction(nameof(CartIndex));
            }

            return View();
        }

        /// <summary>
        /// Remove coupon
        /// </summary>
        /// <param name="cartDto">CartDto</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(12/09/2023)
        [HttpPost]
        public async Task<IActionResult> RemoveCoupon(CartDto cartDto)
        {
            cartDto.CartHeader!.CouponCode = string.Empty;
            var response = await _cartService.ApplyCouponAsync(cartDto);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Cart updated successfully";
                return RedirectToAction(nameof(CartIndex));
            }

            return View();
        }

        /// <summary>
        /// Load cart dto based on logged in user
        /// </summary>
        /// <returns>Information of cartdto</returns>
        /// CreatedBy: ThiepTT(12/09/2023)
        private async Task<CartDto> LoadCartDtoBasedOnLoggedInUser()
        {
            var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            var response = await _cartService.GetCartByUserIdAsync(userId!);

            if (response != null && response.IsSuccess)
            {
                var cart = JsonConvert.DeserializeObject<CartDto>(Convert.ToString(response.Result)!);
                return cart!;
            }

            return new CartDto();
        }
    }
}
