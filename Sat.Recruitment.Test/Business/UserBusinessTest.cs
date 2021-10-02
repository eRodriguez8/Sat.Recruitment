using Moq;
using Xunit;
using System;
using System.Linq;
using FluentAssertions;
using System.Collections.Generic;

using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Test.Models;
using Sat.Recruitment.Factory.User;
using Sat.Recruitment.Business.User;
using Sat.Recruitment.Models.Entities;
using Sat.Recruitment.Repository.User;
using Sat.Recruitment.Models.Exceptions;
using Sat.Recruitment.Test.Models.Mothers;

namespace Sat.Recruitment.Test.Business
{
    public class UserBusinessTest : BaseTest
    {
        private IUserBusiness business;
        private Mock<IUserFactory> _mockFactory = new Mock<IUserFactory>();
        private Mock<IUserRepository> _mockRepository = new Mock<IUserRepository>();

        private UserDto userDto = UserDtoMother.Random();
        private NormalUserModel normalUser = NormalUserModelMother.Random();
        private List<NormalUserModel> userList = new List<NormalUserModel>() { NormalUserModelMother.Random() };

        private string email = RandomString.Generate(5) + "@mail.com";
        private string incorrectEmail = RandomString.Generate(5) + "@mail.com";

        public UserBusinessTest()
        {
            business = new UserBusiness(_mockFactory.Object, _mockRepository.Object);
        }

        internal override void SetupMockObjects()
        {
            _mockFactory
                .Setup(f => f.Create(userDto))
                .Returns(normalUser)
                .Verifiable();

            _mockRepository
                .Setup(r => r.GetByEmail(email))
                .Returns(normalUser)
                .Verifiable();
            
            _mockRepository
                .Setup(r => r.GetByEmail(incorrectEmail))
                .Returns<NormalUserModel>(null)
                .Verifiable();

            _mockRepository
                .Setup(r => r.GetAll())
                .Returns(userList)
                .Verifiable();

            _mockRepository
                .Setup(r => r.Insert(normalUser))
                .Verifiable();
        }

        [Fact]
        public void GivenAEmail_WhenBusinessGetByEmailIsCall_ShouldReturnAUser()
        {
            var user = business.GetByEmail(email);

            user
                .Should()
                .Be(normalUser);
        }

        [Fact]
        public void GivenAIncorrectEmail_WhenBusinessGetByEmailIsCall_ShouldThrownException()
        {
            Action user = () => business.GetByEmail(incorrectEmail);

            user
                .Should()
                .Throw<NotFoundException>("User not found");
        }

        [Fact]
        public void GivenAGetAllRequest_WhenBusinessGetAllIsCall_ShouldReturnUserList()
        {
            var users = business.GetAll().ToList();

            users
                .Should()
                .Equal(userList);
        }

        [Fact]
        public void GivenANormalUser_WhenBusinessInsertIsCall_ShouldPass()
        {
            Action insert = () => business.Insert(userDto);

            insert
                .Should()
                .NotThrow();
        }
    }
}
