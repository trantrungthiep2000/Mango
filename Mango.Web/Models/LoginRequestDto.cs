using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Models
{
    /// <summary>
    /// Information of login request dto
    /// CreatedBy: ThiepTT(31/08/2023)
    /// </summary>
    public class LoginRequestDto
    {
        /// <summary>
        /// User name
        /// </summary>
        [Required]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
