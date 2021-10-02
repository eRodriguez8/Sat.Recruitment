using AutoMapper;

using System;

using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Models.Enums;
using Sat.Recruitment.Models.Entities;
using Sat.Recruitment.Models.Abstract;

namespace Sat.Recruitment.Models.MapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, NormalUserModel>()
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(
                        src => (UserType)Enum.Parse(typeof(UserType), src.UserType.ToUpper())));
            CreateMap<UserDto, PremiumUserModel>()
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(
                        src => (UserType)Enum.Parse(typeof(UserType), src.UserType.ToUpper())));
            CreateMap<UserDto, SuperUserModel>()
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(
                        src => (UserType)Enum.Parse(typeof(UserType), src.UserType.ToUpper())));
            CreateMap<UserModel, UserDto>()
                .ForMember(
                    dest => dest.UserType,
                    opt => opt.MapFrom(
                        src => src.Type.ToString()));
        }
    }
}
