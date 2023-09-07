using Mango.Web.Models;
using Mango.Web.Services;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    /// <summary>
    /// Information of product controller
    /// CreatedBy: ThiepTT(07/09/2023)
    /// </summary>
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Product index
        /// </summary>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(07/09/2023)
        public async Task<IActionResult> ProductIndex()
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
        /// Product create
        /// </summary>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(07/09/2023)
        public IActionResult ProductCreate()
        {
            return View();
        }

        /// <summary>
        /// Product create
        /// </summary>
        /// <param name="productDto">ProductDto</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(07/09/2023)
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProductAsync(productDto);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Product created successfully";
                    return RedirectToAction(nameof(ProductIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }

            return View(productDto);
        }

        /// <summary>
        /// Product edit
        /// </summary>
        /// <param name="productId">Id of product</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(07/09/2023)
        public async Task<IActionResult> ProductEdit(int productId)
        {
            var response = await _productService.GetProductByIdAsync(productId);

            if (response != null && response.IsSuccess)
            {
                var product = JsonConvert.DeserializeObject<Product>(Convert.ToString(response.Result)!);

                return View(product);
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return NotFound();
        }

        /// <summary>
        /// Product edit
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(07/09/2023)
        [HttpPost]
        public async Task<IActionResult> ProductEdit(Product product)
        {
            var response = await _productService.UpdateProductAsync(product);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Product updated successfully";
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(product);
        }

        /// <summary>
        /// Product edit
        /// </summary>
        /// <param name="productId">Id of product</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(07/09/2023)
        public async Task<IActionResult> ProductDelete(int productId)
        {
            var response = await _productService.GetProductByIdAsync(productId);

            if (response != null && response.IsSuccess)
            {
                var product = JsonConvert.DeserializeObject<Product>(Convert.ToString(response.Result)!);

                return View(product);
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return NotFound();
        }

        /// <summary>
        /// Product delete
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(07/09/2023)
        [HttpPost]
        public async Task<IActionResult> ProductDelete(Product product)
        {
            var response = await _productService.DeleteProductAsync(product);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Product deleted successfully";
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(product);
        }
    }
}
