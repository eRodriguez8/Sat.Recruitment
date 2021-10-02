using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Moq;
using Sat.Recruitment.Factory.User;
using Sat.Recruitment.Models.Abstract;
using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Models.Entities;
using Sat.Recruitment.Repository.User;
using Sat.Recruitment.Test.Models;
using Sat.Recruitment.Test.Models.Mothers;
using Xunit;

namespace Sat.Recruitment.Test.Repository.User
{
    public class UserRepositoryTest : BaseTest
    {
        private IUserRepository _repository;
        private Mock<IUserFactory> _mockFactory = new Mock<IUserFactory>();

        private List<UserModel> usersList;
        private NormalUserModel normalUser = NormalUserModelMother.Random();
        private PremiumUserModel premiumUser = PremiumUserModelMother.Random();
        private string incorrectEmail = RandomString.Generate(5) + "@mail.com";

        public UserRepositoryTest()
        {
            _repository = new UserRepository(_mockFactory.Object);
            _repository.Seed();
        }

        internal override void SetupMockObjects()
        {
            _mockFactory
              .Setup(f => f.Create(It.IsAny<UserDto>()))
              .Returns(normalUser)
              .Verifiable();

            usersList = new List<UserModel>();
            usersList.Add(normalUser);
            usersList.Add(normalUser);
            usersList.Add(normalUser);
        }

        [Fact]
        public void GivenAGetAllRequest_WhenRepositoruGetAllIsCall_ShouldReturnUserList()
        {
            var users = _repository.GetAll();

            users
                .Should()
                .Equal(usersList);
        }

        [Fact]
        public void GivenAEmail_WhenBusinessGetByEmailIsCall_ShouldReturnAUser()
        {
            var user = _repository.GetByEmail(normalUser.Email);

            user
                .Should()
                .Be(normalUser);
        }

        [Fact]
        public void GivenAIncorrectEmail_WhenBusinessGetByEmailIsCall_ShouldThrownException()
        {
            var user = _repository.GetByEmail(incorrectEmail);

            user
                .Should()
                .Be(null);
        }

        [Fact]
        public void GivenANormalUser_WhenBusinessInsertIsCall_ShouldPass()
        {
            Action insert = () => _repository.Insert(premiumUser);

            usersList.Add(premiumUser);

            insert
                .Should()
                .NotThrow()
                .Should()
                .Equals(usersList);
        }
    }
}
