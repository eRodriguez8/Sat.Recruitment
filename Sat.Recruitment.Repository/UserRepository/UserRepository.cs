using System;
using System.Collections.Generic;

using Sat.Recruitment.Models.Abstract;

namespace Sat.Recruitment.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        public UserModel Get(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(UserModel user)
        {
            throw new NotImplementedException();
        }

        public void Seed()
        {
            throw new NotImplementedException();
        }
    }
}
