using System.Collections.Generic;

using Sat.Recruitment.Models.Abstract;

namespace Sat.Recruitment.Repository.User
{
    public interface IUserRepository
    {
        public UserModel GetByEmail(string email);
        public IEnumerable<UserModel> GetAll();
        public void Insert(UserModel user);
        public void Seed();
    }
}
