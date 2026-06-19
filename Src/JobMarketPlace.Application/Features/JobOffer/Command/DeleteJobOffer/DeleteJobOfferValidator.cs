using FluentValidation;
using JobMarketPlace.Application.Features.Job.Command.DeleteJob;

namespace JobMarketPlace.Application.Features.JobOffer.Command.DeleteJobOffer
{
    public class DeleteJobOfferValidator : AbstractValidator<DeleteJobOfferCommand>
    {
        public DeleteJobOfferValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Job Offer Id is required.");
        }
    }
}
