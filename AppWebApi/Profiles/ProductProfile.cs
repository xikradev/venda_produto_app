using AutoMapper;
using Domain.DTO.Create;
using Domain.DTO.Read;
using Domain.Models;

namespace AppWebApi.Profiles
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ReadProductDto>();
            CreateMap<CreateProductDto, Product>();
        }
    }
}
