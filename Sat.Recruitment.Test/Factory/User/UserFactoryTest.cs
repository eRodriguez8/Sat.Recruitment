using Moq;
using Xunit;
using AutoMapper;
using FluentAssertions;

using Sat.Recruitment.Factory.User;
using Sat.Recruitment.Test.Models.Mothers;

namespace Sat.Recruitment.Test.Factory.User
{
    public class UserFactoryTest
    {
        private IMapper _mapper;

        //public UserFactoryTest(IMapper mapper)
        //{
        //    _mapper = mapper;
        //}

        [Fact]
        public void GivenAUserDtoWithÜserTypeNormal_WhenFactoryIsCall_ShouldReturnNormalUserModel()
        {
            var userDto = UserDtoMother.WithType("Normal");
            var normalUser = NormalUserModelMother.FromDto(userDto);

            var factory = new UserFactory(_mapper);
            var userFactory = factory.Create(userDto);

            userFactory
                .Should()
                .Be(normalUser);
        }
    }
}
