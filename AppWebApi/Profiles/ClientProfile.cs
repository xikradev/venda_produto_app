using AutoMapper;
using Domain.DTO.Create;
using Domain.DTO.Read;
using Domain.Models;

namespace AppWebApi.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile() 
        {
            CreateMap<CreateClientDto, Client>();
            CreateMap<Client, ReadClientDto>().ForMember(cDto => cDto.address,
                opt => opt.MapFrom(c => c.Address));
        }
    }
}
