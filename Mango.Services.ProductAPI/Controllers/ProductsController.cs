using AutoMapper;
using Mango.Services.ProductAPI.Data;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Mango.Services.ProductAPI.Controllers
{
    /// <summary>
    /// Information of products controller
    /// CreatedBy: ThiepTT(06/09/2023)
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public ProductsController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        // <summary>
        /// Get all products
        /// </summary>
        /// <returns>List of product</returns>
        /// CreatedBy: ThiepTT(06/09/2023)
        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<ResponseDto> GetAllProducts()
        {
            var response = new ResponseDto();

            try
            {
                var products = await _appDbContext.Products.ToListAsync();

                response.Result = products;
            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="productId">Id of product</param>
        /// <returns>Information of product</returns>
        /// CreatedBy: ThiepTT(06/09/2023)
        [HttpGet]
        [Route("GetProductById/{productId}")]
        public async Task<ResponseDto> GetProductById([Required] int productId)
        {
            var response = new ResponseDto();

            try
            {
                var product = await _appDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);

                if (product == null)
                {
                    response.IsSuccess = true;
                    response.Message = $"Not found with ID of product: {productId}";

                    return response;
                }

                response.Result = product;

            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Create product
        /// </summary>
        /// <param name="productDto">ProductDto</param>
        /// <returns>Number product create success</returns>
        /// CreatedBy: ThiepTT(06/09/2023)
        [HttpPost]
        [Route("CreateProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseDto> CreateProduct([FromBody] ProductDto productDto)
        {
            var response = new ResponseDto();

            try
            {
                var product = _mapper.Map<Product>(productDto);

                _appDbContext.Products.Add(product);
                response.Result = await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="product">CouponDto</param>
        /// <param name="productId">Id of product</param>
        /// <returns>Number product update success</returns>
        /// CreatedBy: ThiepTT(24/08/2023)
        [HttpPut]
        [Route("UpdateProduct/{productId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseDto> UpdateProduct([FromBody] ProductDto product, [Required] int productId)
        {
            var response = new ResponseDto();

            try
            {
                var productById = await _appDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);

                if (productById == null)
                {
                    response.IsSuccess = true;
                    response.Message = $"Not found with ID of product: {productId}";

                    return response;
                }

                productById.Name = product.Name;
                productById.Price = product.Price;
                productById.Description = product.Description;
                productById.CategoryName = product.CategoryName;
                productById.ImageUrl = product.ImageUrl;

                _appDbContext.Update(productById);
                response.Result = await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="productId">Id of product</param>
        /// <returns>Number product delete success</returns>
        /// CreatedBy: ThiepTT(06/09/2023)
        [HttpDelete]
        [Route("DeleteProduct/{productId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseDto> DeleteProduct([Required] int productId)
        {
            var response = new ResponseDto();

            try
            {
                var productById = await _appDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);

                if (productById == null)
                {
                    response.IsSuccess = true;
                    response.Message = $"Not found with ID of product: {productId}";

                    return response;
                }

                _appDbContext.Remove(productById);
                response.Result = await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}