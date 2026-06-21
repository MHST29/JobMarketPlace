using FluentValidation;

namespace JobMarketPlace.Application.Features.JobOffer.Command.UpdateJobOffer
{
    public class UpdateJobOfferValidator : AbstractValidator<UpdateJobOfferCommand>
    {
        public UpdateJobOfferValidator()
        {
            RuleFor(x => x.Id)
              .NotNull()
              .NotEmpty();

            RuleFor(x => x.ContractorId)
                .NotEmpty();

            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }
}
