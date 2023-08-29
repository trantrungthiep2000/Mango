using Mango.Services.AuthAPI.Models;

namespace Mango.Services.AuthAPI.Services.IServices
{
    /// <summary>
    /// Information of interface Jwt token generator
    /// CreatedBy: ThiepTT(29/08/2023)
    /// </summary>
    public interface IJwtTokenGenerator
    {
        /// <summary>
        /// Generator token
        /// </summary>
        /// <param name="applicationUser">ApplicationUser</param>
        /// <returns>Token</returns>
        /// CreatedBy: ThiepTT(29/08/2023)
        public string GenerateToken(ApplicationUser applicationUser);
    }
}
