using MediatR;

namespace JobMarketPlace.Application.Features.JobOffer.Command.UpdateJobOffer
{
    public record UpdateJobOfferCommand(
        Guid Id,
        decimal Price,
   Guid JobId,
   Guid ContractorId
  ) : IRequest<Guid>;
}
