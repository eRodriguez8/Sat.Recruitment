using AutoMapper;

using System;

using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Models.Enums;
using Sat.Recruitment.Models.Abstract;
using Sat.Recruitment.Models.Entities;

namespace Sat.Recruitment.Factory.User
{
    public class UserFactory : IUserFactory
    {
        private readonly IMapper _mapper;

        public UserFactory() { }
        public UserFactory(IMapper mapper)
        {
            _mapper = mapper;
        }
        public UserModel Create(UserDto user)
        {
            UserType userType = (UserType)Enum.Parse(typeof(UserType), user.UserType.ToUpper());
            switch (userType)
            {
                case UserType.NORMAL:
                    return _mapper.Map<NormalUserModel>(user);
                case UserType.PREMIUM:
                    return _mapper.Map<PremiumUserModel>(user);
                case UserType.SUPERUSER:
                    return _mapper.Map<SuperUserModel>(user);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
