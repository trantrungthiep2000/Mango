using AutoMapper;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dtos;

namespace Mango.Services.ProductAPI.AutoMappings
{
    /// <summary>
    /// Information of mapping config
    /// CreatedBy: ThiepTT(06/09/2023)
    /// </summary>
    public class MappingConfig
    {
        /// <summary>
        /// Register maps
        /// </summary>
        /// <returns>MapperConfiguration</returns>
        /// CreatedBy: ThiepTT(06/09/2023)
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });

            return mappingConfig;
        }
    }
}
