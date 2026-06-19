using JobMarketPlace.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobMarketPlace.Application.Features.JobOffer.Command.UpdateJobOffer
{
    public class UpdateJobOfferCommandHandler : IRequestHandler<UpdateJobOfferCommand, Guid>
    {
        private readonly IAppDbContext _context;

        public UpdateJobOfferCommandHandler(
            IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(
            UpdateJobOfferCommand request,
            CancellationToken cancellationToken)
        {
            var jobOffer = await _context.JobOffers
                .FirstOrDefaultAsync(
                    x => x.Id == request.Id,
                    cancellationToken);

            if (jobOffer is null)
            {
                throw new KeyNotFoundException(
                    $"Product {request.Id} not found.");
            }

            jobOffer.Price = request.Price;
            jobOffer.JobId = request.JobId;
            jobOffer.ContractorId = request.ContractorId;

            await _context.SaveChangesAsync(
                cancellationToken);

            return jobOffer.Id;
        }
    }
}
