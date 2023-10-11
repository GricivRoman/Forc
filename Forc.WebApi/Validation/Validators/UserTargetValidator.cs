using FluentValidation;
using Forc.WebApi.Dto;

namespace Forc.WebApi.Validation.Validators
{
    public class UserTargetValidator: AbstractValidator<UserTargetViewModel>
    {
        public UserTargetValidator()
        {
            RuleFor(x => x.DateFinish)
                .GreaterThan(x => x.DateStart)
                .WithName("Finish date")
                .WithMessage("{PropertyName} must be later then start date")
                .GreaterThan(DateTime.Now)
                .WithName("Finish date")
                .WithMessage("{PropertyName} must be later then current date");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithName("User ID")
                .WithMessage("{PropertyName} must not be empty");

            RuleFor(x => x.CurrentBodyWeight)
                .GreaterThan(0)
                .WithName("Current body weight")
                .WithMessage("{PropertyName} must be greater than 0");

            RuleFor(x => x.TargetBodyWeight)
                .GreaterThan(0)
                .WithName("Target body weight")
                .WithMessage("{PropertyName} must be greater than 0");
        }
    }
}
