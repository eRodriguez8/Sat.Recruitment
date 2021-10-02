using Xunit;
using System;
using FluentAssertions;

using Sat.Recruitment.Test.Models.Mothers;
using Sat.Recruitment.Models.Helpers.UserValidation;
using Sat.Recruitment.Models.Exceptions;

namespace Sat.Recruitment.Test.Common.Helpers
{
    public class UserValidatorWrapperTest
    {
        [Fact]
        public void GivenAUserDto_WhenUserValidationIsCall_ShouldPass()
        {
            var user = UserDtoMother.Random();

            Action correctFormat =
                () => UserValidatorWrapper.Validate(user);

            correctFormat
                .Should()
                .NotThrow();
        }

        [Fact]
        public void GivenAUserDtoWithIncorrectName_WhenUserValidationIsCall_ShouldThrownException()
        {
            var user = UserDtoMother.Random();
            
            user.Name = "";

            Action incorrectFormat =
                () => UserValidatorWrapper.Validate(user);

            incorrectFormat
                .Should()
                .Throw<BadRequestException>("The name is required");
        }

        [Fact]
        public void GivenAUserDtoWithIncorrectEmail_WhenUserValidationIsCall_ShouldThrownException()
        {
            var user = UserDtoMother.Random();

            user.Email = "";

            Action incorrectFormat =
                () => UserValidatorWrapper.Validate(user);

            incorrectFormat
                .Should()
                .Throw<BadRequestException>("The email is required");
        }

        [Fact]
        public void GivenAUserDtoWithIncorrectAdress_WhenUserValidationIsCall_ShouldThrownException()
        {
            var user = UserDtoMother.Random();

            user.Address = "";

            Action incorrectFormat =
                () => UserValidatorWrapper.Validate(user);

            incorrectFormat
                .Should()
                .Throw<BadRequestException>("The address is required");
        }

        [Fact]
        public void GivenAUserDtoWithIncorrectPhone_WhenUserValidationIsCall_ShouldThrownException()
        {
            var user = UserDtoMother.Random();

            user.Phone = "";

            Action incorrectFormat =
                () => UserValidatorWrapper.Validate(user);

            incorrectFormat
                .Should()
                .Throw<BadRequestException>("The phone is required");
        }

        [Fact]
        public void GivenAUserDtoWithIncorrectType_WhenUserValidationIsCall_ShouldThrownException()
        {
            var user = UserDtoMother.Random();

            user.UserType = "";

            Action incorrectFormat =
                () => UserValidatorWrapper.Validate(user);

            incorrectFormat
                .Should()
                .Throw<BadRequestException>("The type is required");
        }

        [Fact]
        public void GivenAUserDtoWithIncorrectMoney_WhenUserValidationIsCall_ShouldThrownException()
        {
            var user = UserDtoMother.Random();

            user.Money = -1;

            Action incorrectFormat =
                () => UserValidatorWrapper.Validate(user);

            incorrectFormat
                .Should()
                .Throw<BadRequestException>("The amount of money cannot be less than zero");
        }
    }
}
