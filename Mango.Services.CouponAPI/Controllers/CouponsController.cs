using AutoMapper;
using Mango.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Mango.Services.CouponAPI.Controllers
{
    /// <summary>
    /// Information of coupons controller
    /// CreatedBy: ThiepTT(24/08/2023)
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CouponsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public CouponsController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all coupons
        /// </summary>
        /// <returns>List of coupon</returns>
        /// CreatedBy: ThiepTT(24/08/2023)
        [HttpGet]
        [Route("GetAllCoupons")]
        public async Task<ResponseDto> GetAllCounpons()
        {
            var response = new ResponseDto();

            try
            {
                var coupons = await _appDbContext.Coupons.ToListAsync();

                response.Result = coupons;
            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Get coupon by id
        /// </summary>
        /// <param name="couponId">Id of coupon</param>
        /// <returns>Information of coupon</returns>
        /// <exception cref="Exception">Message of exception</exception>
        /// CreatedBy: ThiepTT(24/08/2023)
        [HttpGet]
        [Route("GetCouponById/{couponId}")]
        public async Task<ResponseDto> GetCouponById([Required] int couponId)
        {
            var response = new ResponseDto();

            try
            {
                var coupon = await _appDbContext.Coupons.FirstOrDefaultAsync(c => c.CouponId == couponId);

                if (coupon == null)
                {
                    response.IsSuccess = true;
                    response.Message = $"Not found with ID of coupon: {couponId}";

                    return response;
                }

                response.Result = coupon;

            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Get coupon by code
        /// </summary>
        /// <param name="couponCode">Code of coupon</param>
        /// <returns>Information of coupon</returns>
        /// <exception cref="Exception">Message of exception</exception>
        /// CreatedBy: ThiepTT(24/08/2023)
        [HttpGet]
        [Route("GetCouponByCode/{couponCode}")]
        public async Task<ResponseDto> GetCouponByCode([Required] string couponCode)
        {
            var response = new ResponseDto();

            try
            {
                var coupon = await _appDbContext.Coupons.FirstOrDefaultAsync(c => c.CouponCode.Trim().ToLower().Equals(couponCode.Trim().ToLower()));

                if (coupon == null)
                {
                    response.IsSuccess = true;
                    response.Message = $"Not found with code of coupon: {couponCode}";

                    return response;
                }

                response.Result = coupon;

            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Create coupon
        /// </summary>
        /// <param name="couponCreate">CouponDto</param>
        /// <returns>Number coupon create success</returns>
        /// CreatedBy: ThiepTT(24/08/2023)
        [HttpPost]
        [Route("CreateCoupon")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> CreateCoupon([FromBody] CouponDto couponCreate)
        {
            var response = new ResponseDto();

            try
            {
                var coupon = _mapper.Map<Coupon>(couponCreate);

                _appDbContext.Coupons.Add(coupon);
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
        /// Update coupon
        /// </summary>
        /// <param name="coupon">CouponDto</param>
        /// <param name="couponId">Id of coupon</param>
        /// <returns>Number coupon update success</returns>
        /// CreatedBy: ThiepTT(24/08/2023)
        [HttpPut]
        [Route("UpdateCoupon/{couponId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseDto> UpdateCoupon([FromBody] CouponDto coupon,[Required] int couponId)
        {
            var response = new ResponseDto();

            try
            {
                var couponById = await _appDbContext.Coupons.FirstOrDefaultAsync(c => c.CouponId == couponId);

                if (couponById == null)
                {
                    response.IsSuccess = true;
                    response.Message = $"Not found with ID of coupon: {couponId}";

                    return response;
                }

                couponById.CouponCode = coupon.CouponCode;
                couponById.DiscountAmount = coupon.DiscountAmount;
                couponById.MinAmount = coupon.MinAmount;

                _appDbContext.Update(couponById);
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
        /// Delete coupon
        /// </summary>
        /// <param name="couponId">Id of coupon</param>
        /// <returns>Number coupon delete success</returns>
        /// CreatedBy: ThiepTT(24/08/2023)
        [HttpDelete]
        [Route("DeleteCoupon/{couponId}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> DeleteCoupon([Required] int couponId)
        {
            var response = new ResponseDto();

            try
            {
                var couponById = await _appDbContext.Coupons.FirstOrDefaultAsync(c => c.CouponId == couponId);

                if (couponById == null)
                {
                    response.IsSuccess = true;
                    response.Message = $"Not found with ID of coupon: {couponId}";

                    return response;
                }

                _appDbContext.Remove(couponById);
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