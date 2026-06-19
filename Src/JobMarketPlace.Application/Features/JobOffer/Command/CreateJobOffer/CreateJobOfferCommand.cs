using JobMarketPlace.Domain.Entities;
using MediatR;

namespace JobMarketPlace.Application.Features.JobOffer.Command.CreateJobOffer
{
    public record CreateJobOfferCommand(
   decimal Price,
   Guid JobId,
   Guid ContractorId) : IRequest<Guid>;
}
