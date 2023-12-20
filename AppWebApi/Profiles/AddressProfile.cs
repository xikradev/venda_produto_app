using AutoMapper;
using Domain.DTO.Create;
using Domain.DTO.Read;
using Domain.Models;

namespace AppWebApi.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, ReadAddressDto>();
            CreateMap<CreateAddressDto, Address>();
        }
    }
}
