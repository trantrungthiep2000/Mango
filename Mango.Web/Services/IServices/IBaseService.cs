using Mango.Web.Models;

namespace Mango.Web.Services.IServices
{
    /// <summary>
    /// Information of interface base service
    /// CreatedBy: ThiepTT(25/08/2023)
    /// </summary>
    public interface IBaseService
    {
        /// <summary>
        /// Send async
        /// </summary>
        /// <param name="requestDto">RequestDto</param>
        /// <returns>ReponseDto</returns>
        /// CreatedBy: ThiepTT(25/08/2023)
        public Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
