using System.Collections.Generic;

using Sat.Recruitment.Models.Abstract;

namespace Sat.Recruitment.Repository.UserRepository
{
    public interface IUserRepository
    {
        public UserModel Get(string email);
        public IEnumerable<UserModel> GetAll();
        public void Insert(UserModel user);
        public void Seed();
    }
}
