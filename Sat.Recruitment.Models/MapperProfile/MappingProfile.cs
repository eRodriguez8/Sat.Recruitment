using AutoMapper;

using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Models.Abstract;

namespace Sat.Recruitment.Models.MapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, UserModel>();
            CreateMap<UserModel, UserDto>();
        }
    }
}
