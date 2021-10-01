using Xunit;
using System;
using FluentAssertions;

using Sat.Recruitment.Models.Helpers;

namespace Sat.Recruitment.Test.Models.Helpers
{
    public class EmailValidatorTest
    {
        [Theory]
        [InlineData("email.com")]
        public void GivenAIncorrectEmail_WhenEmailValidatorIsCall_ShouldThrownEmailException(string email)
        {
            Action callingWithAIncorrectValue =
                () => EmailValidator.ValidateEmail(email);

            callingWithAIncorrectValue
                .Should()
                .Throw<FormatException>("The specified string is not in the form required for an e-mail address.");
        }

        [Theory]
        [InlineData("email@mail.com")]
        public void GivenACorrectEmail_WhenEmailValidatorIsCall_ShouldPass(string email)
        {
            Action callingWithAIncorrectValue =
                () => EmailValidator.ValidateEmail(email);

            callingWithAIncorrectValue
                .Should()
                .NotThrow();
        }
    }
}
