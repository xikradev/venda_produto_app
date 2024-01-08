using AutoMapper;
using Domain.Models;
using Domain.DTO.Create;
using Domain.DTO.Read;

namespace AppWebApi.Profiles
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<CreateSaleDto, Sale>();
            CreateMap<Sale, ReadSaleDto>()
                .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client.Fullname))
                .ForMember(dest => dest.Seller, opt => opt.MapFrom(src => src.User.FullName));
        }
    }
}
