using MediatR;

namespace JobMarketPlace.Application.Features.Job.Command.DeleteJob
{
    public record DeleteJobCommand(Guid Id) : IRequest<bool>;
}
