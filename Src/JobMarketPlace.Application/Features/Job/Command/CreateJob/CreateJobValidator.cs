using FluentValidation;

namespace JobMarketPlace.Application.Features.Job.Command.CreateJob
{
     public class CreateJobValidator
    : AbstractValidator<CreateJobCommand>
    {
        public CreateJobValidator()
        {
            RuleFor(x => x.StartDate)
                .Must(date => date >= DateOnly.MinValue)
                .WithMessage("The date is invalid.");

            RuleFor(x => x.DueDate)
                .Must(date => date >= DateOnly.MinValue)
                .WithMessage("The date is invalid.");

            RuleFor(x => x.Budget)
                .GreaterThan(0);
        }
    }
}
