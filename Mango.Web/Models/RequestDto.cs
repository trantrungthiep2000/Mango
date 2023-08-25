using static Mango.Web.Utility.SD;

namespace Mango.Web.Models
{
    /// <summary>
    /// Information of request dto
    /// CreatedBy: ThiepTT(25/08/2023)
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class RequestDto<T>
    {
        /// <summary>
        /// Api type
        /// </summary>
        public ApiType ApiType { get; set; } = ApiType.GET;

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// Data
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Access token
        /// </summary>
        public string AccessToken { get; set; } = string.Empty;
    }
}