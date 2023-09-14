using Mango.Services.EmailAPI.Models.Dtos;

namespace Mango.Services.EmailAPI.Services.IServices
{
    /// <summary>
    /// Information of interface email service
    /// CreatedBy: ThiepTT(13/09/2023)
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Email cart and log
        /// </summary>
        /// <param name="cartDto">CartDto</param>
        /// <returns></returns>
        /// CreatedBy: ThiepTT(13/09/2023)
        public Task EmailCartAndLog(CartDto cartDto);
    }
}
