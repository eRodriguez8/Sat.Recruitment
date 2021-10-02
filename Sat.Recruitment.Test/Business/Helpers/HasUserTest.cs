using Xunit;
using System;
using FluentAssertions;
using System.Collections.Generic;

using Sat.Recruitment.Models.Abstract;
using Sat.Recruitment.Business.Helpers;
using Sat.Recruitment.Test.Models.Mothers;

namespace Sat.Recruitment.Test.Business.Helpers
{
    public class HasUserTest
    {
        [Fact]
        public void GivenANewUser_WhenValidationIsCall_ShouldReturnTrue()
        {
            var userDto = UserDtoMother.Random();
            var userList = new List<UserModel>() { NormalUserModelMother.Random() };

            Action callingWithAIncorrectValue =
                    () => HasUser.Duplicated(userList, userDto);

            callingWithAIncorrectValue
                .Should()
                .Equals(true);
        }

        [Fact]
        public void GivenAnExistentUser_WhenValidationIsCall_ShouldReturnFalse()
        {
            var userDto = UserDtoMother.Random();
            var userList = new List<UserModel>() { NormalUserModelMother.FromDto(userDto) };

            Action callingWithAIncorrectValue =
                    () => HasUser.Duplicated(userList, userDto);

            callingWithAIncorrectValue
                .Should()
                .Equals(false);
        }
    }
}
