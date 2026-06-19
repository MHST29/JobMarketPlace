using JobMarketPlace.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobMarketPlace.Application.Features.JobOffer.Command.DeleteJobOffer
{
    public class DeleteJobOfferCommandHandler
    : IRequestHandler<DeleteJobOfferCommand, bool>
    {
        private readonly IAppDbContext _context;

        public DeleteJobOfferCommandHandler(
            IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(
            DeleteJobOfferCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _context.JobOffers
                .FirstOrDefaultAsync(
                    x => x.Id == request.Id,
                    cancellationToken);

            if (product is null)
            {
                throw new KeyNotFoundException(
                    $"Job Offer '{request.Id}' not found.");
            }

            // Hard delete
            _context.JobOffers.Remove(product);

            await _context.SaveChangesAsync(
                cancellationToken);

            return true;
        }
    }
}