using AutoMapper;
using Domain.DTO.Create;
using Domain.DTO.Read;
using Domain.Models;

namespace AppWebApi.Profiles
{
    public class ProductSupplierProfile : Profile
    {
        public ProductSupplierProfile()
        {
            CreateMap<CreateProductSupplierDto, ProductSupplier>();
            CreateMap<ProductSupplier, ReadProductSupplierDto>()
                .ForMember(psDto => psDto.Supplier,
                    opt => opt.MapFrom(ps => ps.Supplier)).
                ForMember(psDto => psDto.Product,
                    opt => opt.MapFrom(ps => ps.Product));
        }
    }
}
