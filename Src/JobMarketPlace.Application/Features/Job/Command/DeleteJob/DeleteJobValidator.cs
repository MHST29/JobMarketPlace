using FluentValidation;

namespace JobMarketPlace.Application.Features.Job.Command.DeleteJob
{
  public class DeleteJobValidator
    : AbstractValidator<DeleteJobCommand>
    {
        public DeleteJobValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Job Id is required.");
        }
    }
}
