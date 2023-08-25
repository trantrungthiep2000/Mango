namespace Mango.Web.Models
{
    /// <summary>
    /// Information of response dto
    /// CreatedBy: ThiepTT(25/08/2023)
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class ResponseDto<T>
    {
        /// <summary>
        /// Result of response
        /// </summary>
        public T? Result { get; set; }

        /// <summary>
        /// Is success
        /// </summary>
        public bool IsSuccess { get; set; } = false;

        /// <summary>
        /// Message of response
        /// </summary>
        public string Message { get; set; } = string.Empty;
    }
}