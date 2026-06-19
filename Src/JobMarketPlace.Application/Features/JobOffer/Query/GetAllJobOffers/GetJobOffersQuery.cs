using MediatR;

namespace JobMarketPlace.Application.Features.JobOffer.Query.GetAllJobOffers
{
   public record GetJobOffersQuery()
    : IRequest<List<JobOfferResponseDto>>;
}
