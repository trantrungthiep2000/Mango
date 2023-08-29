namespace Mango.Services.AuthAPI.Models.Dtos
{
    /// <summary>
    /// Information of registeration request dto
    /// CreatedBy: ThiepTT(29/08/2023)
    /// </summary>
    public class RegisterationRequestDto
    {
        /// <summary>
        /// Email of user
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Name of user
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Phone number
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
