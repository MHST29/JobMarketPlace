using JobMarketPlace.Application.Common.Interfaces;
using JobMarketPlace.Application.Features.Contractor.Command.CreateContructor;
using MediatR;

namespace JobMarketPlace.Application.Features.JobOffer.Command.CreateJobOffer
{
    public class CreateJobOfferCommandHandler : IRequestHandler<CreateJobOfferCommand, Guid>
    {
        private readonly IAppDbContext _context;

        public CreateJobOfferCommandHandler(
            IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(
            CreateJobOfferCommand request,
            CancellationToken cancellationToken)
        {
            var jobOffer = new Domain.Entities.JobOffer
            {
                Price = request.Price,
                JobId = request.JobId,
                ContractorId = request.ContractorId,
            };

            await _context.JobOffers.AddAsync(
                jobOffer,
                cancellationToken);

            await _context.SaveChangesAsync(
                cancellationToken);

            return jobOffer.Id;
        }
    }
}
