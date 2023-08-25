using AutoMapper;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dtos;

namespace Mango.Services.CouponAPI.AutoMappings
{
    /// <summary>
    /// Information of mapping config
    /// CreatedBy: ThiepTT(24/08/2023)
    /// </summary>
    public class MappingConfig
    {
        /// <summary>
        /// Register maps
        /// </summary>
        /// <returns>MapperConfiguration</returns>
        /// CreatedBy: ThiepTT(24/08/2023)s
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });

            return mappingConfig;
        }
    }
}
