using Moq;
using Xunit;

using Sat.Recruitment.Factory.User;
using Sat.Recruitment.Repository.User;

namespace Sat.Recruitment.Test.Repository.User
{
    public class UserRepositoryTest : BaseTest
    {
        private const string EMAIL = "Juan@marmol.com";

        private Mock<IUserFactory> mockFactory;
        private IUserRepository userRepository;

        public UserRepositoryTest()
        {
            userRepository = new UserRepository(mockFactory.Object);
            userRepository.Seed();
        }

        internal override void SetupMockObjects()
        {
            mockFactory = new Mock<IUserFactory>();
        }

        [Fact]
        public void GivenAEmail_WhenUserRepositoryMethodGetByEmailIsCall_ShouldReturnUserModel()
        {

            var user = userRepository.GetByEmail(EMAIL);
        }
    }
}
