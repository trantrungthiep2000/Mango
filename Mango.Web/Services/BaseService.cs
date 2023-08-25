﻿using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static Mango.Web.Utility.SD;

namespace Mango.Web.Services
{
    /// <summary>
    /// Information of base service
    /// CreatedBy: ThiepTT(25/08/2023)
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IHttpClientFactory _httpClientFactory;
        
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Send async
        /// </summary>
        /// <param name="requestDto">RequestDto</param>
        /// <returns>ResponseDto</returns>
        /// CreatedBy: ThiepTT(25/08/2023)
        public async Task<ResponseDto<T>?> SendAsync(RequestDto<T> requestDto)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                // token

                message.RequestUri = new Uri(requestDto.Url);

                if (requestDto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }

                HttpResponseMessage? apiResponse = null;

                switch (requestDto.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await client.SendAsync(message);

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not Found" };
                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Access Denied" };
                    case HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal Server Error" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto<T>>(apiContent);

                        return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto<T>
                {
                    IsSuccess = false,
                    Message = ex.Message.ToString(),
                };

                return dto;
            }
        }
    }
}
