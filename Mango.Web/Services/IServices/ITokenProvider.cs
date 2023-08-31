namespace Mango.Web.Services.IServices
{
    /// <summary>
    /// Information of interface token provider
    /// CreatedBy: ThiepTT(31/08/2023)
    /// </summary>
    public interface ITokenProvider
    {
        /// <summary>
        /// Set token
        /// </summary>
        /// <param name="token">Token</param>
        /// CreatedBy: ThiepTT(31/08/2023)
        public void SetToken(string token);

        /// <summary>
        /// Get token
        /// </summary>
        /// <returns>Token</returns>
        /// CreatedBy: ThiepTT(31/08/2023)
        public string? GetToken();

        /// <summary>
        /// Clean token
        /// </summary>
        /// CreatedBy: ThiepTT(31/08/2023)
        public void CleanToken();
    }
}
