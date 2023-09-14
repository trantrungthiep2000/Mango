using Mango.Web.Models;

namespace Mango.Web.Services.IServices
{
    /// <summary>
    /// Information of interface service
    /// CreatedBy: ThiepTT(12/09/2023)
    /// </summary>
    public interface ICartService
    {
        /// <summary>
        /// Get cart by user id async
        /// </summary>
        /// <param name="userId">Id of user</param>
        /// <returns>ResponseDto</returns>
        /// CreatedBy: ThiepTT(12/09/2023)
        public Task<ResponseDto?> GetCartByUserIdAsync(string userId);

        /// <summary>
        /// Cart upsert async
        /// </summary>
        /// <param name="cartDto">CartDto</param>
        /// <returns>ResponseDto</returns>
        /// CreatedBy: ThiepTT(12/09/2023)
        public Task<ResponseDto?> CartUpsertAsync(CartDto cartDto);

        /// <summary>
        /// Remove from cart async
        /// </summary>
        /// <param name="cartDetailsId">Id of cart details</param>
        /// <returns>ResponseDto</returns>
        /// CreatedBy: ThiepTT(12/09/2023)
        public Task<ResponseDto?> RemoveFromCartAsync(int cartDetailsId);

        /// <summary>
        /// Apply coupon async
        /// </summary>
        /// <param name="cartDto">CartDto</param>
        /// <returns>ResponseDto</returns>
        /// CreatedBy: ThiepTT(12/09/2023)
        public Task<ResponseDto?> ApplyCouponAsync(CartDto cartDto);

        /// <summary>
        /// Email cart
        /// </summary>
        /// <param name="cartDto">CartDto</param>
        /// <returns>ResponseDto</returns>
        /// CreatedBy: ThiepTT(13/09/2023)
        public Task<ResponseDto?> EmailCartAsync(CartDto cartDto);
    }
}
