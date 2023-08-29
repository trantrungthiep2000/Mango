namespace Mango.Services.AuthAPI.Models
{
    /// <summary>
    /// Information of user
    /// CreatedBy: ThiepTT(29/08/2023)
    /// </summary>
    public class User
    {
        /// <summary>
        /// ID of user
        /// </summary>
        public string ID { get; set; } = string.Empty;

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
    }
}
