using AutoMapper;
using Mango.Services.ShoppingCartAPI.Data;
using Mango.Services.ShoppingCartAPI.Models;
using Mango.Services.ShoppingCartAPI.Models.Dtos;
using Mango.Services.ShoppingCartAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;

namespace Mango.Services.ShoppingCartAPI.Controllers
{
    /// <summary>
    /// Information of carts controller
    /// CreatedBy: ThiepTT(11/09/2023)
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly ICouponService _couponService;

        public CartsController(AppDbContext appDbContext, IMapper mapper, IProductService productService, ICouponService couponService)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _productService = productService;
            _couponService = couponService;
        }

        /// <summary>
        /// Get cart
        /// </summary>
        /// <param name="userId">Id of user</param>
        /// <returns>ResponseDto</returns>
        /// CreatedBy: ThiepTT(12/09/2023)
        [HttpGet]
        [Route("GetCart/{userId}")]
        public async Task<ResponseDto> GetCart(string userId)
        {
            var response = new ResponseDto();

            try
            {
                var cartHeader = await _appDbContext.CartHeaders.FirstAsync(u => u.UserId == userId);

                var cart = new CartDto()
                {
                    CartHeader = _mapper.Map<CartHeader>(cartHeader)
                };

                var listCartDetails = await _appDbContext.CartDetails
                    .Where(u => u.CartHeaderId == cart.CartHeader.CartHeaderId).ToListAsync();

                cart.CartDetails = _mapper.Map<IEnumerable<CartDetails>>(listCartDetails);

                var products = await _productService.GetProducts();

                foreach (var cartDetails in listCartDetails)
                {
                    cartDetails.Product = products.FirstOrDefault(u => u.ProductId == cartDetails.ProductId);
                    cart.CartHeader.CartTotal += (cartDetails.Count * cartDetails.Product!.Price);
                }

                // apply coupon if any
                if (!string.IsNullOrWhiteSpace(cart.CartHeader.CouponCode))
                {
                    var coupon = await _couponService.GetCouponByCode(cart.CartHeader.CouponCode);

                    if (coupon != null && cart.CartHeader.CartTotal > coupon.MinAmount)
                    {
                        cart.CartHeader.CartTotal -= coupon.DiscountAmount;
                        cart.CartHeader.Discount = coupon.DiscountAmount;
                    }
                }

                response.Result = cart;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
                response.IsSuccess = false;
            }

            return response;
        }

        /// <summary>
        /// Apply coupon
        /// </summary>
        /// <param name="cartDto">CartDto</param>
        /// <returns>ResponseDto</returns>
        /// CreatedBy: ThiepTT(12/09/2023)
        [HttpPost]
        [Route("ApplyCoupon")]
        public async Task<ResponseDto> AppplyCoupon(CartDto cartDto)
        {
            var response = new ResponseDto();

            try
            {
                var cartFromDb = await _appDbContext.CartHeaders.FirstAsync(u => u.UserId == cartDto.CartHeader!.UserId);
                cartFromDb.CouponCode = cartDto.CartHeader!.CouponCode;

                _appDbContext.CartHeaders.Update(cartFromDb);
                await _appDbContext.SaveChangesAsync();

                response.Result = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
                response.IsSuccess = false;
            }

            return response;
        }

        /// <summary>
        /// Cart upsert
        /// </summary>
        /// <param name="cartDto">CartDto</param>
        /// <returns>ResponseDto</returns>
        /// CreatedBy: ThiepTT(11/09/2023)
        [HttpPost]
        [Route("CartUpsert")]
        public async Task<ResponseDto> CartUpsert(CartDto cartDto)
        {
            var response  = new  ResponseDto();

            try
            {
                // get cart header from database
                var cartHeaderFromDb = await _appDbContext.CartHeaders
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.UserId == cartDto.CartHeader!.UserId);

                // cart header from database no data
                if (cartHeaderFromDb == null)
                {
                    // create cart header and cart details
                    var cartHeader = _mapper.Map<CartHeader>(cartDto.CartHeader);
                    
                    _appDbContext.CartHeaders.Add(cartHeader);
                    await _appDbContext.SaveChangesAsync();

                    cartDto.CartDetails!.First().CartHeaderId = cartHeader.CartHeaderId;
                    var cartDetails = _mapper.Map<CartDetails>(cartDto.CartDetails!.First());
                    
                    _appDbContext.CartDetails.Add(cartDetails);
                    await _appDbContext.SaveChangesAsync();
                }
                else 
                {
                    // get cart details from databse 
                    var cartDetailsFromDb = await _appDbContext.CartDetails
                        .AsNoTracking()
                        .FirstOrDefaultAsync(
                            u => u.ProductId == cartDto.CartDetails!.First().ProductId &&
                            u.CartHeaderId == cartHeaderFromDb.CartHeaderId);

                    // cart detaild from database no data
                    if (cartDetailsFromDb == null)
                    {
                        // create cart details
                        cartDto.CartDetails!.First().CartHeaderId = cartHeaderFromDb.CartHeaderId;
                        var cartDetails = _mapper.Map<CartDetails>(cartDto.CartDetails!.First());

                        _appDbContext.CartDetails.Add(cartDetails);
                        await _appDbContext.SaveChangesAsync();
                    }
                    else
                    {
                        // update count cart  
                        cartDto.CartDetails!.First().Count += cartDetailsFromDb.Count;
                        cartDto.CartDetails!.First().CartHeaderId = cartHeaderFromDb.CartHeaderId;
                        cartDto.CartDetails!.First().CartDetailsId = cartDetailsFromDb.CartDetailsId;
                        var cartDetails = _mapper.Map<CartDetails>(cartDto.CartDetails!.First());

                        _appDbContext.CartDetails.Update(cartDetails);
                        await _appDbContext.SaveChangesAsync();
                    }
                }

                response.Result = cartDto;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
                response.IsSuccess = false;
            }

            return response;
        }

        /// <summary>
        /// Remove cart
        /// </summary>
        /// <param name="cartDetailsId">Id of cart details</param>
        /// <returns>ResponseDto</returns>
        /// CreatedBy: ThiepTT(12/09/2023)
        [HttpDelete]
        [Route("RemoveCart/{cartDetailsId}")]
        public async Task<ResponseDto> RemoveCart(int cartDetailsId)
        {
            var response = new ResponseDto();

            try
            {
                var cartDetails = await _appDbContext.CartDetails
                    .FirstAsync(u => u.CartDetailsId == cartDetailsId);

                int totalCountOfCartItem = await _appDbContext.CartDetails
                    .Where(u => u.CartHeaderId == cartDetails!.CartHeaderId).CountAsync();
                _appDbContext.CartDetails.Remove(cartDetails!);

                if (totalCountOfCartItem == 1)
                {
                    var cartHeaderToRemove = await _appDbContext.CartHeaders
                        .FirstOrDefaultAsync(u => u.CartHeaderId == cartDetails.CartHeaderId);

                    _appDbContext.CartHeaders.Remove(cartHeaderToRemove!);
                }

                await _appDbContext.SaveChangesAsync();

                response.Result = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
                response.IsSuccess = false;
            }

            return response;
        }
    }
}