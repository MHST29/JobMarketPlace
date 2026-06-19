using MediatR;

namespace JobMarketPlace.Application.Features.Contractor.Command.CreateContructor
{
    public record CreateContractorCommand(
    string Name,
    int Rating) : IRequest<Guid>;
}
