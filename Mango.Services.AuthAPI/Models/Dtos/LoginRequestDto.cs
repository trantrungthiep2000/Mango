namespace Mango.Services.AuthAPI.Models.Dtos
{
    /// <summary>
    /// Information of login request dto
    /// CreatedBy: ThiepTT(29/08/2023)
    /// </summary>
    public class LoginRequestDto
    {
        /// <summary>
        /// User name
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
