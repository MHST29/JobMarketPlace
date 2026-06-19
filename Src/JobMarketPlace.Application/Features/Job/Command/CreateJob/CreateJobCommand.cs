using MediatR;

namespace JobMarketPlace.Application.Features.Job.Command.CreateJob
{
    public record CreateJobCommand(
    DateOnly StartDate,
    DateOnly DueDate,
    decimal Budget,
    string? Description,
    Guid? AcceptedJobOfferId,
    Guid CustomerId) : IRequest<Guid>;
}