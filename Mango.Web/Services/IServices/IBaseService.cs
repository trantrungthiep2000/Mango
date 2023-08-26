using Mango.Web.Models;

namespace Mango.Web.Services.IServices
{
    /// <summary>
    /// Information of interface base service
    /// CreatedBy: ThiepTT(25/08/2023)
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public interface IBaseService<T> where T : class
    {
        /// <summary>
        /// Send async
        /// </summary>
        /// <param name="requestDto">RequestDto</param>
        /// <returns>ReponseDto</returns>
        public Task<ResponseDto<T>?> SendAsync(RequestDto<T> requestDto);
    }
}
