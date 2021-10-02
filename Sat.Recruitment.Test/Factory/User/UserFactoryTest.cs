using Xunit;
using AutoMapper;
using FluentAssertions;

using Sat.Recruitment.Factory.User;
using Sat.Recruitment.Models.Entities;
using Sat.Recruitment.Test.Models.Mothers;
using Sat.Recruitment.Models.MapperProfile;

namespace Sat.Recruitment.Test.Factory.User
{
    public class UserFactoryTest : BaseTest
    {
        private const string NORMAL_TYPE = "Normal";
        private const string PREMIUM_TYPE = "Premium";
        private const string SUPERUSER_TYPE = "SuperUser";

        private IMapper mapper;
        private IUserFactory factory;
        private MapperConfiguration mockMapper;

        public UserFactoryTest()
        {
            factory = new UserFactory(mapper);
        }

        internal override void SetupMockObjects()
        {
            mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            mapper = mockMapper.CreateMapper();
        }

        [Fact]
        public void GivenAUserDtoWithUserTypeNormal_WhenFactoryIsCall_ShouldReturnNormalUserModel()
        {
            var userDto = UserDtoMother.WithType(NORMAL_TYPE);
            var normalUser = NormalUserModelMother.FromDto(userDto);

            
            var userFactory = factory.Create(userDto);

            userFactory.Name
                .Should()
                .Be(normalUser.Name);
            userFactory.Email
                .Should()
                .Be(normalUser.Email);
            userFactory.Address
                .Should()
                .Be(normalUser.Address);
            userFactory.Phone
                .Should()
                .Be(normalUser.Phone);
            userFactory.Money
                .Should()
                .Be(normalUser.Money);
            userFactory.GetType()
                .Should()
                .Be(typeof(NormalUserModel));
        }

        [Fact]
        public void GivenAUserDtoWithUserTypePremium_WhenFactoryIsCall_ShouldReturnPremiumUserModel()
        {
            var userDto = UserDtoMother.WithType(PREMIUM_TYPE);
            var premiumUser = PremiumUserModelMother.FromDto(userDto);

            var factory = new UserFactory(mapper);
            var userFactory = factory.Create(userDto);

            userFactory.Name
                .Should()
                .Be(premiumUser.Name);
            userFactory.Email
                .Should()
                .Be(premiumUser.Email);
            userFactory.Address
                .Should()
                .Be(premiumUser.Address);
            userFactory.Phone
                .Should()
                .Be(premiumUser.Phone);
            userFactory.Money
                .Should()
                .Be(premiumUser.Money);
            userFactory.GetType()
                .Should()
                .Be(typeof(PremiumUserModel));
        }

        [Fact]
        public void GivenAUserDtoWithUserTypeSuperUser_WhenFactoryIsCall_ShouldReturnSuperUserModel()
        {
            var userDto = UserDtoMother.WithType(SUPERUSER_TYPE);
            var superUser = SuperUserModelMother.FromDto(userDto);

            var factory = new UserFactory(mapper);
            var userFactory = factory.Create(userDto);

            userFactory.Name
                .Should()
                .Be(superUser.Name);
            userFactory.Email
                .Should()
                .Be(superUser.Email);
            userFactory.Address
                .Should()
                .Be(superUser.Address);
            userFactory.Phone
                .Should()
                .Be(superUser.Phone);
            userFactory.Money
                .Should()
                .Be(superUser.Money);
            userFactory.GetType()
                .Should()
                .Be(typeof(SuperUserModel));
        }
    }
}
