using JobMarketPlace.Application.Common.Interfaces;
using MediatR;

namespace JobMarketPlace.Application.Features.Job.Command.CreateJob
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, Guid>
    {
        private readonly IAppDbContext _context;

        public CreateJobCommandHandler(
            IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(
            CreateJobCommand request,
            CancellationToken cancellationToken)
        {
            var job = new Domain.Entities.Job
            {
                StartDate = request.StartDate,
                DueDate = request.DueDate,
                Budget = request.Budget,
                Description = request.Description,
                AcceptedJobOfferId = request.AcceptedJobOfferId,
                CustomerId = request.CustomerId
            };

            await _context.Jobs.AddAsync(
                job,
                cancellationToken);

            await _context.SaveChangesAsync(
                cancellationToken);

            return job.Id;
        }
    }
}
