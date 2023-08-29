using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Models.Dtos;

namespace Mango.Services.AuthAPI.Services.IServices
{
    /// <summary>
    /// Information of interface auth service
    /// CreatedBy: ThiepTT(29/08/2023)
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="registerationRequestDto">RegisterationRequestDto</param>
        /// <returns>Information</returns>
        /// CreatedBy: ThiepTT(29/08/2023)
        public Task<string> Register(RegisterationRequestDto registerationRequestDto);

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginRequestDto">LoginRequestDto</param>
        /// <returns>Information of user and token</returns>
        /// CreatedBy: ThiepTT(29/08/2023)
        public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
    }
}
