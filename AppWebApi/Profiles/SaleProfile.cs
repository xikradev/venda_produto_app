using AutoMapper;
using Domain.Models;
using Domain.DTO.Create;

namespace AppWebApi.Profiles
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<CreateSaleDto, Sale>();
        }
    }
}
