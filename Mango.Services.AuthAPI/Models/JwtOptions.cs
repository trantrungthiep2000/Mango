namespace Mango.Services.AuthAPI.Models
{
    /// <summary>
    /// Information of jwt options
    /// CreatedBy: ThiepTT(29/08/2023)
    /// </summary>
    public class JwtOptions
    {
        /// <summary>
        /// Issuer
        /// </summary>
        public string Issuer { get; set; } = string.Empty;

        /// <summary>
        /// Audience
        /// </summary>
        public string Audience { get; set; } = string.Empty;

        /// <summary>
        /// Secret
        /// </summary>
        public string Secret { get; set; } = string.Empty;
    }
}
