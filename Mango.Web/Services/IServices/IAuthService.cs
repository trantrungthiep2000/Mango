using Mango.Web.Models;

namespace Mango.Web.Services.IServices
{
    /// <summary>
    /// Information of interface auth service 
    /// CreatedBy: ThiepTT(31/08/2023)
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Login async
        /// </summary>
        /// <param name="loginRequestDto">LoginRequestDto</param>
        /// <returns>ResponseDto</returns>
        /// CreatedBy: ThiepTT(31/08/2023)
        public Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);

        /// <summary>
        /// Register async
        /// </summary>
        /// <param name="registerationRequestDto">RegisterationRequestDto</param>
        /// <returns>ResponseDto</returns>
        /// CreatedBy: ThiepTT(31/08/2023)
        public Task<ResponseDto?> RegisterAsync(RegisterationRequestDto registerationRequestDto);

        /// <summary>
        /// Assign role async
        /// </summary>
        /// <param name="assignRoleRequestDto">AssignRoleRequestDto</param>
        /// <returns>ResponseDto</returns>
        /// CreatedBy: ThiepTT(31/08/2023)
        public Task<ResponseDto?> AssignRoleAsync(AssignRoleRequestDto assignRoleRequestDto);
    }
}
