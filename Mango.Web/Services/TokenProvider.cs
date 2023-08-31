using Mango.Web.Services.IServices;
using Mango.Web.Utility;
using Newtonsoft.Json.Linq;

namespace Mango.Web.Services
{
    /// <summary>
    /// Information of token provider
    /// CreatedBy: ThiepTT(31/08/2023)
    /// </summary>
    public class TokenProvider : ITokenProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public TokenProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        /// <summary>
        /// Set token
        /// </summary>
        /// <param name="token">Token</param>
        /// CreatedBy: ThiepTT(31/08/2023)
        public void SetToken(string token)
        {
            _contextAccessor.HttpContext?.Response.Cookies.Append(SD.TokenCookie, token);
        }

        /// <summary>
        /// Get token
        /// </summary>
        /// <returns>Token</returns>
        /// CreatedBy: ThiepTT(31/08/2023)
        public string? GetToken()
        {
            string? token = null;
            bool? hasToken = _contextAccessor.HttpContext?.Request.Cookies.TryGetValue(SD.TokenCookie, out token);
            return hasToken is true ? token : null;
        }

        /// <summary>
        /// Clean token
        /// </summary>
        /// CreatedBy: ThiepTT(31/08/2023)
        public void CleanToken()
        {
            _contextAccessor.HttpContext?.Response.Cookies.Delete(SD.TokenCookie);
        }
    }
}
