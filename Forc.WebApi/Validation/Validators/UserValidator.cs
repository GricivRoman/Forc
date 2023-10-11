using FluentValidation;
using Forc.WebApi.Dto;

namespace Forc.WebApi.Validation.Validators
{
    public class UserValidator: AbstractValidator<UserViewModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithName("User id")
                .WithMessage("{PropertyName} must not be empty");

            RuleFor(x => x.Name)
                .MinimumLength(2)
                .WithName("Name")
                .WithMessage("{PropertyName} min length is 2");

            RuleFor(x => x.BirthDate)
                .LessThan(DateTime.Now)
                .WithName("Birth date")
                .WithMessage("{PropertyName} must be earlier than now");
        }
    }
}
