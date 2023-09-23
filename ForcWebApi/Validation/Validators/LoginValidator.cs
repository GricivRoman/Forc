using FluentValidation;
using ForcWebApi.Dto;

namespace ForcWebApi.Validation.Validators
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserNameOrEmail)
                .NotEmpty()
                .WithName("User name or E-mail")
                .WithMessage("{PropertyName} is required");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithName("Password")
                .WithMessage("{PropertyName} is required");
        }
    }
}
