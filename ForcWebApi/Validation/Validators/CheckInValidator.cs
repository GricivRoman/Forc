using FluentValidation;
using ForcWebApi.Dto;

namespace ForcWebApi.Validation.Validators
{
    public class CheckInValidator : AbstractValidator<CheckInViewModel>
    {
        public CheckInValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithName("UserName")
                .WithMessage("{PropertyName} is required")
                .MinimumLength(3)
                .WithName("UserName")
                .WithMessage("Required min length for {PropertyName} is 3");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithName("Password")
                .WithMessage("{PropertyName} is required")
                .MinimumLength(7)
                .WithName("Password")
                .WithMessage("Required min length for {PropertyName} is 7");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithName("Email")
                .WithMessage("{PropertyName} is required")
                .EmailAddress()
                .WithName("Email")
                .WithMessage("{PropertyName} must be an e-male type string");
        }
    }
}
