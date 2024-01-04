using AutoMapper;
using Domain.DTO.Create;
using Domain.Models.Identity_Users;

namespace AppWebApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<UserRegisterRequest, User>();
        }
    }
}
