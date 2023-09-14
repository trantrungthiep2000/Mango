namespace Mango.Services.EmailAPI.Models
{
    /// <summary>
    /// Information of email logger
    /// CreatedBy: ThiepTT(13/09/2023)
    /// </summary>
    public class EmailLogger
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Email sent
        /// </summary>
        public DateTime EmailSent { get; set; }
    }
}
