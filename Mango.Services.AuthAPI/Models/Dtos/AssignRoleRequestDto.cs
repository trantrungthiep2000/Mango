namespace Mango.Services.AuthAPI.Models.Dtos
{
    /// <summary>
    /// Information of assign role request dto
    /// CreatedBy: ThiepTT(30/08/2023)
    /// </summary>
    public class AssignRoleRequestDto
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Role name
        /// </summary>
        public string RoleName { get; set; } = string.Empty;
    }
}
