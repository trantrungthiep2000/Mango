using Microsoft.AspNetCore.Identity;

namespace Mango.Services.AuthAPI.Models
{
    /// <summary>
    /// Information of application user
    /// CreatedBy: ThiepTT(28/08/2023)
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
