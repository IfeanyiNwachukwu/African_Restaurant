using AutoMapper;
using Services.ProductAPI.DataTransferObjects.Readable;
using Services.ProductAPI.Models;

namespace Services.ProductAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
