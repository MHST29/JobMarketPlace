using MediatR;

namespace JobMarketPlace.Application.Features.JobOffer.Command.DeleteJobOffer
{
    public record DeleteJobOfferCommand(Guid Id) : IRequest<bool>;
}
