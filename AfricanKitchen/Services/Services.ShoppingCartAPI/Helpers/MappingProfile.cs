using AutoMapper;
using Services.ShoppingCartAPI.DataTransferObjects.Readable;
using Services.ShoppingCartAPI.Models;

namespace Services.ShoppingCartAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();  // Source Destination
            CreateMap<CartDTO, Cart>().ReverseMap();
            CreateMap<CartHeaderDTO, CartHeader>().ReverseMap();
            CreateMap<CartDetailsDTO, CartDetails>().ReverseMap();

            CreateMap<CartHeader, CartHeaderDTO>().ReverseMap();
            CreateMap<CartDetails, CartDetailsDTO>().ReverseMap();
            CreateMap<Cart,CartDTO>().ReverseMap();

        }
    }
}
