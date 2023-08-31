using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Mango.Web.Utility;

namespace Mango.Web.Services
{
    /// <summary>
    /// Information of auth service
    /// CreatedBy: ThiepTT(31/08/2023)
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;

        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        /// <summary>
        /// Login async
        /// </summary>
        /// <param name="loginRequestDto">LoginRequestDto</param>
        /// <returns>ResponseDto</returns>
        /// CreatedBy: ThiepTT(31/08/2023)
        public async Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Url = SD.AuthAPIBase + $"/api/Auths/Login",
                Data = loginRequestDto,
            });
        }

        /// <summary>
        /// Register async 
        /// </summary>
        /// <param name="registerationRequestDto">RegisterationRequestDto</param>
        /// <returns>ResponseDto</returns>
        /// CreatedBy: ThiepTT(31/08/2023)
        public async Task<ResponseDto?> RegisterAsync(RegisterationRequestDto registerationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Url = SD.AuthAPIBase + $"/api/Auths/Register",
                Data = registerationRequestDto,
            });
        }

        /// <summary>
        /// Assign role async
        /// </summary>
        /// <param name="assignRoleRequestDto">AssignRoleRequestDto</param>
        /// <returns>ResponseDto</returns>
        /// CreatedBy: ThiepTT(31/08/2023)
        public async Task<ResponseDto?> AssignRoleAsync(AssignRoleRequestDto assignRoleRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Url = SD.AuthAPIBase + $"/api/Auths/AssignRole",
                Data = assignRoleRequestDto,
            });
        }
    }
}
