using JobMarketPlace.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobMarketPlace.Application.Features.Job.Command.DeleteJob
{
    public class DeleteJobCommandHandler
    : IRequestHandler<DeleteJobCommand, bool>
    {
        private readonly IAppDbContext _context;

        public DeleteJobCommandHandler(
            IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(
            DeleteJobCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _context.Jobs
                .FirstOrDefaultAsync(
                    x => x.Id == request.Id,
                    cancellationToken);

            if (product is null)
            {
                throw new KeyNotFoundException(
                    $"Job '{request.Id}' not found.");
            }

            // Hard delete
            _context.Jobs.Remove(product);

            await _context.SaveChangesAsync(
                cancellationToken);

            return true;
        }
    }
}
