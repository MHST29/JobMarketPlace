using JobMarketPlace.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobMarketPlace.Application.Features.Job.Query.GetAllJobs
{
   public class GetJobsQueryHandler
    : IRequestHandler<
        GetJobsQuery,
        List<JobResponseDto>>
    {
        private readonly IAppDbContext _context;

        public GetJobsQueryHandler(
            IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<JobResponseDto>>
            Handle(
            GetJobsQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Jobs
                .AsNoTracking()
                .OrderBy(x => x.StartDate)
                .Select(x => new JobResponseDto
                {
                    Id = x.Id,
                    StartDate = x.StartDate,
                    DueDate = x.DueDate,
                    Budget = x.Budget,
                    Description = x.Description,
                    AcceptedJobOfferId = x.AcceptedJobOfferId,
                    CustomerId = x.CustomerId
                })
                .ToListAsync(cancellationToken);
        }
    }
}
