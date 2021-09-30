using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Models.Abstract;

namespace Sat.Recruitment.Factory.User
{
    public interface IUserFactory
    {
        public UserModel Create(UserDto user);
    }
}
