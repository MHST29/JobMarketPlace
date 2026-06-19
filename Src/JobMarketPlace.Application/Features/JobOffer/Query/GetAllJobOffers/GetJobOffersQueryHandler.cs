using JobMarketPlace.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobMarketPlace.Application.Features.JobOffer.Query.GetAllJobOffers
{
   public class GetJobOffersQueryHandler
    : IRequestHandler<
        GetJobOffersQuery,
        List<JobOfferResponseDto>>
    {
        private readonly IAppDbContext _context;

        public GetJobOffersQueryHandler(
            IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<JobOfferResponseDto>>
            Handle(
            GetJobOffersQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.JobOffers
                .AsNoTracking()
                .OrderBy(x => x.CreatedAt)
                .Select(x => new JobOfferResponseDto
                {
                    Id = x.Id,
                    Price = x.Price,
                    JobId = x.JobId,
                    ContractorId = x.ContractorId
                })
                .ToListAsync(cancellationToken);
        }
    }
}
