using JobMarketPlace.Application.Common.Interfaces;
using JobMarketPlace.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobMarketPlace.Application.Features.Job.Command.UpdateJob
{
  public class UpdateJobCommandHandler
    : IRequestHandler<UpdateJobCommand, Guid>
    {
        private readonly IAppDbContext _context;

        public UpdateJobCommandHandler(
            IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(
            UpdateJobCommand request,
            CancellationToken cancellationToken)
        {
            var job = await _context.Jobs
                .FirstOrDefaultAsync(
                    x => x.Id == request.Id,
                    cancellationToken);

            if (job is null)
            {
                throw new KeyNotFoundException(
                    $"Product {request.Id} not found.");
            }

            job.StartDate = request.StartDate;
            job.DueDate = request.DueDate;
            job.Budget = request.Budget;
            job.Description = request.Description;
            job.AcceptedJobOfferId = request.AcceptedJobOfferId;
            job.CustomerId = request.CustomerId;

            await _context.SaveChangesAsync(
                cancellationToken);

            return job.Id;
        }
    }
}
