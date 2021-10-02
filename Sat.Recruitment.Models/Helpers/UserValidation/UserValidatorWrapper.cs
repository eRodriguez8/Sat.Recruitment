using FluentValidation.Results;
using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Models.Exceptions;

namespace Sat.Recruitment.Models.Helpers.UserValidation
{
    public class UserValidatorWrapper
    {
        public static void Validate(UserDto user)
        {
            UserValidator validator = new UserValidator();
            ValidationResult result = validator.Validate(user);

            if (!result.IsValid)
            {
                string errorMsg = "";

                foreach (var error in result.Errors)
                {
                    errorMsg = string.Join(",", $"Error in {error.PropertyName}: {error.ErrorMessage}");
                }

                throw new BadRequestException(errorMsg);
            }
        }
    }
}
