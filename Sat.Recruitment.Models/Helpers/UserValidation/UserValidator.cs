using FluentValidation;
using Sat.Recruitment.Models.Dtos;

namespace Sat.Recruitment.Models.Helpers.UserValidation
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("The name is required");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("The email is required")
                .EmailAddress()
                .WithMessage("The email is not valid");
            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("The address is required");
            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("The phone is required");
            RuleFor(x => x.UserType)
                .NotEmpty()
                .WithMessage("The type is required");
            RuleFor(x => x.Money)
                .GreaterThanOrEqualTo(0)
                .WithMessage("The amount of money cannot be less than zero");
        }
    }
}
