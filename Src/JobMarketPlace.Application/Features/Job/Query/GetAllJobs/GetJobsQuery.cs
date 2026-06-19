using MediatR;

namespace JobMarketPlace.Application.Features.Job.Query.GetAllJobs
{
       public record GetJobsQuery()
    : IRequest<List<JobResponseDto>>;
}
