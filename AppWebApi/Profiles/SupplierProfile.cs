using AutoMapper;
using Domain.DTO.Create;
using Domain.DTO.Read;
using Domain.Models;

namespace AppWebApi.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<CreateSupplierDto, Supplier>();
            CreateMap<Supplier, ReadSupplierDto>().ForMember(sDto => sDto.address,
                opt => opt.MapFrom(s => s.Address));
        }
    }
}
