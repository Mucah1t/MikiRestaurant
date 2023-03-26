using AutoMapper;
using Miki.Services.ProductAPI.Models;
using Miki.Services.ProductAPI.Models.DTO;

namespace Miki.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>(); //.reverse method can be used for reverse method instead of writing 
                config.CreateMap<Product, ProductDto>();
            });

            return mappingConfig;
        }
    }
}
