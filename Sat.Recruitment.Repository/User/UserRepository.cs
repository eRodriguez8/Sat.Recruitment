using System;
using System.Collections.Generic;

using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Models.Helpers;
using Sat.Recruitment.Models.Abstract;
using Sat.Recruitment.Factory.User;

namespace Sat.Recruitment.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private List<UserModel> _users;
        private readonly IUserFactory _factory;

        public UserRepository(IUserFactory factory)
        {
            _factory = factory;
            _users = new List<UserModel>();

            Seed();
        }
        public UserModel GetByEmail(string email)
        {
            return _users.Find(user => String.Equals(user.Email, email));
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _users;
        }

        public void Insert(UserModel user)
        {
            _users.Add(user);
        }

        public void Seed()
        {
            var reader = FileReader.ReadUsersFromFile();

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                var user = new UserDto
                {
                    Name = line.Split(',')[0].ToString(),
                    Email = line.Split(',')[1].ToString(),
                    Phone = line.Split(',')[2].ToString(),
                    Address = line.Split(',')[3].ToString(),
                    UserType = line.Split(',')[4].ToString(),
                    Money = decimal.Parse(line.Split(',')[5].ToString()),
                };

                _users.Add(_factory.Create(user));
            }
            reader.Close();
        }
    }
}
