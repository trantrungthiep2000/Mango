namespace Mango.Services.AuthAPI.Models.Dtos
{
    /// <summary>
    /// Information of login response dto
    /// CreatedBy: ThiepTT(29/08/2023)
    /// </summary>
    public class LoginResponseDto
    {
        /// <summary>
        /// Information of user
        /// </summary>
        public User User { get; set; } = new User();

        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; } = string.Empty;
    }
}
