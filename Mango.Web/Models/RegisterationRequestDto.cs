using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Models
{
    /// <summary>
    /// Information of registeration request dto
    /// CreatedBy: ThiepTT(31/08/2023)
    /// </summary>
    public class RegisterationRequestDto
    {
        /// <summary>
        /// Email of user
        /// </summary>
        [Required]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Name of user
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Phone number
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Role name
        /// </summary>
        public string RoleName { get; set; } = string.Empty;
    }
}
