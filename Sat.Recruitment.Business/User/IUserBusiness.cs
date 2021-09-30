using System.Collections.Generic;

using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Models.Abstract;

namespace Sat.Recruitment.Business.User
{
    public interface IUserBusiness
    {
        public UserModel GetByEmail(string email);
        public List<UserModel> GetAll();
        public void Insert(UserDto user);
    }
}
