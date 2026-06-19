using FluentValidation;

namespace JobMarketPlace.Application.Features.Job.Command.UpdateJob
{
    public class UpdateJobValidator
   : AbstractValidator<UpdateJobCommand>
    {
        public UpdateJobValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.StartDate)
                .Must(date => date >= DateOnly.MinValue)
                .WithMessage("The date is invalid.");

            RuleFor(x => x.DueDate)
                .Must(date => date >= DateOnly.MinValue)
                .WithMessage("The date is invalid.");

            RuleFor(x => x.Budget)
                .GreaterThan(0);

            RuleFor(x => x.AcceptedJobOfferId)
                .NotEmpty();
        }
    }
}