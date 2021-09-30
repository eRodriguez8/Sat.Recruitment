using System;
using System.Linq;
using System.Collections.Generic;

using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Factory.User;
using Sat.Recruitment.Models.Abstract;
using Sat.Recruitment.Repository.User;
using Sat.Recruitment.Models.Exceptions;

namespace Sat.Recruitment.Business.User
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserFactory _factory;
        private readonly IUserRepository _repository;
        public UserBusiness(IUserFactory factory, IUserRepository repository)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public UserModel GetByEmail(string email)
        {
            var user = _repository.GetByEmail(email);

            if (user is null)
                throw new NotFoundException("User not found");
            
            return user;
        }

        public List<UserModel> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public void Insert(UserDto user)
        {
            if (ExistDuplicatedUser(user))
                throw new DuplicatedUserException("User is duplicated");

            _repository.Insert(_factory.Create(user));
        }

        private bool ExistDuplicatedUser(UserDto user)
        {
            var users = _repository.GetAll().ToList();

            return users.Exists(existentUser =>
            {
                return (
                    (String.Equals(existentUser.Email, user.Email) || String.Equals(existentUser.Phone, user.Phone)) || 
                        (String.Equals(existentUser.Name, user.Name) && String.Equals(existentUser.Address, user.Address))
                );
            });

        }
    }
}
