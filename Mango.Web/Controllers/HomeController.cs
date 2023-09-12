using IdentityModel;
using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Mango.Web.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Mango.Web.Controllers
{
    /// <summary>
    /// Information of home controller
    /// CreatedBy: ThiepTT(07/09/2023)
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, ICartService cartService)
        {
            _logger = logger;
            _productService = productService;
            _cartService = cartService;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(07/09/2023)
        public async Task<IActionResult> Index()
        {
            var products = new List<Product>();

            var response = await _productService.GetAllProductsAsync();

            if (response != null && response.IsSuccess)
            {
                products = JsonConvert.DeserializeObject<List<Product>>(Convert.ToString(response.Result)!);
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(products);
        }

        /// <summary>
        /// Product details
        /// </summary>
        /// <param name="productId">Id of product</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(11/09/2023)
        [Authorize]
        public async Task<IActionResult> ProductDetails(int productId)
        {
            var product = new Product();

            var response = await _productService.GetProductByIdAsync(productId);

            if (response != null && response.IsSuccess)
            {
                product = JsonConvert.DeserializeObject<Product>(Convert.ToString(response.Result)!);
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(product);
        }

        /// <summary>
        /// Product details
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(12/09/2023)
        [Authorize]
        [HttpPost]
        [ActionName("ProductDetails")]
        public async Task<IActionResult> ProductDetails(Product product)
        {
            var cart = new CartDto()
            {
                CartHeader = new CartHeader()
                {
                    UserId = User.Claims.Where(u => u.Type == JwtClaimTypes.Subject)?.FirstOrDefault()?.Value!,
                }
            };

            var cartDetails = new CartDetails()
            {
                Count = product.Count,
                ProductId = product.ProductId,
            };

            var listCarrtDetails = new List<CartDetails>() { cartDetails };
            cart.CartDetails = listCarrtDetails;
            var response = await _cartService.CartUpsertAsync(cart);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Item has been added to the Shopping Cart";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(product);
        }

        [Authorize(Roles = SD.RoleAdmin)]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}