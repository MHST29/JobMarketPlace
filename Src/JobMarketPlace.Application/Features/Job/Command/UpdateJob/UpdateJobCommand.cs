using MediatR;

namespace JobMarketPlace.Application.Features.Job.Command.UpdateJob
{
     public record UpdateJobCommand(
      Guid Id,
      DateOnly StartDate,
    DateOnly DueDate,
    decimal Budget,
    string? Description,
    Guid? AcceptedJobOfferId,
    Guid CustomerId
  ) : IRequest<Guid>;
}
