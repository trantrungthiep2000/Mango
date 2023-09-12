using AutoMapper;
using Mango.Services.ShoppingCartAPI.Models;
using Mango.Services.ShoppingCartAPI.Models.Dtos;

namespace Mango.Services.ShoppingCartAPI.AutoMappings
{
    /// <summary>
    /// Information of mapping config
    /// CreatedBy: ThiepTT(11/09/2023)
    /// </summary>
    public class MappingConfig
    {
        /// <summary>
        /// Register maps
        /// </summary>
        /// <returns>MapperConfiguration</returns>
        /// CreatedBy: ThiepTT(11/09/2023)
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
